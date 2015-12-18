namespace PictureTjak
{
    class DragPicture
    {
        public int StartX { get; private set; }

        public int StartY { get; private set; }

        public bool IsDragging { get; private set; }

        public void Start(int x, int y)
        {
            StartX = x;
            StartY = y;
            IsDragging = true;
        }

        public void End()
        {
            StartX = 0;
            StartY = 0;
            IsDragging = false;
        }
    }
}
