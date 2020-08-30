using Tabuleiro;

namespace Xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez Partida;
        public Peao(Cor cor, ControleTabuleiro tab, PartidaDeXadrez partida) : base(cor, tab)
        {
            Partida = partida;
        }
        public override string ToString()
        {
            return "P";
        }
        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = TabuleiroDaPeca.PecaControle(pos);
            return p != null && p.CorDaPeca != this.CorDaPeca;
        }
        private bool PosicaoLivre(Posicao pos)
        {
            return TabuleiroDaPeca.PecaControle(pos) == null;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = new bool[TabuleiroDaPeca.Linhas, TabuleiroDaPeca.Colunas];
            Posicao pos = new Posicao(0, 0);

            if (CorDaPeca == Cor.Branca)
            {
                pos.DefinirValores(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna);
                if (TabuleiroDaPeca.PosicaoValida(pos) && PosicaoLivre(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(PosicaoDaPeca.Linha - 2, PosicaoDaPeca.Coluna);
                if (TabuleiroDaPeca.PosicaoValida(pos) && PosicaoLivre(pos) && QteMovimentos == 0)
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna - 1);
                if (TabuleiroDaPeca.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna + 1);
                if (TabuleiroDaPeca.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                if (PosicaoDaPeca.Linha == 3)
                {
                    Posicao esquerda = new Posicao(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna - 1);
                    Posicao direita = new Posicao(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna + 1);
                    if (TabuleiroDaPeca.PosicaoValida(esquerda)
                        && ExisteInimigo(esquerda)
                        && TabuleiroDaPeca.PecaControle(esquerda) == Partida.VulneravelEnPassant)
                    {
                        movimentosPossiveis[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    if (TabuleiroDaPeca.PosicaoValida(direita)
                       && ExisteInimigo(direita)
                       && TabuleiroDaPeca.PecaControle(direita) == Partida.VulneravelEnPassant)
                    {
                        movimentosPossiveis[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
            }
            else //Pretas
            {
                pos.DefinirValores(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna);
                if (TabuleiroDaPeca.PosicaoValida(pos) && PosicaoLivre(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(PosicaoDaPeca.Linha + 2, PosicaoDaPeca.Coluna);
                if (TabuleiroDaPeca.PosicaoValida(pos) && PosicaoLivre(pos) && QteMovimentos == 0)
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna - 1);
                if (TabuleiroDaPeca.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna + 1);
                if (TabuleiroDaPeca.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                }
                if (PosicaoDaPeca.Linha == 4)
                {
                    Posicao esquerda = new Posicao(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna - 1);
                    Posicao direita = new Posicao(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna + 1);
                    if (TabuleiroDaPeca.PosicaoValida(esquerda)
                        && ExisteInimigo(esquerda)
                        && TabuleiroDaPeca.PecaControle(esquerda) == Partida.VulneravelEnPassant)
                    {
                        movimentosPossiveis[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                    if (TabuleiroDaPeca.PosicaoValida(direita)
                       && ExisteInimigo(direita)
                       && TabuleiroDaPeca.PecaControle(direita) == Partida.VulneravelEnPassant)
                    {
                        movimentosPossiveis[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return movimentosPossiveis;
        }
    }
}
