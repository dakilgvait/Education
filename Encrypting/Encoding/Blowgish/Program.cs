using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elskom.Generic.Libs;
//using System.Security.Cryptography;

namespace ConsoleApplication26
{
    class Program
    {
        static string data = "myPassword";

        public byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8 };
        static void Main(string[] args)
        {
            
            byte[] bytesdata = Encoding.ASCII.GetBytes(data);
            Program test = new Program();
            byte[] enc = test.Encrypt(bytesdata);
            
            foreach (byte i in enc)
            {
                Console.WriteLine(i);
            }

            byte [] dec = test.Decrypt(enc);

            foreach (byte i in dec)
            {
                Console.WriteLine(i);
            }

            string someString = Encoding.ASCII.GetString(dec);
            Console.WriteLine(someString);
            Console.ReadKey();
        }
        private byte[] Encrypt(byte[] data)
        {
            string kh = "0000011100fa00010034ba2145000032";
            BlowFish bfc = new BlowFish(kh);
            //this.IV = bfc.SetRandomIV();
            byte [] IV = this.IV;
            bfc.IV = IV;
         
            return bfc.EncryptCBC(data);
        }
        private byte[] Decrypt(byte[] data)
        {
            
            string kh = "0000011100fa00010034ba2145000032";
            BlowFish bfd=new BlowFish (kh);
            bfd.IV = this.IV;
            
            return bfd.DecryptCBC(data);
         
        }
    }
}
