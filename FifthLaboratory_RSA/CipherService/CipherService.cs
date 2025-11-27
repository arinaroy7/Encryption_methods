using System;
using System.Numerics;
using System.Text;

namespace FifthLaboratory_RSA

{
    public class CipherService
    {
        private static readonly Random _rand = new Random();

        private bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }

        private int GeneratePrime(int min, int max)
        {
            int num;
            do
            {
                num = _rand.Next(min, max);
            } while (!IsPrime(num));
            return num;
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        private int ModInverse(int e, int phi)
        {
            int a0 = phi, a1 = e;
            int x0 = 0, x1 = 1;

            while (a1 > 0)
            {
                int q = a0 / a1;
                int tmp = a1;
                a1 = a0 - q * a1;
                a0 = tmp;

                tmp = x1;
                x1 = x0 - q * x1;
                x0 = tmp;
            }

            if (a0 != 1) return -1;

            if (x0 < 0)
                x0 += phi;

            return x0;
        }

        private int GetE(int phi)
        {
            for (int e = 3; e < phi; e += 2)
                if (GCD(e, phi) == 1)
                    return e;
            return -1;
        }

        public string GenerateKeys()
        {
            int p, q;

            do
            {
                p = GeneratePrime(500, 5000);
                q = GeneratePrime(500, 5000);
            }
            while (p == q);

            int n = p * q;
            int phi = (p - 1) * (q - 1);

            int e = GetE(phi);
            int d = ModInverse(e, phi);

            return $"{n},{e},{d}";
        }

        public string Encrypt(string text, string key)
        {
            var parts = key.Split(',');

            int n = int.Parse(parts[0]);
            int e = int.Parse(parts[1]);

            StringBuilder sb = new StringBuilder();

            foreach (char c in text)
            {
                BigInteger m = c;
                BigInteger encrypted = BigInteger.ModPow(m, e, n);
                sb.Append(encrypted).Append(",");
            }

            return sb.ToString().TrimEnd(',');
        }

        public string Decrypt(string text, string key)
        {
            var parts = key.Split(',');

            int n = int.Parse(parts[0]);
            int d = int.Parse(parts[2]);

            StringBuilder sb = new StringBuilder();
            var blocks = text.Split(',');

            foreach (var b in blocks)
            {
                if (string.IsNullOrWhiteSpace(b)) continue;
                BigInteger c = BigInteger.Parse(b);
                BigInteger decrypted = BigInteger.ModPow(c, d, n);
                sb.Append((char)(int)decrypted);
            }

            return sb.ToString();
        }
    }
}