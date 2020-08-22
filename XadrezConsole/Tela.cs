using Tabuleiro;
using Xadrez;
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
                    ImprimePecaNaTela(tab.PecaControle(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H ");
        }
        public static void ImprimeTabuleiro(ControleTabuleiro tab, bool[,] possicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoMovimentos = ConsoleColor.DarkGray;

            Console.WriteLine();
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (possicoesPossiveis[i,j])
                    {
                        Console.BackgroundColor = fundoMovimentos;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimePecaNaTela(tab.PecaControle(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H ");
            Console.BackgroundColor = fundoOriginal;
        }
        public static void ImprimePecaNaTela(Peca piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
    }
}
