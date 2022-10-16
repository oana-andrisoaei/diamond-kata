using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DiamondKata.UnitTests
{
  [TestClass]
  public class DiamondKataTests
  {

    [TestMethod]
    public void Generate_A_Diamond_OK()
    {
      DiamondGenerator actualADiamond = new DiamondGenerator('A');
      actualADiamond.GenerateDiamond();
      Assert.AreEqual(1, actualADiamond.DiamondMatrix.Length);
      Assert.AreEqual(1, actualADiamond.DiamondMatrix[0].Length);
      Assert.AreEqual('A', actualADiamond.DiamondMatrix[0][0]);
    }

    [TestMethod]
    public void GeneratedDiamond_IsNotEmpty_OK()
    {
      char[][] diamondMatrix = GetDiamondMatrix(GenerateRandomLetterFromBToZ());
      Assert.IsTrue(diamondMatrix.Length > 1);
      Assert.IsTrue(diamondMatrix[0].Length > 1);
    }

    [TestMethod]
    public void GeneratedDiamond_NumberOfColumnsAndRowsAreEqual_OK()
    {
      char[][] diamondMatrix = GetDiamondMatrix(GenerateRandomLetterFromBToZ());

      Assert.AreEqual(diamondMatrix.Length, diamondMatrix[0].Length);
    }

    [TestMethod]
    public void GeneratedDiamond_FirstLineAndLastLineContainsExactlyOneA_OK()
    {
      char[][] diamondMatrix = GetDiamondMatrix(GenerateRandomLetterFromBToZ());

      Assert.AreEqual(1, diamondMatrix[0].Count(c => c == 'A'));
      Assert.AreEqual(1, diamondMatrix[diamondMatrix.Length - 1].Count(c => c == 'A'));
    }

    [TestMethod]
    public void GeneratedDiamond_EveryRowContainsExactlyTwoLetters_Ok()
    {
      char[][] diamondMatrix = GetDiamondMatrix(GenerateRandomLetterFromBToZ());

      for (int i = 1; i < diamondMatrix.Length - 1; i++)
      {
        Assert.AreEqual(2, diamondMatrix[i].Count(c => char.IsLetter(c)));
      }
    }

    [TestMethod]
    public void GeneratedDiamond_EveryColumnContainsExactlyTwoLetters_Ok()
    {
      char[][] diamondMatrix = GetDiamondMatrix(GenerateRandomLetterFromBToZ());

      for (int i = 1; i < diamondMatrix.Length - 1; i++)
      {
        char[] column = GetColumn(diamondMatrix, i);
        Assert.AreEqual(2, column.Count(c => char.IsLetter(c)));
      }
    }

    [TestMethod]
    public void GeneratedDiamond_GeneratedLetterIsFirstAndLastInTheMiddleRow_OK()
    {
      char letter = GenerateRandomLetterFromBToZ();
      char[][] diamondMatrix = GetDiamondMatrix(letter);

      int middleColumnIndex = diamondMatrix.Length / 2;
      Assert.AreEqual(letter, diamondMatrix[middleColumnIndex][0]);
      Assert.AreEqual(letter, diamondMatrix[middleColumnIndex][diamondMatrix.Length - 1]);
    }

    [TestMethod]
    public void GeneratedDiamond_EveryCharIsLetterOrPadding_OK()
    {
      char[][] diamondMatrix = GetDiamondMatrix(GenerateRandomLetterFromBToZ());

      for (int i = 0; i < diamondMatrix.Length; i++)
      {
        Assert.AreEqual(0, diamondMatrix[i].Count(c => !char.IsLetter(c) && c != '-'));
      }
    }

    [TestMethod]
    public void GeneratedDiamond_EveryRowIsPalindrome_Ok()
    {
      char[][] diamondMatrix = GetDiamondMatrix(GenerateRandomLetterFromBToZ());

      for (int i = 0; i < diamondMatrix.Length; i++)
      {
        char[] reversedCharArray = new char[diamondMatrix.Length];
        Array.Copy(diamondMatrix[i], reversedCharArray, diamondMatrix.Length);
        Array.Reverse(reversedCharArray);
        Assert.AreEqual(new string(diamondMatrix[i]), new string(reversedCharArray));
      }
    }

    [TestMethod]
    public void GeneratedDiamond_EveryColumnIsPalindrome_Ok()
    {
      char[][] diamondMatrix = GetDiamondMatrix(GenerateRandomLetterFromBToZ());

      for (int i = 0; i < diamondMatrix.Length; i++)
      {
        char[] column = GetColumn(diamondMatrix, i);
        char[] reversedCharArray = new char[diamondMatrix.Length];
        Array.Copy(column, reversedCharArray, diamondMatrix.Length);
        Array.Reverse(reversedCharArray);
        Assert.AreEqual(new string(column), new string(reversedCharArray));
      }
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void InitializeDiamond_NonLetter_NOK()
    {
      DiamondGenerator diamond = new DiamondGenerator('3');
    }

    private char[][] GetDiamondMatrix(char letter)
    {
      DiamondGenerator diamond = new DiamondGenerator(letter);
      diamond.GenerateDiamond();
      return diamond.DiamondMatrix;
    }
    private char GenerateRandomLetterFromBToZ()
    {
      Random random = new Random();
      int ascii_index = random.Next(66, 91);
      return Convert.ToChar(ascii_index);
    }

    private char[] GetColumn(char[][] matrix, int columnNo)
    {
      return matrix.Where(o => (o != null && o.Count() > columnNo)).Select(o => o[columnNo]).ToArray();
    }
  }
}
