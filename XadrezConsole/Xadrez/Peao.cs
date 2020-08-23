using System.Runtime.InteropServices.WindowsRuntime;
using Tabuleiro;

namespace Xadrez
{
    class Peao : Peca
    {
        public Peao(Cor cor, ControleTabuleiro tab) : base(cor, tab) { }
        public override string ToString()
        {
            return "P";
        }
        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = TabuleiroDaPeca.PecaControle(pos);
            return p == null || p.CorDaPeca != this.CorDaPeca;
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
            }

            return movimentosPossiveis;
        }
    }
}
