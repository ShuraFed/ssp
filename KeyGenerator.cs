using System.Security.Cryptography;
using System;
using System.Text;

namespace stonepaper
{
    class KeyGenerator
    {
        internal static string GenerateKey()
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            byte[] key = new byte[16];
            rng.GetBytes(key);
            string r = BitConverter.ToString(key).Replace("-",string.Empty);
            return r;
        }

        internal static int ChooseTurn(int max)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] t = new byte[4];
            rng.GetBytes(t);
            int i = BitConverter.ToInt32(t, 0);
            int result = Math.Abs(i % max);
            return result;
        }

        internal static string GenerateHMAC(int pc, string key)
        {
            byte[] bkey = Encoding.Default.GetBytes(key);
            HMACSHA256 hmac = new HMACSHA256(bkey);
            byte[] bstr = Encoding.Default.GetBytes(pc.ToString());
            var bhash = hmac.ComputeHash(bstr);
            return BitConverter.ToString(bhash).Replace("-", string.Empty);
        }
    }
}
