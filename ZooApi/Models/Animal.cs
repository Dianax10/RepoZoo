namespace ZooApi.Models
{
    public class Animal
    {
        public int IdAnimal { get; set; }
        public string Specie { get; set; }

        public double Peso { get; set; }

        public double Altezza { get; set; }
        public AreaModel Area { get; set; }
    }
}
