using Tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez PartidaDoRei { get; set; }
        public Rei(Cor cor, ControleTabuleiro tab, PartidaDeXadrez partida) : base(cor, tab)
        {
            PartidaDoRei = partida;
        }
        public override string ToString()
        {
            return "K";
        }
        private bool VerificaMovimentoDaPeca(Posicao pos)
        {
            Peca p = TabuleiroDaPeca.PecaControle(pos);
            return p == null || p.CorDaPeca != this.CorDaPeca;
        }
        private bool VerificaTorreParaRoque(Posicao pos)
        {
            Peca p = TabuleiroDaPeca.PecaControle(pos);
            return p != null && p is Torre && p.CorDaPeca == this.CorDaPeca && p.QteMovimentos == 0;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] movimentosPossiveis = new bool[TabuleiroDaPeca.Linhas, TabuleiroDaPeca.Colunas];
            Posicao pos = new Posicao(0, 0);
            //Acima
            pos.DefinirValores(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentoDaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            //DiagonalDireitaAcima
            pos.DefinirValores(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna + 1);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentoDaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            //Direita
            pos.DefinirValores(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna + 1);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentoDaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            //DiagonalDireitaAbaixo
            pos.DefinirValores(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna + 1);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentoDaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            //Abaixo
            pos.DefinirValores(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentoDaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            //DiagonalEsquerdaAbaixo
            pos.DefinirValores(PosicaoDaPeca.Linha + 1, PosicaoDaPeca.Coluna - 1);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentoDaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            //Esquerda
            pos.DefinirValores(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna - 1);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentoDaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            //DiagonalEsquerdaAcima
            pos.DefinirValores(PosicaoDaPeca.Linha - 1, PosicaoDaPeca.Coluna - 1);
            if (TabuleiroDaPeca.PosicaoValida(pos) && VerificaMovimentoDaPeca(pos))
            {
                movimentosPossiveis[pos.Linha, pos.Coluna] = true;
            }
            //#JogadaEspecial Roque 
            if (QteMovimentos == 0 && PartidaDoRei.Xeque)
            {
                //#JogadaEspecial Roque Pequeno
                Posicao torreRoquePequeno = new Posicao(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna + 3);
                if (VerificaTorreParaRoque(torreRoquePequeno))
                {
                    Posicao p1 = new Posicao(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna + 1);
                    Posicao p2 = new Posicao(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna + 2);
                    if ((TabuleiroDaPeca.PecaControle(p1) == null) && (TabuleiroDaPeca.PecaControle(p2) == null))
                    {
                        movimentosPossiveis[PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna + 2] = true;
                    }

                }
                //#JogadaEspecial Roque Grande
                Posicao torreRoqueGrande = new Posicao(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna - 4);
                if (VerificaTorreParaRoque(torreRoqueGrande))
                {
                    Posicao p1 = new Posicao(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna - 1);
                    Posicao p2 = new Posicao(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna - 2);
                    Posicao p3 = new Posicao(PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna - 3);

                    if ((TabuleiroDaPeca.PecaControle(p1) == null)
                        && (TabuleiroDaPeca.PecaControle(p2) == null)
                        && (TabuleiroDaPeca.PecaControle(p3) == null))
                    {
                        movimentosPossiveis[PosicaoDaPeca.Linha, PosicaoDaPeca.Coluna - 2] = true;
                    }

                }
            }
            return movimentosPossiveis;
        }
    }
}
