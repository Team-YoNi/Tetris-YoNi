namespace Tetris.Blocks
{
    using System;

    public class Block
    {
        // The top left starting point of the block
        private int x = 0;
        private int y = 0;
        private int[][] model;

        public Block(int x, int y, int[][] model)
        {
            this.X = x;
            this.Y = x;
            this.Model = model;
        }


        // Do not touch this property!
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (x < 0)
                    throw new ArgumentException("The x of the block cannot be less than 0");
                if (x > Console.WindowWidth)
                    throw new ArgumentException($"The x of the block cannot be greater than the Console's Width {Console.WindowWidth}");

                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                if (y < 0)
                    throw new ArgumentException("The y of the block cannot be less than 0");
                if (y > Console.WindowHeight)
                    throw new ArgumentException($"The y of the block cannot be greater than the Console's Height {Console.WindowHeight}");

                this.y = value;
            }
        }

        // Do not touch this property!
        public int[][] Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
    }
}
