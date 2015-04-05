using System;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace HaloOnline.Server.Core.Http.Auth
{
    public class HaloTokenFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly TokenValidationParameters _validationParameters;

        public HaloTokenFormat(JwtSecurityTokenHandler securityTokenHandler,
            TokenValidationParameters validationParameters)
        {
            if (validationParameters == null) throw new ArgumentNullException("validationParameters");
            _validationParameters = validationParameters;
            _tokenHandler = securityTokenHandler;
        }

        public string Protect(AuthenticationTicket data)
        {
            ClaimsIdentity subject = data.Identity;
            DateTime? validFrom = DateTime.UtcNow;
            DateTime? validTo = DateTime.UtcNow.AddMinutes(_tokenHandler.TokenLifetimeInMinutes);
            JwtSecurityToken token = _tokenHandler.CreateToken(
                _validationParameters.ValidIssuer,
                _validationParameters.ValidAudience,
                subject,
                validFrom,
                validTo,
                GetHmacSigningCredentials()
                );

            return _tokenHandler.WriteToken(token);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            if (protectedText == null) throw new ArgumentNullException("protectedText");
            SecurityToken securityToken = _tokenHandler.ReadToken(protectedText);
            ;
            if (securityToken == null) throw new ArgumentException("protectedText is not a valid token");

            SecurityToken validatedToken;
            var claimsPrincipal = _tokenHandler.ValidateToken(protectedText, _validationParameters, out validatedToken);
            AuthenticationProperties authenticationProperties = new AuthenticationProperties();
            DateTime issued = validatedToken.ValidFrom;
            if (issued != DateTime.MinValue)
            {
                authenticationProperties.IssuedUtc = issued.ToUniversalTime();
            }
            DateTime expires = validatedToken.ValidTo;
            if (expires != DateTime.MinValue)
            {
                authenticationProperties.ExpiresUtc = expires.ToUniversalTime();
            }
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimsPrincipal.Identity);
            return new AuthenticationTicket(claimsIdentity, authenticationProperties);
        }

        private SigningCredentials GetHmacSigningCredentials()
        {
            return new SigningCredentials(
                _validationParameters.IssuerSigningKey,
                "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256",
                "http://www.w3.org/2001/04/xmlenc#sha256");
        }
    }
}
