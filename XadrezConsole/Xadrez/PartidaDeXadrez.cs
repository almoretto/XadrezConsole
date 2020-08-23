using Tabuleiro;
using System.Collections.Generic;
using System;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public ControleTabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor CorJogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        public bool Xeque { get; private set; }

        private HashSet<Peca> PecasDaPartida;
        private HashSet<Peca> PecasCapturadas;


        public PartidaDeXadrez()
        {
            Tabuleiro = new ControleTabuleiro(8, 8);
            Turno = 1;
            CorJogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            PecasDaPartida = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            ColocarPecas();
        }
        public Peca EfetuaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                PecasCapturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }
        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tabuleiro.RetirarPeca(destino);
            p.DecrementarQteMovimentos();
            if (pecaCapturada!=null)
            {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                PecasCapturadas.Remove(pecaCapturada);
            }
            Tabuleiro.ColocarPeca(p, origem);
        }
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = EfetuaMovimento(origem, destino);
            if (EstaEmCheck(CorJogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em Xeque");
            }
            if (EstaEmCheck(CorAdversaria(CorJogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
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
                if (p.CorDaPeca == cor)
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
        private Cor CorAdversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }
        private Peca RetornaRei(Cor cor)
        {
            foreach (Peca p in PecasDaPartida)
            {
                if (p is Rei)
                {
                    return p;
                }
            }
            return null;
        }
        public bool EstaEmCheck(Cor cor)
        {
            Peca rei = RetornaRei(cor);
            if (rei == null)
            {
                throw new TabuleiroException("Cadê o rei da cor " + cor + "?");
            }
            foreach (Peca p in PecasEmJogo(CorAdversaria(cor)))
            {
                bool[,] checkMatrix = p.MovimentosPossiveis();
                if (checkMatrix[rei.PosicaoDaPeca.Linha,rei.PosicaoDaPeca.Coluna])
                {
                    return true;
                }
            }
            return false;
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
