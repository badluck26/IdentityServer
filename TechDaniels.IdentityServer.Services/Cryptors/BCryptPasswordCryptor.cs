using TechDaniels.IdentityServer.Core.Cryptors;

namespace TechDaniels.IdentityServer.Services.Cryptors
{
    internal class BCryptPasswordCryptor : IPasswordCryptor
    {
        public bool Challenge(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
        }

        public string Encrypt(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
        }
    }
}
