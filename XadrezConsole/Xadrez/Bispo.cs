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
            Posicao pos = new Posicao(0, 0);
            //Diagonal Esquerda Acima
            pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            while (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentodaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(pos) != null 
                    && TabuleiroDaPeca.PecaControle(pos).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }
            //Diagonal Direita Acima
            pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            while (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentodaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(pos) != null
                    && TabuleiroDaPeca.PecaControle(pos).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }
            //Diagonal Direita Abaixo
            pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            while (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentodaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(pos) != null
                    && TabuleiroDaPeca.PecaControle(pos).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }
            //Diagonal Esquerda Abaixo
            pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            while (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentodaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
                if (TabuleiroDaPeca.PecaControle(pos) != null
                    && TabuleiroDaPeca.PecaControle(pos).CorDaPeca != this.CorDaPeca)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            return movimentosPossiveis;
        }
    }
}
