using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescryptLevel1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the encrypted string:");
            string encryptedString = Console.ReadLine();

            Console.WriteLine(Decrypt(encryptedString));

            Console.ReadLine();
        }

        private static string Decrypt(string encryptedString)
        {
            var size  = encryptedString.Length;
            var splitPosition = size / 2;
            if (size % 2 == 1)
            {
                splitPosition += 1;
            }

            var i = 0;
            var j = splitPosition;
            string decryptedString = string.Empty;
            while (i < splitPosition)
            {
                decryptedString += encryptedString[i];

                // check in case the second half is shorter than the first half
                // to avoid index out of bound exception
                if (j < size)
                {
                    decryptedString += encryptedString[j];
                }

                i++;
                j++;
            }

            return decryptedString;
        }
    }
}
