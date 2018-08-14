namespace Tetris
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Timers;
    using Core.Blocks;
    using Core.Stats;

    public class Startup
    {
        public const int CONSOLE_WIDTH = 40;
        public const int CONSOLE_HEIGHT = 30;

        // this matrix is representig the console cells
        public static Block activeBlock;
        public static char[][] gameMatrix;
        public static Random randomGenerator = new Random();
        public static ConsoleKey keyPressed;
        public static int timeCounter = 0;

        public static int modelWidth;
        public static int modelHeight;
        public static readonly int footerStartRow = CONSOLE_HEIGHT - 3;

        public static void Main()
        {
            SetConsoleSettings();

            InitilizeGameMatrix();

            PrintFooter();

            // Core game loop
            while (true)
            {
                // Creates the active block, that player will control
                activeBlock = GetNewBlock();

                AddBlockOnGameMatrix();
                PrintGameMatrix();

                // This awesome timer here will take care of invoking OnTimeEvent every 200 miliseconds
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                timer.Interval = 200;
                timer.Enabled = true;
                //

                while (true)
                {
                    Task task = Task.Factory.StartNew(() => ReadKey());

                    switch (keyPressed)
                    {
                        case ConsoleKey.LeftArrow:
                            if (activeBlock.X > 0)
                                MoveBlockLeft();
                            break;
                        case ConsoleKey.RightArrow:
                            if (activeBlock.X < CONSOLE_WIDTH - modelWidth)
                                MoveBlockRight();
                            break;
                    }

                    keyPressed = ConsoleKey.Spacebar;

                    if (timeCounter >= 1)
                    {
                        timeCounter = 0;
                        MoveBlockDown();
                    }

                    if (activeBlock.Y + modelHeight >= gameMatrix.Length) { break; }

                    PrintGameMatrix();
                }
            }
        }

        private static void ReadKey()
        {
            keyPressed = Console.ReadKey(true).Key;
        }

        private static void PrintFooter()
        {
            string borderFooter = new string('=', CONSOLE_WIDTH);

            int borderFooterCol = 0;
            int borderFooterRow = footerStartRow;
            Console.SetCursorPosition(borderFooterCol, borderFooterRow);
            Console.WriteLine(borderFooter);

            int pointsCol = (CONSOLE_WIDTH - Points.Text.Length) / 2;
            int pointsRow = CONSOLE_HEIGHT - 1;
            Console.SetCursorPosition(pointsCol, pointsRow);
            Console.WriteLine(Points.Text);
        }

        private static void SetConsoleSettings()
        {
            Console.Title = "YoNi Tetris";
            Console.CursorVisible = false;

            Console.WindowWidth = CONSOLE_WIDTH;
            Console.WindowHeight = CONSOLE_HEIGHT;
            Console.BufferWidth = CONSOLE_WIDTH;
            Console.BufferHeight = CONSOLE_HEIGHT;
        }

        // Fills the game matrix with arrays of characters with value (' ')
        public static void InitilizeGameMatrix()
        {
            int gameMatrixHeight = footerStartRow - 1;
            int gameMatrixWidth = CONSOLE_WIDTH;

            gameMatrix = new char[gameMatrixHeight][];

            for (int row = 0; row < gameMatrix.Length; row++)
            {
                gameMatrix[row] = new char[gameMatrixWidth]
                    .Select(x => ' ')
                    .ToArray();
            }
        }

        private static void AddBlockOnGameMatrix()
        {
            for (int row = 0; row < modelHeight; row++)
            {
                for (int col = 0; col < modelWidth; col++)
                {
                    int gameMatrixRow = row + activeBlock.Y;
                    int gameMatrixCol = col + activeBlock.X;

                    if (activeBlock.Model[row][col] == 1)
                    {
                        gameMatrix[gameMatrixRow][gameMatrixCol] = '*';
                    }
                }
            }
        }

        private static Block GetNewBlock()
        {
            int[][] model = GetRandomModel();

            // Updates the current model width and height
            modelWidth = model[0].Length;
            modelHeight = model.Length;

            int blockX = randomGenerator.Next(0, CONSOLE_WIDTH - modelWidth);

            return new Block(blockX, 0, model);
        }

        private static int[][] GetRandomModel()
        {
            //Have I done my job well, master? ;) 

            int index = randomGenerator.Next(0, 7);

            int[][] randomModel = Models.AllBlocks[index];

            return randomModel;
        }

        private static void MoveBlockLeft()
        {
            ClearBlockFromGameMatrix();

            activeBlock = new Block(activeBlock.X - 1, activeBlock.Y, activeBlock.Model); // We changed to (block.X - 1) to move one col left

            AddBlockOnGameMatrix();
        }

        private static void MoveBlockRight()
        {
            ClearBlockFromGameMatrix();

            activeBlock = new Block(activeBlock.X + 1, activeBlock.Y, activeBlock.Model); // We changed to (block.X + 1) to move one col right

            AddBlockOnGameMatrix();
        }

        private static void MoveBlockDown()
        {
            ClearBlockFromGameMatrix();

            activeBlock = new Block(activeBlock.X, activeBlock.Y + 1, activeBlock.Model); // We changed to (block.Y + 1) to move one row down

            AddBlockOnGameMatrix();
        }

        private static void ClearBlockFromGameMatrix()
        {
            for (int row = 0; row < modelHeight; row++)
            {
                for (int col = 0; col < modelWidth; col++)
                {
                    if (activeBlock.Model[row][col] == 1)
                    {
                        int gameMatrixRow = row + activeBlock.Y;
                        int gameMatrixCol = col + activeBlock.X;

                        gameMatrix[gameMatrixRow][gameMatrixCol] = ' ';

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
                    char currElem = gameMatrix[row][col];

                    if (currElem != ' ')
                    {
                        Console.SetCursorPosition(col, row);
                        Console.Write(currElem);
                    }
                }
            }
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            timeCounter++;
        }
    }
}
