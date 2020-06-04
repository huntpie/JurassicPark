using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Linq;
using System.Globalization;





namespace JurassicPark
{
  class DinosaurController
  {
    private List<Dinosaur> Dinosaurs = new List<Dinosaur>();
    private List<string> Log = new List<string>();
    public void SaveAllDinosaurs()
    {
      var writer = new StreamWriter("dinosaurs.csv");

      var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

      csvWriter.WriteRecords(Dinosaurs);

      writer.Close();
    }
    public void LoadAllDinosaurs()
    {
      if (File.Exists("dinosaurs.csv"))
      {
        var reader = new StreamReader("dinosaurs.csv");

        var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

        Dinosaurs = csvReader.GetRecords<Dinosaur>().ToList();
      }
    }


    //return the list of dinosaurs
    public IEnumerable<Dinosaur> AllDinosaurs()
    {
      Log.Add("Someone prompted for a list of dinosaurs");
      return Dinosaurs.OrderBy(dinosaur => dinosaur.Name);
    }

    //Find dinosaur by name
    public Dinosaur FindDinosaurByName(string name)
    {
      Log.Add($"Someone looked for a dinosaur named {name}");
      var foundDino = Dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == name);

      return foundDino;
    }

    //Add a new dinosaur
    public void AddNewDinosaur(string name, string dietType, DateTime whenAcquired, int weight, int enclosureNumber)
    {
      Log.Add($"Someone added a dinosaur named {name}");

      var newDinosaur = new Dinosaur
      {
        Weight = weight,
        DietType = dietType,
        WhenAcquired = whenAcquired,
        Name = name,
        EnclosureNumber = enclosureNumber,
      };

      Dinosaurs.Add(newDinosaur);

      SaveAllDinosaurs();
    }

    //Given a dinosaur, Remove it
    public void RemovePlease(Dinosaur dinoToRemove)
    {
      Log.Add($"Someone removed a dinosaur named {dinoToRemove.Name}");

      Dinosaurs.Remove(dinoToRemove);

      SaveAllDinosaurs();

    }

    //Transfer the dinosaur to given enclosure number
    public void Transfer(Dinosaur dinoToTransfer, int enclosureNumber)
    {
      Log.Add($"Someone transferred a dinosaur named {dinoToTransfer} to Enclosure Number {enclosureNumber}");

      dinoToTransfer.EnclosureNumber = enclosureNumber;

      SaveAllDinosaurs();
    }
    //Summary - output the number of herbivores and carnivores
    public void FindDinosaurByDietType(string dietType)
    {
      int hCount = 0;
      int cCount = 0;
      for (int index = 0; index < Dinosaurs.Count; index++)
      {

        var dino1 = Dinosaurs[index];
        if (dino1.DietType == "herbivore")
        {
          hCount++;
        }
        else
        {
          cCount++;
        }
      }
      Console.WriteLine($"Number of Carnivores in the Park: {cCount}. Number of Herbivores: {hCount}");
    }

    //Given a WhenAcquired date of a dinosaur, return the dinosaurs after that date, or null if nothing found


    //Given an EnclosureNumber of a dinosaur, return the dinosaurs in that enclosure number, or null if nothing found



    // public void PrintLog()
    // {
    //  foreach (var log in Log)
    //  {
    //   Console.WriteLine(log);
    // }
    //  }


    public void Seed()
    {
      DateTime localDate1 = DateTime.Now;
      //Add some dinosaurs to our database of dinosaurs

      var trex = new Dinosaur
      {
        Name = "T-Rex",
        DietType = "carnivore",
        WhenAcquired = localDate1,
        Weight = 25000,
        EnclosureNumber = 9,
      };

      var raptor = new Dinosaur
      {
        Name = "Raptor",
        DietType = "carnivore",
        WhenAcquired = localDate1,
        Weight = 3500,
        EnclosureNumber = 10,
      };

      var triceratops = new Dinosaur
      {
        Name = "Triceratops",
        DietType = "herbivore",
        WhenAcquired = localDate1,
        Weight = 13000,
        EnclosureNumber = 8,
      };

      var brachiosaurus = new Dinosaur
      {
        Name = "Brachiosaurus",
        DietType = "herbivore",
        WhenAcquired = localDate1,
        Weight = 37000,
        EnclosureNumber = 5,
      };

      Dinosaurs.Add(trex);
      Dinosaurs.Add(raptor);
      Dinosaurs.Add(triceratops);
      Dinosaurs.Add(brachiosaurus);

    }




  }
}