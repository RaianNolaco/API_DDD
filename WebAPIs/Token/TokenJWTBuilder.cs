using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;

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

            
        }
    }
}
