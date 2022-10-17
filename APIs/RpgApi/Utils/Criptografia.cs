using RpgApi.Models;
using RpgApi.Data;
using System.Security.Cryptography;

namespace RpgApi.Utils // o NameSpace deve estar relacionado ao caminho do arquivo
{
    public class Criptografia
    {
        public static void CriarPasswordHash(string password, out byte[] hash, out byte[] salt)
        {
            using (var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}