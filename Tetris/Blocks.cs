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

        private readonly int[][] secondBlock =
            {
                new[] { 0, 0, 0, 0 },
                new[] { 1, 1, 1, 1 }
            };

        public int[][] SecondBlock
        {
            get
            {
                return this.secondBlock;
            }
        }

        private readonly int[][] thirdBlock =
            {
                new[] { 0, 0, 1 },
                new[] { 1, 1, 1 }
            };

        public int[][] ThirdBlock
        {
            get
            {
                return this.thirdBlock;
            }
        }

        private readonly int[][] fourthBlock =
            {
                new[] { 1, 1 },
                new[] { 1, 1 }
            };

        public int[][] FourthBlock
        {
            get
            {
                return this.fourthBlock;
            }
        }

        private readonly int[][] fifthBlock =
            {
                new[] { 0, 1, 1 },
                new[] { 1, 1, 0 }
            };

        public int[][] FifthBlock
        {
            get
            {
                return this.fifthBlock;
            }
        }

        private readonly int[][] sixthBlock =
            {
                new[] { 0, 1, 0 },
                new[] { 1, 1, 1 }
            };

        public int[][] SixthBlock
        {
            get
            {
                return this.sixthBlock;
            }
        }

        private readonly int[][] seventhBlock =
            {
                new[] { 1, 1, 0 },
                new[] { 0, 1, 1 }
            };

        public int[][] SeventhBlock
        {
            get
            {
                return this.seventhBlock;
            }
        }
    }
}
