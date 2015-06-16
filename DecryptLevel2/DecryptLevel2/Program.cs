using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecryptLevel2
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

            // create a list that contains all the empty positions (initialy all are included)
            var emptyPositions = new List<int>();
            var i = 0;
            while (i < size)
            {
                emptyPositions.Add(i);
                i++;
            }

            // create an empty string (all spaces)
            char[] decryptedString = new char[size];
            BuildDecryptedString(
                encryptedString,
                decryptedString,
                emptyPositions);

            return new string(decryptedString);
        }

        private static void BuildDecryptedString(
            string encryptedString,
            char[] decryptedString,
            List<int> emptyPositions)
        {
            var size = encryptedString.Length;
            var splitPosition = size / 2;
            if (size % 2 == 1)
            {
                splitPosition += 1;
            }

            // process first half of the string by assigning the values on the impar positions
            var i = 0;
            while (i < splitPosition)
            {
                decryptedString[emptyPositions[i]] = encryptedString[i];
                emptyPositions.RemoveAt(i);

                i += 1;
            }

            encryptedString = encryptedString.Substring(splitPosition);
            if (!string.IsNullOrEmpty(encryptedString))
            {
                BuildDecryptedString(
                    encryptedString,
                    decryptedString,
                    emptyPositions);
            }
        }
    }
}
