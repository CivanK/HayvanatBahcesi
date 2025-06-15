namespace HayvanatBahcesi.Models
{
    public class Lion : Animal
    {
        public override int Speed => 4;

        public Lion(Point position, Gender gender) : base(position, gender) { }
    }
}