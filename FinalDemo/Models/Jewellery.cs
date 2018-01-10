namespace FinalDemo.Models
{
    using System;

    public enum Title
    {
        Earrings,
        Necklace,
        WeddingRing,
        Coulomb
    }

    public enum Metal
    {
        Gold,
        Silver,
        Bronze,
        Platinum,
        Palladium
    }

    public class Jewellery
    {
        public Title Title { get; set; }

        public Metal Metal { get; set; }

        public double Weight { get; set; }

        public decimal Price { get; set; }

        public void GetRandomValues(Random random)
        {
            this.Title = (Title)random.Next(4);
            this.Metal = (Metal)random.Next(5);
            this.Weight = 20d * random.NextDouble();
            this.Price = random.Next(1000, 20000);
        }

        public override string ToString()
        {
            var result = $"{this.Title} {this.Metal.ToString()} {this.Weight} {this.Price}\n";
            return result;
        }
    }
}
