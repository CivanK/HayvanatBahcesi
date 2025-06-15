namespace HayvanatBahcesi.Models
{
    public abstract class Animal
    {
        public Point Position { get; set; }
        public Gender Gender { get; set; }
        public abstract int Speed { get; }

        protected Animal(Point position, Gender gender)
        {
            Position = position;
            Gender = gender;
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