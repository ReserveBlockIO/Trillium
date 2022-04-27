// See https://aka.ms/new-console-template for more information
namespace Trillium
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e)
            {
                Console.WriteLine();
                Console.WriteLine("Goodbye! ¡Adiós! Ciao! Adieu! Adeus! Tschüss! Пока! 再见 さようなら הֱיה שלום وداعا");
            };

            ClearLine();

            var argList = args.ToList();
            if(argList.Any())
            {
                argList.ForEach(x => {
                    var arg = x.ToLower();
                });
            }
        }

        private static void ClearLine(string part1 = "", string part2 = "")
        {
            string spaces = new string(' ', part1.Length + part2.Length + 1);
            Console.Write("\r{0}\r", spaces);
        }

        private static void SetCursor(string prompt, string line, int pos)
        {
            ClearLine(prompt, line);
            Console.Write("{0}{1}\r{2}{3}",
              prompt, line, prompt, line.Substring(0, pos));
        }

    }
}