using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zufallstextgenerator
{
    class Program
    {
        static void consoleDesign()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
        }
        static int inputInt()
        {
            String input;
            bool valid = false;
            int toReturn = 0;
            while (!valid)
            {
                input = Console.ReadLine();
                valid = true;
                try
                {
                    toReturn = int.Parse(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Keine gültige Zahl!");
                    valid = false;
                }
            }
            return toReturn;
        }
        static String generateText(int keylength)
        {
            int n;
            String password = "";
            Random random = new Random();
            for (int i = 0; i < keylength; i++)
            {
                n = random.Next(97, 124);
                if (n == 123 || i % 7 == 0 && i > 4) n = 32;
                password += (char)n;
            }
            Console.WriteLine(password);
            return password;
        }
        static void createText()
        {
            Console.WriteLine("Wie viele Zeichen soll der Text lang werden!");
            int keylength = inputInt();
            Console.WriteLine("Text:\n");
            Clipboard.SetText(generateText(keylength));
            Console.WriteLine("\nDer Text wurde in die Zwischenablage kopiert!");
        }

        [STAThreadAttribute]
        static void Main(string[] args)
        {
            consoleDesign();
            Console.WriteLine("Willkommen zum Zufallstextgenerator");
            createText();
            Console.Write("Beliebige Taste zum Beenden drücken!");
            Console.ReadKey();
        }
    }
}
