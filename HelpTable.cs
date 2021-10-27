using ConsoleTables;

namespace stonepaper
{
    class HelpTable
    {
        internal static void Show(string[] args)
        {
            var table = new ConsoleTable("User\\PC");
           
            table.AddColumn(args);
           
            for (int i = 0; i < args.Length; i++)
            {
                string[] w = new string[args.Length+1];

                w[0] = args[i];
                for (int j = 1; j < args.Length+1; j++)
                {
                   w[j]=Winner.Show(args, i, j-1);
                }
                table.AddRow(w);
            }
            table.Write(Format.Alternative);
        }
    }
}
