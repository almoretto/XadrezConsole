using Tabuleiro;
using System;

namespace XadrezConsole
{
    class Tela
    {
        public static void ImprimeTabuleiro(Tabuleiro.Tabuleiro tab)
        {
            Console.WriteLine();
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + "");
                for (int j = 0; j < tab.Colunas; j++)
                {

                    if (tab.PecaPosicao(i, j) == null)
                    {
                        Console.Write("- ");

                    }
                    else
                    {
                        PrintPiece(tab.PecaPosicao(i, j));
                        Console.Write(" ");
                        //Console.Write(board.PiecePut(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(" A B C D E F G H ");
        }
        public static void PrintPiece(Peca piece)
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
