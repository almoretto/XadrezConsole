namespace Tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        public Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }
        public Peca PecaPosicao(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }
        public Peca PecaPosicao(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }
        public void ColocarPeca(Peca p, Posicao pos)
        {
            Pecas[pos.Linha, pos.Coluna] = p;
            p.PosicaoDaPeca = pos;
        }
        public bool ExistePecaNaPosicao(Posicao pos)
        {
            ValidaPosicao(pos);
            return PecaPosicao(pos) != null;
        }
        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha > Linhas || pos.Coluna < 0 || pos.Coluna > Colunas)
            {
                return false;
            }
            return true;
        }
        public void ValidaPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição Inválida!");
            }
        }
    }
}
