using System;


namespace JurassicPark
{
  public class Dinosaur
  {
    //Name: string047

    public string Name { get; set; }

    //DietType: "carnivore" or "herbivore" - string
    public string DietType { get; set; }

    //WhenAcquired: default to current time when the dinosaur is created
    public DateTime WhenAcquired { get; set; }

    //Weight: How heavy the dinosaur is in pounds - double
    public int Weight { get; set; }
    //EnclosureNumber: the number of the pen the dinosaur is currently in - double
    public int EnclosureNumber { get; set; }

    public string Description()
    {
      Console.WriteLine();
      return $"{Name} is a {DietType}" +
            $" that was created on {WhenAcquired} and {Name}" +
            $" weighs {Weight} pounds. You can find this " +
            $"dinosaur in Enclosure {EnclosureNumber}.";
    }
  }
}