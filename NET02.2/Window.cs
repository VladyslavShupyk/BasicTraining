namespace NET02._2
{
    class Window
    {
        public readonly int DEFAULT_TOP = 0;
        public readonly int DEFAULT_LEFT = 0;
        public readonly int DEFAULT_WIDTH = 400;
        public readonly int DEFAULT_HEIGHT = 150;
        public string Title { get; set; }
        public int? Top { get; set; }
        public int? Left { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public Window(string title, int top, int left, int width, int height)
        {
            Title = title;
            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }
    }
}
