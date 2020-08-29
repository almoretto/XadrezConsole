using Tabuleiro;

namespace Xadrez
{
    class Bispo : Peca
    {
        public Bispo(Cor cor, ControleTabuleiro tab) : base(cor, tab) { }
        public override string ToString()
        {
            return "B";
        }
        private bool VerificaMovimentodaPeca(Posicao pos)
        {
            Peca p = TabuleiroDaPeca.PecaControle(pos);
            return p == null || p.CorDaPeca != this.CorDaPeca;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = new bool[TabuleiroDaPeca.Linhas, TabuleiroDaPeca.Colunas];
            Posicao posB = new Posicao(0, 0);
            //Diagonal Esquerda Acima
            posB.DefinirValores(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna - 1);
            while (TabuleiroDaPeca.PosicaoValida(posB) && VerificaMovimentodaPeca(posB))
            {
                movimentosPossiveis[posB.Linha, posB.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(posB) != null 
                    && TabuleiroDaPeca.PecaControle(posB).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                posB.DefinirValores(posB.Linha - 1, posB.Coluna - 1);
            }
            //Diagonal Direita Acima
            posB.DefinirValores(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna + 1);
            while (TabuleiroDaPeca.PosicaoValida(posB) && VerificaMovimentodaPeca(posB))
            {
                movimentosPossiveis[posB.Linha, posB.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(posB) != null
                    && TabuleiroDaPeca.PecaControle(posB).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                posB.DefinirValores(posB.Linha - 1, posB.Coluna + 1);
            }
            //Diagonal Direita Abaixo
            posB.DefinirValores(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna + 1);
            while (TabuleiroDaPeca.PosicaoValida(posB) && VerificaMovimentodaPeca(posB))
            {
                movimentosPossiveis[posB.Linha, posB.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(posB) != null
                    && TabuleiroDaPeca.PecaControle(posB).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                posB.DefinirValores(posB.Linha + 1, posB.Coluna + 1);
            }
            //Diagonal Esquerda Abaixo
            posB.DefinirValores(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna - 1);
            while (TabuleiroDaPeca.PosicaoValida(posB) && VerificaMovimentodaPeca(posB))
            {
                movimentosPossiveis[posB.Linha, posB.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(posB) != null
                    && TabuleiroDaPeca.PecaControle(posB).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                posB.DefinirValores(posB.Linha + 1, posB.Coluna - 1);
            }

            return movimentosPossiveis;
        }
    }
}
