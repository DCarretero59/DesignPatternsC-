using System;

namespace DecortatorMultipleInheritance
{
    public class Bird
    {
        public int Weight { get; set; }
        public void Fly()
        {
            Console.WriteLine($"Flying with weight {Weight}");
        }
    }

    public class Lizard
    {
        public int Weight { get; set; }
        public void Crawl()
        {
            Console.WriteLine($"Crawling with weight {Weight}");
        }
    }


    public class Dragon // no multiple inheritance
    {
        public int Weight
        {
            get => _weight;
            set => _weight = bird.Weight = lizard.Weight =  value;
        }

        private Bird bird;
        private Lizard lizard;
        private int _weight;

        public Dragon(Bird bird, Lizard lizard)
        {
            this.bird = bird ?? throw new ArgumentNullException(paramName: nameof(bird));
            this.lizard = lizard ?? throw new ArgumentNullException(paramName: nameof(lizard));
        }

        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }
    }

    static class Demo
    {
        static void Main(string[] args)
        {
            var d = new Dragon(new Bird(), new Lizard());
            d.Weight = 159;
            d.Fly();
            d.Crawl();
        }
    }
}
