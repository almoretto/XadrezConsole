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
            //#JogadaEspecial Roque Pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca torreRoque = Tabuleiro.RetirarPeca(origemTorre);
                torreRoque.IncrementarQteMovimentos();
                Tabuleiro.ColocarPeca(torreRoque, destinoTorre);

            }
            //#JogadaEspecial Roque Grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca torreRoque = Tabuleiro.RetirarPeca(origemTorre);
                torreRoque.IncrementarQteMovimentos();
                Tabuleiro.ColocarPeca(torreRoque, destinoTorre);

            }
            return pecaCapturada;
        }
        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tabuleiro.RetirarPeca(destino);
            p.DecrementarQteMovimentos();
            if (pecaCapturada != null)
            {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                PecasCapturadas.Remove(pecaCapturada);
            }
            Tabuleiro.ColocarPeca(p, origem);
            //#JogadaEspecial Roque Pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca torreRoque = Tabuleiro.RetirarPeca(destinoTorre);
                torreRoque.DecrementarQteMovimentos();
                Tabuleiro.ColocarPeca(torreRoque, origemTorre);

            }
            //#JogadaEspecial Roque Grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca torreRoque = Tabuleiro.RetirarPeca(destinoTorre);
                torreRoque.DecrementarQteMovimentos();
                Tabuleiro.ColocarPeca(torreRoque, origemTorre);

            }
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
            if (EstaEmCheckMate(CorAdversaria(CorJogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                AlteraJogador();
            }

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
            if (!Tabuleiro.PecaControle(pos).ExisteMovimentosPossiveis())
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
            foreach (Peca p in PecasDaPartida)
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
        private Peca RetornaRei(Cor cor)//verificado
        {
            foreach (Peca p in PecasEmJogo(cor))
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
                if (checkMatrix[rei.PosicaoDaPeca.Linha, rei.PosicaoDaPeca.Coluna])
                {
                    return true;
                }
            }
            return false;
        }
        public bool EstaEmCheckMate(Cor cor)
        {
            if (!EstaEmCheck(cor))
            {
                return false;
            }
            foreach (Peca p in PecasEmJogo(cor))
            {
                bool[,] movimentos = p.MovimentosPossiveis();
                for (int i = 0; i < Tabuleiro.Linhas; i++)
                {
                    for (int j = 0; j < Tabuleiro.Colunas; j++)
                    {
                        if (movimentos[i, j])
                        {
                            Posicao origem = p.PosicaoDaPeca;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaEmTeste = EfetuaMovimento(origem, destino);
                            bool testeCheck = EstaEmCheck(cor);
                            DesfazMovimento(origem, destino, pecaEmTeste);
                            if (!testeCheck)
                            {
                                return false;
                            }
                        }
                    }

                }
            }
            return true;
        }
        public void ColocarNovaPeca(char coluna, int linha, Peca p)
        {
            Tabuleiro.ColocarPeca(p, new PosicaoXadrez(coluna, linha).ToPosicao());
            PecasDaPartida.Add(p);
        }
        private void ColocarPecas()
        {
            //Peças Brancas
            ColocarNovaPeca('a', 1, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('h', 1, new Torre(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('b', 1, new Cavalo(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('g', 1, new Cavalo(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('c', 1, new Bispo(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('f', 1, new Bispo(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('e', 1, new Rei(Cor.Branca, Tabuleiro, this));
            ColocarNovaPeca('d', 1, new Rainha(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('a', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('b', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('c', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('d', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('e', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('f', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('g', 2, new Peao(Cor.Branca, Tabuleiro));
            ColocarNovaPeca('h', 2, new Peao(Cor.Branca, Tabuleiro));

            //Peças Pretas
            ColocarNovaPeca('a', 8, new Torre(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('h', 8, new Torre(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('b', 8, new Cavalo(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('g', 8, new Cavalo(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('c', 8, new Bispo(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('f', 8, new Bispo(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('e', 8, new Rei(Cor.Preta, Tabuleiro, this));
            ColocarNovaPeca('d', 8, new Rainha(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('a', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('b', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('c', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('d', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('e', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('f', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('g', 7, new Peao(Cor.Preta, Tabuleiro));
            ColocarNovaPeca('h', 7, new Peao(Cor.Preta, Tabuleiro));
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
