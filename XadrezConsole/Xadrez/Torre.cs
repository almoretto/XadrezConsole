using Tabuleiro;

namespace Xadrez
{
    class Torre : Peca
    {
        public Torre(Cor cor, ControleTabuleiro tab) : base(cor, tab) { }
        public override string ToString()
        {
            return "T";
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
            //Acima
            pos.DefinirValores(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna);
            while (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentodaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(pos) != null
                    && TabuleiroDaPeca.PecaControle(pos).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }
            //Abaixo
            pos.DefinirValores(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna);
            while (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentodaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(pos) != null
                    && TabuleiroDaPeca.PecaControle(pos).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }
            //Direita
            pos.DefinirValores(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna + 1);
            while (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentodaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(pos) != null
                    && TabuleiroDaPeca.PecaControle(pos).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }
            //Esquerda
            pos.DefinirValores(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna - 1);
            while (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentodaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(pos) != null
                    && TabuleiroDaPeca.PecaControle(pos).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            return movimentosPossiveis;
        }
    }
}
