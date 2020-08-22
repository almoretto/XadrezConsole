using Tabuleiro;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public ControleTabuleiro Tabuleiro { get; private set; }
        private int Turno;
        private Cor JogadorAtual;

        public PartidaDeXadrez()
        {
            Tabuleiro = new ControleTabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
        }
        public void EfetuaJogada(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);
        }
        private void ColocarPecas()
        {

        }
    }
}
