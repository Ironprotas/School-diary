using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JWT.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "AutServer";
        public const string AUDIENCE = "AutClient";
        const string KEY = "mysupersecret_secretkey!123";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
