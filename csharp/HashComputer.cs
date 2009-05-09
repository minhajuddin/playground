using System;
using System.Text;
using System.Security.Cryptography;

namespace Util {
    class Program {
        public static void Main(string[] args) {
            var initColor = Console.ForegroundColor;
            if (args.Length == 0) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect number of arguments\r\n Pass an word as an argument \r\n e.g. HashComputer Whatever");
            } else {
                var input = args[0];
                ICryptographerService crypto = new CryptographerService();
                var hashedInput = crypto.GetHash(input);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The Hash of '{0}' is '{1}' ", input, hashedInput);
            }
            Console.ForegroundColor = initColor;
        }
    }

    public class CryptographerService : ICryptographerService {
        public string GetHash(string password) {
            var pwdBytes = Encoding.UTF8.GetBytes(password);
            var sha512 = SHA512.Create();

            var hashedPasswordBytes = sha512.ComputeHash(pwdBytes);
            return GetHexString(hashedPasswordBytes);
        }

        private string GetHexString(byte[] inputBytes) {
            var sb = new StringBuilder();
            foreach (var b in inputBytes) {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }

    public interface ICryptographerService {
        string GetHash(string password);
    }
}
