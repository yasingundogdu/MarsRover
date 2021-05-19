namespace MarsRover.Domain
{
    public class PlateauModel
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public PlateauModel(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
