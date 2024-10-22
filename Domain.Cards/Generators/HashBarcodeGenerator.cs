using System.Security.Cryptography;
using System.Text;

namespace Domain.Barcode.Generators
{
    public class HashBarcodeGenerator<SaltObject> 
        (SaltObject saltObject, int minPropsCount)
        : IBarcodeGenerator where SaltObject : class
    {
        private readonly SaltObject saltObject = saltObject;
        private readonly int minPropsCount = minPropsCount;

        public string GenerateBarcode()
        {
            string input = this.PrepareStringInputFromObject(saltObject);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder numericHash = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    numericHash.Append(b % 10);
                }
                string barcode = numericHash.ToString().Substring(0,12);
                return barcode;
            }
        }


        private string PrepareStringInputFromObject(SaltObject salt)
        {
            var properties = this.saltObject.GetType().GetProperties();
            if (properties.Length < minPropsCount)
            {
                throw new ArgumentException($"Min props count have to be more than {this.minPropsCount}");
            }

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var prop in properties)
            {
                var value = prop.GetValue(salt)?.ToString() ?? string.Empty;
                stringBuilder.Append(value);
            }
            return stringBuilder.ToString();
        }
    }
}
