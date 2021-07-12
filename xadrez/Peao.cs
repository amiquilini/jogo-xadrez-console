using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = tab.Peca(pos);
            return p != null && p.cor != cor;
        }

        private bool Livre(Posicao pos)
        {
            return tab.Peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                pos.DefinirValores(posicao.linha - 1, posicao.coluna);
                if (tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.DefinirValores(posicao.linha - 2, posicao.coluna);
                Posicao p2 = new Posicao(posicao.linha - 1, posicao.coluna);
                if (tab.PosicaoValida(p2) && Livre(p2) && tab.PosicaoValida(pos) && Livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            else
            {
                pos.DefinirValores(posicao.linha + 1, posicao.coluna);
                if (tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.DefinirValores(posicao.linha + 2, posicao.coluna);
                Posicao p2 = new Posicao(posicao.linha + 1, posicao.coluna);
                if (tab.PosicaoValida(p2) && Livre(p2) && tab.PosicaoValida(pos) && Livre(pos) && qteMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }

            return mat;
        }
    }
}
