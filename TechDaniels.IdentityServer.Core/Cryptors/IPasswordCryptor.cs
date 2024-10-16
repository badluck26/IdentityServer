using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechDaniels.IdentityServer.Core.Cryptors
{
    public interface IPasswordCryptor
    {
        public string Encrypt(string password);
        public bool Challenge(string password, string passwordHash);
    }
}
