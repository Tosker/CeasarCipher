using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A - Cipher");
            Console.WriteLine("B - Decipher");
            var keyPress = Console.ReadKey(true).Key;
            int offset = 0;
            Console.Write("Enter the offset: ");
            var validOffset = int.TryParse(Console.ReadLine(), out offset);

            if(validOffset)
            {
                if (keyPress == ConsoleKey.A)
                {
                    Console.Write("Message to cipher: ");
                    string message = Console.ReadLine();
                    Ceaser(offset, message, false);
                    Console.ReadLine();
                }

                if (keyPress == ConsoleKey.B)
                {
                    Console.Write("Message to decipher: ");
                    string message2 = Console.ReadLine();
                    Ceaser(offset, message2, true);
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid offset!");
                Console.ReadLine();
                Main(null);
            }

            Console.Clear();
            Main(null);
        }

        public static void Ceaser(int offset, string message, bool dechipher)
        {
            var lowerMessage = message.ToLower();
            var characters = lowerMessage.ToCharArray();
            string newMessage = "";

            foreach (char c in characters)
            {
                var asciiKey = (int)c;
                int newKey;

                if (c == ' ')
                {
                    newMessage += c.ToString();
                    continue;
                }

                if (dechipher)
                    newKey = CheckMin(asciiKey - offset);
                else
                    newKey = CheckMax(asciiKey + offset);

                newMessage += (char)newKey;
            }

            Console.WriteLine(String.Format("Output is: {0}", newMessage));
        }

        public static int CheckMax(int asciiValue)
        {
            while(asciiValue > 122)
            {
                asciiValue -= 122;
                asciiValue += 97;
            }
            return asciiValue;
        }

        public static int CheckMin(int asciiValue)
        {
            while (asciiValue < 97)
            {
                asciiValue -= 97;
                asciiValue += 122;
            }
            return asciiValue;
        }
    }
}
