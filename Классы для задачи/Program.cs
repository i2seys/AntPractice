namespace IT_WORKS
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Play(
                 daysTillDry: 12,
                 colonies: HelpFunctions.GetListOfQueenAntColonies(),
                 heaps: HelpFunctions.HeapsInit()
                 );
        }
    }
}
