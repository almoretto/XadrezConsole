using Tabuleiro;

namespace Xadrez
{
    class Rainha : Peca
    {
        public Rainha(Cor cor, ControleTabuleiro tab) : base(cor, tab) { }
        public override string ToString()
        {
            return "Q";
        }
        private bool VerificaMovimentodaPeca(Posicao pos)
        {
            Peca p = TabuleiroDaPeca.PecaControle(pos);
            return p == null || p.CorDaPeca != this.CorDaPeca;
        }
        public override bool[,] MovimentosPossiveis()
        {

            bool[,] movimentosPossiveis = new bool[TabuleiroDaPeca.Linhas, TabuleiroDaPeca.Colunas];
            Posicao posR = new Posicao(0, 0);
            //Acima
            posR.DefinirValores(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna);
            while (TabuleiroDaPeca.PosicaoValida(posR) && VerificaMovimentodaPeca(posR))
            {
                movimentosPossiveis[posR.Linha, posR.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(posR) != null
                    && TabuleiroDaPeca.PecaControle(posR).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                posR.Linha = posR.Linha - 1;
            }
            //Abaixo
            posR.DefinirValores(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna);
            while (TabuleiroDaPeca.PosicaoValida(posR) && VerificaMovimentodaPeca(posR))
            {
                movimentosPossiveis[posR.Linha, posR.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(posR) != null
                    && TabuleiroDaPeca.PecaControle(posR).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                posR.Linha = posR.Linha + 1;
            }
            //Direita
            posR.DefinirValores(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna + 1);
            while (TabuleiroDaPeca.PosicaoValida(posR) && VerificaMovimentodaPeca(posR))
            {
                movimentosPossiveis[posR.Linha, posR.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(posR) != null
                    && TabuleiroDaPeca.PecaControle(posR).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                posR.Coluna = posR.Coluna + 1;
            }
            //Esquerda
            posR.DefinirValores(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna - 1);
            while (TabuleiroDaPeca.PosicaoValida(posR) && VerificaMovimentodaPeca(posR))
            {
                movimentosPossiveis[posR.Linha, posR.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(posR) != null
                    && TabuleiroDaPeca.PecaControle(posR).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                posR.Coluna = posR.Coluna - 1;
            }
            //Diagonal Esquerda Acima
            posR.DefinirValores(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna - 1);
            while (TabuleiroDaPeca.PosicaoValida(posR) && VerificaMovimentodaPeca(posR))
            {
                movimentosPossiveis[posR.Linha, posR.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(posR) != null
                    && TabuleiroDaPeca.PecaControle(posR).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                posR.DefinirValores(posR.Linha - 1, posR.Coluna - 1);
            }
            //Diagonal Direita Acima
            posR.DefinirValores(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna + 1);
            while (TabuleiroDaPeca.PosicaoValida(posR) && VerificaMovimentodaPeca(posR))
            {
                movimentosPossiveis[posR.Linha, posR.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(posR) != null
                    && TabuleiroDaPeca.PecaControle(posR).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                posR.DefinirValores(posR.Linha - 1, posR.Coluna + 1);
            }
            //Diagonal Direita Abaixo
            posR.DefinirValores(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna + 1);
            while (TabuleiroDaPeca.PosicaoValida(posR) && VerificaMovimentodaPeca(posR))
            {
                movimentosPossiveis[posR.Linha, posR.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(posR) != null
                    && TabuleiroDaPeca.PecaControle(posR).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                posR.DefinirValores(posR.Linha + 1, posR.Coluna + 1);
            }
            //Diagonal Esquerda Abaixo
            posR.DefinirValores(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna - 1);
            while (TabuleiroDaPeca.PosicaoValida(posR) && VerificaMovimentodaPeca(posR))
            {
                movimentosPossiveis[posR.Linha, posR.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(posR) != null
                    && TabuleiroDaPeca.PecaControle(posR).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                posR.DefinirValores(posR.Linha + 1, posR.Coluna - 1);
            }

            return movimentosPossiveis;
        }
    }
}
