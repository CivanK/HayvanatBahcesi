namespace HayvanatBahcesi.Models
{
    public class Hunter
    {
        public Point Position { get; set; }
        public int Speed => 1;

        public Hunter(Point position)
        {
            Position = position;
        }

        public void Move(int areaSize, Random rnd)
        {
            int dx = rnd.Next(-Speed, Speed + 1);
            int dy = rnd.Next(-Speed, Speed + 1);

            Position.X = Math.Clamp(Position.X + dx, 0, areaSize);
            Position.Y = Math.Clamp(Position.Y + dy, 0, areaSize);
        }
    }
}