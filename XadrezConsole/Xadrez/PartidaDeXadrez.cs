using Tabuleiro;
using System.Collections.Generic;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public ControleTabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor CorJogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        private HashSet<Peca> PecasDaPartida;
        private HashSet<Peca> PecasCapturadas;


        public PartidaDeXadrez()
        {
            Tabuleiro = new ControleTabuleiro(8, 8);
            Turno = 1;
            CorJogadorAtual = Cor.Branca;
            Terminada = false;
            PecasDaPartida = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            ColocarPecas();
        }
        public void EfetuaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);
            if (pecaCapturada!=null)
            {
                PecasCapturadas.Add(pecaCapturada);
            }
        }
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            EfetuaMovimento(origem, destino);
            Turno++;
            AlteraJogador();
        }
        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (Tabuleiro.PecaControle(pos) == null)
            {
                throw new TabuleiroException("Não pode mover um espaço vazio!");
            }
            if (CorJogadorAtual != Tabuleiro.PecaControle(pos).CorDaPeca)
            {
                throw new TabuleiroException("A peça que está tentando mover não é sua!");
            }
            if (Tabuleiro.PecaControle(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existe movimentos possíveis");
            }
        }
        public void ValidaPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.PecaControle(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }
        public HashSet<Peca> PecasCapturadasPorCor(Cor cor)
        {
            HashSet<Peca> porCor = new HashSet<Peca>();
            foreach (Peca p in PecasCapturadas)
            {
                if (p.CorDaPeca==cor)
                {
                    porCor.Add(p);
                }
            }
            return porCor;
        }
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> porCor = new HashSet<Peca>();
            foreach (Peca p in PecasCapturadas)
            {
                if (p.CorDaPeca == cor)
                {
                    porCor.Add(p);
                }
            }
            porCor.ExceptWith(PecasCapturadasPorCor(cor));
            return porCor;
        }
        public void ColocarNovaPeca(char coluna, int linha, Peca p)
        {
            Tabuleiro.ColocarPeca(p, new PosicaoXadrez(coluna, linha).ToPosicao());
            PecasDaPartida.Add(p);
        }
        private void ColocarPecas()
        {

        }
        private void AlteraJogador()
        {
            if (CorJogadorAtual == Cor.Branca)
            {
                CorJogadorAtual = Cor.Preta;
            }
            else
            {
                CorJogadorAtual = Cor.Branca;
            }
        }
    }
}
