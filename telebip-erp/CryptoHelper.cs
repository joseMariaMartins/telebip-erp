using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace telebip_erp
{
    public static class CryptoHelper
    {
        // ⚠️ Se mudar essa chave ou o salt, nada mais descriptografa!
        private static readonly string chaveSecreta = "TELEBIP_MASTER_KEY_2025";
        private static readonly byte[] salt = Encoding.UTF8.GetBytes("TeleBipSalt2025");

        // Hash para senhas de USUÁRIO (não reversível)
        public static string GerarHashSHA256(string texto)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha.ComputeHash(bytes);

                // 🔹 Converte para HEX em vez de Base64
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2")); // duas casas hexadecimais

                return sb.ToString();
            }
        }

        // Criptografar (reversível) p/ segredos como senha de e-mail
        public static string CriptografarAES(string texto)
        {
            using (Aes aes = Aes.Create())
            {
                var kdf = new Rfc2898DeriveBytes(chaveSecreta, salt, 10000);
                aes.Key = kdf.GetBytes(32);
                aes.IV = kdf.GetBytes(16);

                using var ms = new MemoryStream();
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                using (var sw = new StreamWriter(cs))
                    sw.Write(texto);

                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public static string DescriptografarAES(string base64)
        {
            using (Aes aes = Aes.Create())
            {
                var kdf = new Rfc2898DeriveBytes(chaveSecreta, salt, 10000);
                aes.Key = kdf.GetBytes(32);
                aes.IV = kdf.GetBytes(16);

                byte[] dados = Convert.FromBase64String(base64);
                using var ms = new MemoryStream(dados);
                using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
                using var sr = new StreamReader(cs);
                return sr.ReadToEnd();
            }
        }
    }
}
