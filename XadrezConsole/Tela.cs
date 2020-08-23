using Tabuleiro;
using Xadrez;
using System;
using System.Collections.Generic;

namespace XadrezConsole
{
    class Tela
    {
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimeTabuleiro(partida.Tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine();
            if (!partida.Terminada)
            {
                Console.WriteLine("Jogador Atual: " + partida.CorJogadorAtual);
                Console.WriteLine();
                if (partida.Xeque)
                {
                    Console.WriteLine("--== Xeque! ==--");
                }
            }
            else
            {
                Console.WriteLine("---=== Xeque Mate! ===---");
                Console.WriteLine("Vencedor: "+partida.CorJogadorAtual);
            }
           
        }
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
        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("--== Peças Capturadas ==--");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadasPorCor(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            ImprimirConjunto(partida.PecasCapturadasPorCor(Cor.Preta));
            Console.ForegroundColor = c;
            Console.WriteLine("--== ==--");
            

        } 
        public static void ImprimirConjunto(HashSet<Peca> pecas)
        {
            Console.Write("[");
            foreach (Peca p in pecas)
            {
                Console.Write(p+", ");
            }
            Console.WriteLine("]");
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
