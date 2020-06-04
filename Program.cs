using System.Linq;

namespace JurassicPark
{
  class Program
  {
    static void Main(string[] args)
    {

      //create a new object that manages dinosaurs
      var dinosaurController = new DinosaurController();
      dinosaurController.Seed();

      //new object that interacts with users
      var frontEnd = new FrontEnd(dinosaurController);
      frontEnd.Greeting();
      frontEnd.Menu();

      //dinosaurController.PrintLog();
      dinosaurController.SaveAllDinosaurs();
    }
  }
}
