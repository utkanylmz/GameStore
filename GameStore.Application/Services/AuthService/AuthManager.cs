using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using GameStore.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository; 
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, 
            ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken); 
            return addedRefreshToken;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {

            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(u => 
                                                                 u.UserId == user.Id,
                                                                   include: u => u.Include(u => u.OperationClaim));
            //Kullaniciyi getir ayni zamanda kullanicin claimlerini include et.

            IList<OperationClaim> operationClaims = userOperationClaims.Items.Select(u => new OperationClaim 
                                                      { Id = u.OperationClaimId, Name = u.OperationClaim.Name }).ToList();
          //Kullanicin operation claimlerini hepsini don donduklerin Id ve name'ini al  onu bir listeye cevir.
            
            AccessToken accessToken =_tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
            //TokenHelper sinindaki create token metodunu kullarak bir accesstoken uretiyor.
        }

        public async Task<RefreshToken> CreateRefreshToken(User user,string ipAddress)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            return await Task.FromResult(refreshToken);
        }
    }
}
