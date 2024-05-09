using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebAPIs.Token
{
    public class TokenJWTBuilder
    {
        private SecurityKey SecurityKey = null;
        private string subject = "";
        private string issuer = "";
        private string audience = "";
        private Dictionary<string, string> claims = new Dictionary<string, string>();
        private int expiryInMinutes = 5;


        public TokenJWTBuilder AddSecurityKey(SecurityKey securityKey)
        {
            this.SecurityKey = securityKey;
            return this;
        }

        public TokenJWTBuilder AddSubject(string subject)
        {
            this.subject = subject;
            return this;
        }

        public TokenJWTBuilder AddIssuer(string issuer)
        {
            this.issuer = issuer;
            return this;
        }

        public TokenJWTBuilder AddAudience(string audience)
        {
            this.audience = audience;
            return this;
        }

        public TokenJWTBuilder AddClaim(string trype, string value)
        {
            this.claims.Add(trype, value);
            return this;
        }

        private void EnsureArguments()
        {
            if (this.SecurityKey == null)
                throw new ArgumentNullException("Security key");

            if (string.IsNullOrEmpty(this.subject))
                throw new ArgumentNullException("Subject");

            if (string.IsNullOrEmpty(this.issuer))
                throw new ArgumentNullException("issuer");

            if (string.IsNullOrEmpty(this.audience))
                throw new ArgumentNullException("Audience");

        }

        public TokenJWT Builder()
        {
            EnsureArguments();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,this.subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }.Union(this.claims.Select(item => new Claim(item.Key, item.Value)));

            var token = new JwtSecurityToken(
               
                issuer: this.issuer,
                audience: this.audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                signingCredentials: new SigningCredentials(
                                                            this.SecurityKey,
                                                            SecurityAlgorithms.HmacSha256
                                                          )

                );

            return new TokenJWT(token);
            
        }
    }
}
