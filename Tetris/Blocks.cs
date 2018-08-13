namespace Tetris
{
    public class Blocks
    {
        private readonly int[][] firstBlock =
            {
                new[] { 1, 0, 0 },
                new[] { 1, 1, 1 }
            };

        public int[][] FirstBlock
        {
            get
            {
                return this.firstBlock;
            }
        }
    }
}
