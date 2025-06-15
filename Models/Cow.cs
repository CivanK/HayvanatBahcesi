namespace HayvanatBahcesi.Models
{
    public class Cow : Animal
    {
        public override int Speed => 2;

        public Cow(Point position, Gender gender) : base(position, gender) { }
    }
}