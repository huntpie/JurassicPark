using System;

namespace JurassicPark
{
  public class FrontEnd
  {
    private DinosaurController OurDinosaursController;

    //Constructor
    public FrontEnd(DinosaurController dinosaurControllerToUse)
    {
      OurDinosaursController = dinosaurControllerToUse;
    }

    public string PromptForString(string prompt)
    {
      Console.Write(prompt);
      var userInput = Console.ReadLine();

      return userInput;
    }

    public int PromptForInteger(string prompt)
    {
      Console.Write(prompt);
      int userInput;
      var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

      if (isThisGoodInput)
      {
        return userInput;
      }
      else
      {
        Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
        return 0;
      }
    }

    public void Greeting()
    {
      //Welcome user to Jurassic Park
      Console.WriteLine();
      Console.WriteLine($"Welcome to Jurassic Park, find a dinosaur from our list of dinosaurs.");
      Console.WriteLine();
    }

    public void Menu()
    {
      var userChoseQuit = false;

      //While the user has NOT quit
      while (userChoseQuit == false)
      {
        Console.WriteLine("Make a selection please.");
        Console.WriteLine();
        Console.WriteLine("(V)iew all the dinosaurs in the list");
        Console.WriteLine("(A)dd a dinosaur to the list");
        Console.WriteLine("(R)emove a dinosaur from the list by name");
        Console.WriteLine("(T)ransfer a dinosaur to a new Enclosure");
        Console.WriteLine("(S)ummary that displays the number of carnivores and herbivores");
        Console.WriteLine("(Q)uit the program");
        Console.WriteLine();

        var selection = PromptForString("Selection: ");

        switch (selection)
        {
          case "V":

            var dinosaurs = OurDinosaursController.AllDinosaurs();

            foreach (var dinosaur in dinosaurs)
            {
              var description = dinosaur.Description();
              Console.WriteLine(description);
            }

            break;

          case "A":
            var dinosaurNameForNewDino = PromptForString("Name: ");
            var newDietType = PromptForString("Diet Type: ");
            var newWhenAcquired = PromptForString("Date & Time Created: ");
            DateTime acquiredDateFromString = DateTime.Parse(newWhenAcquired, System.Globalization.CultureInfo.InvariantCulture);
            var Weight = PromptForInteger("Weight(lbs): ");
            var EnclosureNumber = PromptForInteger("Enclosure Number: ");

            OurDinosaursController.AddNewDinosaur(dinosaurNameForNewDino, newDietType, acquiredDateFromString, Weight, EnclosureNumber);

            break;

          case "R":
            var nameOfDinoToFind = PromptForString("Name of dinosaur being removed: ");

            var foundDino = OurDinosaursController.FindDinosaurByName(nameOfDinoToFind);
            if (foundDino == null)
            {
              Console.WriteLine($"There is no dinosaur named {nameOfDinoToFind}");
            }
            else
            {
              // - Show the found dinosaur and confirm 
              var foundDinoDescription = foundDino.Description();
              Console.WriteLine(foundDinoDescription);

              var shouldWeRemove = PromptForString("Sure you want to remove this dinosaur? (Y/N): ");
              if (shouldWeRemove.ToLower() == "y")
              {
                OurDinosaursController.RemovePlease(foundDino);
              }
            }

            break;

          case "T":
            var nameOfDinoToTransfer = PromptForString("Name of dinosaur being transferred: ");

            var dinoToUpdate = OurDinosaursController.FindDinosaurByName(nameOfDinoToTransfer);
            if (dinoToUpdate == null)
            {
              Console.WriteLine($"There is no dinosaur named {nameOfDinoToTransfer}");
            }
            else
            {
              var foundDinoDescription = dinoToUpdate.Description();
              Console.WriteLine(foundDinoDescription);
              // - ask for new enclosure number
              var newEnclosureNumber = PromptForInteger("New enclosure number: ");

              // - update the dinosaur
              OurDinosaursController.Transfer(dinoToUpdate, newEnclosureNumber);
            }

            break;

          case "S":
            string carnivoreString = "carnivore";
            OurDinosaursController.FindDinosaurByDietType(carnivoreString);


            break;


          //dinosaurs created on or after user inputted date case

          //dinosaurs in a given enclosure number
          case "Q":
            userChoseQuit = true;
            break;
        }
      }
    }


  }
}