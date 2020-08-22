using Tabuleiro;
using System;

namespace XadrezConsole
{
    class Tela
    {
        public static void ImprimeTabuleiro(ControleTabuleiro tab)
        {
            Console.WriteLine();
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {

                    if (tab.PecaControle(i, j) == null)
                    {
                        Console.Write("- ");

                    }
                    else
                    {
                        ImprimePecaNaTela(tab.PecaControle(i, j));
                        Console.Write(" ");
                        //Console.Write(board.PiecePut(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H ");
        }
        public static void ImprimePecaNaTela(Peca piece)
        {
            if (piece.CorDaPeca == Cor.Branca)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor auxiliaryColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(piece);
                Console.ForegroundColor = auxiliaryColor;
            }
        }
    }
}
