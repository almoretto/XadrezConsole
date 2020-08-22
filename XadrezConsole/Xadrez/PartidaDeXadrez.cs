using Tabuleiro;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public ControleTabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public  Cor CorJogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new ControleTabuleiro(8, 8);
            Turno = 1;
            CorJogadorAtual = Cor.Branca;
            Terminada = false;
            ColocarPecas();
        }
        public void EfetuaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);
        }
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            EfetuaMovimento(origem, destino);
            Turno++;
            AlteraJogador();
        }
        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (Tabuleiro.PecaControle(pos)==null)
            {
                throw new TabuleiroException("Não pode mover um espaço vazio!");
            }
            if (CorJogadorAtual!= Tabuleiro.PecaControle(pos).CorDaPeca)
            {
                throw new TabuleiroException("A peça que está tentando mover não é sua!");
            }
            if (Tabuleiro.PecaControle(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existe movimentos possíveis");
            }
        }
        private void ColocarPecas()
        {

        }
        private void AlteraJogador()
        {
            if (CorJogadorAtual==Cor.Branca)
            {
                CorJogadorAtual = Cor.Preta;
            }
            else
            {
                CorJogadorAtual = Cor.Branca;
            }
        }
    }
}
