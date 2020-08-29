using Tabuleiro;

namespace Xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Cor cor, ControleTabuleiro tab) : base(cor, tab) { }
        public override string ToString()
        {
            return "C";
        }
        private bool VerificaMovimentodaPeca(Posicao pos)
        {
            Peca p = TabuleiroDaPeca.PecaControle(pos);
            return p == null || p.CorDaPeca != this.CorDaPeca;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = new bool[TabuleiroDaPeca.Linhas, TabuleiroDaPeca.Colunas];
            Posicao pos = new Posicao(0, 0);

            pos.DefinirValores(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna - 2);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentodaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(PosicaoDaPeca.Linha - 2, PosicaoDaPeca.Coluna - 1);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentodaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(PosicaoDaPeca.Linha - 2, PosicaoDaPeca.Coluna + 1);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentodaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna + 2);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentodaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna + 2);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentodaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(PosicaoDaPeca.Linha + 2, PosicaoDaPeca.Coluna + 1);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentodaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(PosicaoDaPeca.Linha + 2, PosicaoDaPeca.Coluna - 1);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentodaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna - 2);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentodaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }

            return movimentosPossiveis;
        }
    }
}
