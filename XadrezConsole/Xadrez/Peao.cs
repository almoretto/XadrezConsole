﻿using Tabuleiro;

namespace Xadrez
{
    class Peao : Peca
    {
        public Peao(Cor cor, Tabuleiro.Tabuleiro tab) : base(cor, tab) { }
        public override string ToString()
        {
            return "P";
        }
    }
}