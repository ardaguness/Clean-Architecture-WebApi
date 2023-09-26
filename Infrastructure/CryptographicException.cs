using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IEncryptionService
    {
        string Decrypt(string encryptedText);
        string Encrypt(string plainText);
    }

    public class EncryptionService : IEncryptionService
    {
        private readonly IDataProtector _dataProtector;

        public EncryptionService(IDataProtectionProvider dataProtectionProvider)
        {
            string appName = "Clean-Architecture-WebApi";
            _dataProtector = dataProtectionProvider.CreateProtector("MySuperSecretKey");
        }

        public string Decrypt(string encryptedText)
        {
            return _dataProtector.Unprotect(encryptedText);
        }

        public string Encrypt(string plainText)
        {
            return _dataProtector.Protect(plainText);
        }
    }

}
