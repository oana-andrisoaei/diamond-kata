using System;

namespace DiamondKata
{
  internal class Program
  {
    static void Main(string[] args)
    {
      //Assumption: characters should always be uppercase
      Console.WriteLine("Hello World!");
      char inputChar = Console.ReadKey().KeyChar;
      DiamondGenerator diamond = new DiamondGenerator(inputChar);
      diamond.GenerateDiamond();
      diamond.PrintDiamond();
    }
  }
}
