using System;
using Tabuleiro;
using Xadrez;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoOrigem(origem);

                        bool[,] movimentosPossiveis = partida.Tabuleiro.PecaControle(origem).MovimentosPossiveis();
                        Console.Clear();
                        Tela.ImprimeTabuleiro(partida.Tabuleiro, movimentosPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidaPosicaoDestino(origem, destino);

                        partida.EfetuaMovimento(origem, destino);

                    }
                    catch (TabuleiroException jogadaException)
                    {
                        Console.WriteLine(jogadaException.Message);
                        Console.WriteLine("Pressione qualquer tecla para tentar novamente.");
                        Console.ReadLine();
                    }
                   
                }

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
