namespace HayvanatBahcesi.Models
{
    public class Rooster : Animal
    {
        public override int Speed => 1;

        public Rooster(Point position, Gender gender) : base(position, gender) { }
    }
}