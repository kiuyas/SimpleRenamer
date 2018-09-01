namespace SimpleRenamer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Renamer renamer = new Renamer();
                renamer.Execute(args[0]);
            }
        }
    }
}
