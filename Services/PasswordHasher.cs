using System.Security.Cryptography;
using System.Text;

namespace Journal_App_MAUI.Services
{
    public static class PasswordHasher
    {
        // Generate a random salt
        public static string GenerateSalt()
        {
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        // Hash password with salt
        public static string HashWithSalt(string input, string salt)
        {
            var combined = Encoding.UTF8.GetBytes(input + salt);
            using var sha256 = SHA256.Create();
            var hashBytes = sha256.ComputeHash(combined);
            return $"{Convert.ToBase64String(hashBytes)}:{salt}"; // store hash:salt together
        }

        // Verify input against stored hash:salt
        public static bool Verify(string input, string storedHashSalt)
        {
            var parts = storedHashSalt.Split(':');
            if (parts.Length != 2) return false;

            var hash = parts[0];
            var salt = parts[1];

            var newHash = Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(input + salt)));
            return newHash == hash;
        }
    }
}
