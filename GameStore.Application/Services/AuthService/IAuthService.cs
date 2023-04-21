using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services.AuthService
{
    public interface IAuthService
    {
        public Task<AccessToken> CreateAccessToken(User user);
        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
        public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);

//Bir Kullanıcı Register olduğunda  ona Access Token ,Refresh Token'ı geri geri donmemiz gerekiyor
//ve refresh tokenını db ye eklememiz gerekiyor.Bu işlemleri Sadace register olduğunda değil login oldunda 'da yapacağımız için
// bunları metotlarını Serviceye yazıp managerda metotların içini doldurup command'de çağıracağız. 
    }
}
