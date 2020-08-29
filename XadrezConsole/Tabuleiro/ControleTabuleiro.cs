namespace Tabuleiro
{
    class ControleTabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        public Peca[,] Pecas;

        public ControleTabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }
        public Peca PecaControle(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }
        public Peca PecaControle(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }
        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePecaNaPosicao(pos))
            {
                throw new TabuleiroException("Já existe peça nesta posição!");
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.PosicaoDaPeca = pos;
        }
        public Peca RetirarPeca(Posicao pos)
        {
            if (PecaControle(pos)==null)
            {
                return null;
            }
            Peca retirada = PecaControle(pos);
            retirada.PosicaoDaPeca = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return retirada;
        }
        public bool ExistePecaNaPosicao(Posicao pos)
        {
            ValidaPosicao(pos);
            return PecaControle(pos) != null;
        }
        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
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
