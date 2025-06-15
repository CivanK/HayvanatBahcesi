namespace HayvanatBahcesi.Models
{
    public class Sheep : Animal
    {
        public override int Speed => 2;

        public Sheep(Point position, Gender gender) : base(position, gender) { }
    }
}