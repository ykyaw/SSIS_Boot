using SSIS_BOOT.Components.JWT.Impl;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


/**
 * @author WUYUDING
 */
namespace SSIS_BOOT.Components.JWT.Interfaces
{
    public interface IAuthService
    {
        public string SecretKey { get; set; }
        public int ExpireMinutes { get; set; }

        public bool IsTokenValid(string token);
        public string GenerateToken(User user);
        public IEnumerable<Claim> GetTokenClaims(string token);
        public JWTContainerModel GetJWTContainerModel(User user);
    }
}
