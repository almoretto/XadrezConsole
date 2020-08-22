using System;
using Tabuleiro;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ControleTabuleiro tab = new ControleTabuleiro(8, 8);
            Tela.ImprimeTabuleiro(tab);
            Console.ReadKey();
        }
    }
}
