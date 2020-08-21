using Microsoft.IdentityModel.Tokens;
using SSIS_BOOT.Components.JWT.Interfaces;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

/**
 * JWT service
 * responsible to generate token, validate token and decrypt token
 * 
 * @author WUYUDING
 */
namespace SSIS_BOOT.Components.JWT.Impl
{
    public class JWTService:IAuthService
    {
        //The secret key we use to encrypt out token with.
        public string SecretKey { get; set; }= "TW9zaGVFcmV6UHJpdmF0ZUtleQ==";

        public int ExpireMinutes { get; set; } = 60*24*7; //7 days

        private SecurityKey GetSymmetricSecurityKey()
        {
            byte[] symmetricKey = Convert.FromBase64String(SecretKey);
            return new SymmetricSecurityKey(symmetricKey);
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = GetSymmetricSecurityKey()
            };
        }

        //Validate whether a given token is valid or not. 
        //And return true in case the token is valid otherwise it will return false.
        public bool IsTokenValid(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Given token is null or empty.");
            }
            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters();

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(token, 
                    tokenValidationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Generate token by given model.
        //Validate whether the given model is valid, then get the symmetric key.
        //Encrypt the token and return it
        public string GenerateToken(Employee emp)
        {
            if (emp == null)
            {
                return null;
            }
            IAuthContainerModel model = GetJWTContainerModel(emp);
            if (model == null || model.Claims == null || model.Claims.Length == 0)
            {
                throw new ArgumentException("Arguments to create token are not valid.");
            }

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(model.Claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(ExpireMinutes)),
                SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(), model.SecurityAlgorithm)
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            string token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return token;
        }

        //Receive the claims of token by given token as string.
        public IEnumerable<Claim> GetTokenClaims(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Given token is null or empty.");
            }

            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters();

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                return tokenValid.Claims;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public JWTContainerModel GetJWTContainerModel(Employee emp)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    //new Claim(ClaimTypes.NameIdentifier,emp.Id.ToString()),
                    new Claim(ClaimTypes.Name,emp.Name),
                    new Claim(ClaimTypes.Email,emp.Email),
                    new Claim(ClaimTypes.Role,emp.Role),
                    new Claim(ClaimTypes.Expired, DateTime.UtcNow.AddMinutes(Convert.ToInt32(ExpireMinutes)).ToString()),
                    new Claim(ClaimTypes.NameIdentifier,emp.Id+ "")
                }

            };
        }

    }
}
