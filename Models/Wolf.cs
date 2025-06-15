namespace HayvanatBahcesi.Models
{
    public class Wolf : Animal
    {
        public override int Speed => 3;

        public Wolf(Point position, Gender gender) : base(position, gender) { }
    }
}