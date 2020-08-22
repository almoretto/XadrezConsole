using Tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, ControleTabuleiro tab) : base(cor, tab) { }
        public override string ToString()
        {
            return "K";
        }
        private bool VerificaMovimento(Posicao pos)
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
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimento(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            //DiagonalDireitaAcima
            pos.DefinirValores(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna + 1);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimento(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            //Direita
            pos.DefinirValores(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna + 1);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimento(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            //DiagonalDireitaAbaixo
            pos.DefinirValores(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna + 1);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimento(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            //Abaixo
            pos.DefinirValores(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimento(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            //DiagonalEsquerdaAbaixo
            pos.DefinirValores(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna - 1);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimento(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            //Esquerda
            pos.DefinirValores(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna - 1);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimento(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            //DiagonalEsquerdaAcima
            pos.DefinirValores(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna - 1);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimento(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            return movimentosPossiveis;
        }
    }
}
