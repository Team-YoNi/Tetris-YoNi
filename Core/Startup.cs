namespace Tetris
{
    using System;
    
    using Core.Blocks;

    public class Startup
    {
        // this matrix is representig the console cells
        public static int[][] gameMatrix;
        public static Random randomGenerator = new Random();

        public static int modelWidth;
        public static int modelHeight;

        public static void Main()
        {
            SetConsoleSettings();

            InitilizeGameMatrix();

            // Core game loop
            while (true)
            {
                // Creates the active block, that player will control
                Block block = GetNewBlock();

                AddBlockOnGameMatrix(block);
                PrintGameMatrix();

                while (true)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (block.X > 0)
                                MoveBlockLeft(ref block);
                            break;
                            // TODO: add a case for RightArrow... Hint: Make the constraint    if (block.X < Console.Width - modelWidth)    , then create method MoveBlockRight()
                    }

                    PrintGameMatrix();
                }
            }
        }

        private static void SetConsoleSettings()
        {
            Console.Title = "YoNi Tetris";
            Console.CursorVisible = false;

            Console.WindowWidth = 60;
            Console.WindowHeight = 40;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight + 1;
        }

        // Fills the game matrix with arrays of integers with value 0
        public static void InitilizeGameMatrix()
        {
            gameMatrix = new int[Console.WindowHeight][];

            for (int i = 0; i < gameMatrix.Length; i++)
            {
                gameMatrix[i] = new int[Console.WindowWidth];
            }
        }

        private static void AddBlockOnGameMatrix(Block block)
        {
            for (int row = 0; row < modelHeight; row++)
            {
                for (int col = 0; col < modelWidth; col++)
                {
                    int gameMatrixRow = row + block.Y;
                    int gameMatrixCol = col + block.X;

                    gameMatrix[gameMatrixRow][gameMatrixCol] = block.Model[row][col];
                }
            }
        }

        private static Block GetNewBlock()
        {
            int[][] model = Models.FirstBlock; // for now we will only use FirstBlock

            // Updates the current model width and height
            modelWidth = model[0].Length;
            modelHeight = model.Length;

            int blockX = randomGenerator.Next(0, Console.WindowWidth - modelWidth);

            return new Block(blockX, 0, model);
        }

        private static void MoveBlockLeft(ref Block block)
        {
            ClearBlockFromGameMatrix(block);

            block = new Block(block.X - 1, block.Y, block.Model); // We changed to (block.X - 1) to move one col left

            AddBlockOnGameMatrix(block);
        }

        private static void ClearBlockFromGameMatrix(Block block)
        {
            for (int row = 0; row < modelHeight; row++)
            {
                for (int col = 0; col < modelWidth; col++)
                {
                    if (block.Model[row][col] == 1)
                    {
                        int gameMatrixRow = row + block.Y;
                        int gameMatrixCol = col + block.X;

                        gameMatrix[gameMatrixRow][gameMatrixCol] = 0;

                        Console.SetCursorPosition(gameMatrixCol, gameMatrixRow);
                        Console.Write(' ');
                    }
                }
            }
        }

        private static void PrintGameMatrix()
        {
            for (int row = 0; row < gameMatrix.Length; row++)
            {
                for (int col = 0; col < gameMatrix[row].Length; col++)
                {
                    int currElem = gameMatrix[row][col];

                    if (currElem == 1)
                    {
                        Console.SetCursorPosition(col, row);
                        Console.Write(currElem);
                    }
                }
            }
        }
    }
}
