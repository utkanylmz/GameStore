using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using GameStore.Application.Features.Auths.Dtos;
using GameStore.Application.Features.Auths.Rules;
using GameStore.Application.Services.AuthService;
using GameStore.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Auths.Commands.Register
{
    public class RegisterCommand:IRequest<RegisteredDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAddress { get; set; }
        //Refresh Tokenda Ip bazli doğrulama ve yönetim bazlı süreçleri vardır onu'da talep ederiz.


        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
        {
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;

            public RegisterCommandHandler(AuthBusinessRules authBusinessRules, 
                IUserRepository userRepository, IAuthService authService)
            {
                _authBusinessRules = authBusinessRules;
                _userRepository = userRepository;
                _authService = authService;
            }

          
            public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.EMailCanNotBeDuplicatedWhenRegistered(request.UserForRegisterDto.Email);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

                User newUser = new()
                {
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    Email = request.UserForRegisterDto.Email,
                    NickName = request.UserForRegisterDto.NickName,
                    BirthDate = Convert.ToDateTime(request.UserForRegisterDto.BirthDate),
                    TelNumber = request.UserForRegisterDto.TelNumber,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    IsActive = true
                };
                User createdUser = await _userRepository.AddAsync(newUser);
                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
                
                RegisteredDto registeredDto = new() { RefreshToken=addedRefreshToken,AccessToken=createdAccessToken};
                return registeredDto;

            }

               
                   

            
        }
    }
}
