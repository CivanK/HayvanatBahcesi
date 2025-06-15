namespace HayvanatBahcesi.Models
{
    public class Chicken : Animal
    {
        public override int Speed => 1;

        public Chicken(Point position, Gender gender) : base(position, gender) { }
    }
}