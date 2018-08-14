using System.Collections.Generic;

namespace Core.Blocks
{
    public static class Models
    {
        private static readonly int[][] firstBlock =
            {
                new[] { 1, 0, 0 },
                new[] { 1, 1, 1 }
            };

        private static readonly int[][] secondBlock =
            {
                new[] { 0, 0, 0, 0 },
                new[] { 1, 1, 1, 1 }
            };

        private static readonly int[][] thirdBlock =
            {
                new[] { 0, 0, 1 },
                new[] { 1, 1, 1 }
            };

        private static readonly int[][] fourthBlock =
            {
                new[] { 1, 1 },
                new[] { 1, 1 }

            };

        private static readonly int[][] fifthBlock =
            {
                new[] { 0, 1, 1 },
                new[] { 1, 1, 0 }
            };

        private static readonly int[][] sixthBlock =
            {
                new[] { 0, 1, 0 },
                new[] { 1, 1, 1 }
            };

        private static readonly int[][] seventhBlock =
            {
                new[] { 1, 1, 0 },
                new[] { 0, 1, 1 }
            };

        public static int[][] FirstBlock
        {
            get
            {
                return firstBlock;
            }
        }

        public static int[][] SecondBlock
        {
            get
            {
                return secondBlock;
            }
        }

        public static int[][] ThirdBlock
        {
            get
            {
                return thirdBlock;
            }
        }

        public static int[][] FourthBlock
        {
            get
            {
                return fourthBlock;
            }
        }

        public static int[][] FifthBlock
        {
            get
            {
                return fifthBlock;
            }
        }

        public static int[][] SixthBlock
        {
            get
            {
                return sixthBlock;
            }
        }

        public static int[][] SeventhBlock
        {
            get
            {
                return seventhBlock;
            }
        }

        public static List<int[][]> AllBlocks
        {
            get
            {
                return new List<int[][]>() { FirstBlock, SecondBlock, ThirdBlock, FourthBlock, FifthBlock, SixthBlock, SeventhBlock };
            }
        }
    }
}
