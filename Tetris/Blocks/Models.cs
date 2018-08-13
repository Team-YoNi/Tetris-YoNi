namespace Tetris
{
    public class Models
    {
        private readonly int[][] firstBlock =
            {
                new[] { 1, 0, 0 },
                new[] { 1, 1, 1 }
            };

        private readonly int[][] secondBlock =
            {
                new[] { 0, 0, 0, 0 },
                new[] { 1, 1, 1, 1 }
            };

        private readonly int[][] thirdBlock =
            {
                new[] { 0, 0, 1 },
                new[] { 1, 1, 1 }
            };

        private readonly int[][] fourthBlock =
            {
                new[] { 1, 1 },
                new[] { 1, 1 }
            };

        private readonly int[][] fifthBlock =
            {
                new[] { 0, 1, 1 },
                new[] { 1, 1, 0 }
            };

        private readonly int[][] sixthBlock =
            {
                new[] { 0, 1, 0 },
                new[] { 1, 1, 1 }
            };

        private readonly int[][] seventhBlock =
            {
                new[] { 1, 1, 0 },
                new[] { 0, 1, 1 }
            };

        public int[][] FirstBlock
        {
            get
            {
                return this.firstBlock;
            }
        }


        public int[][] SecondBlock
        {
            get
            {
                return this.secondBlock;
            }
        }


        public int[][] ThirdBlock
        {
            get
            {
                return this.thirdBlock;
            }
        }

        public int[][] FourthBlock
        {
            get
            {
                return this.fourthBlock;
            }
        }

        public int[][] FifthBlock
        {
            get
            {
                return this.fifthBlock;
            }
        }

        public int[][] SixthBlock
        {
            get
            {
                return this.sixthBlock;
            }
        }

        public int[][] SeventhBlock
        {
            get
            {
                return this.seventhBlock;
            }
        }
    }
}
