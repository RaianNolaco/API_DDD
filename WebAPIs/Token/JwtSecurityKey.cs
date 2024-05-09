using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebAPIs.Token
{
    public class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secrete) {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secrete));
        
        }
    }
}
