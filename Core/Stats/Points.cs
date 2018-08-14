namespace Core.Stats
{
    using System;

    public static class Points
    {
        private static int value = 0;

        private static string text = "Points: 0";

        public static int Value
        {
            get
            {
                return Points.value;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Points cannot be less tahn 0");

                // When points are changed, text also is updating
                Points.Text = $"Points: {value}";

                value = Points.value;
            }
        }

        public static string Text
        {
            get
            {
                return text;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("Text cannot be null");

                text = value;
            }
        }
    }
}
