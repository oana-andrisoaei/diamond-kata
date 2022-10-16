using System;

namespace DiamondKata
{
  public class DiamondGenerator
  {
    private char _letter;
    private char[][] _diamondMatrix;
    private int _numberOfRows;
    private int _positionInAlphabet;

    public char[][] DiamondMatrix
    {
      get { return _diamondMatrix; }
    }

    public DiamondGenerator(char letter)
    {
      if (!char.IsLetter(letter))
        throw new ArgumentException($"{letter} is an invalid letter.");

      _letter = char.ToUpper(letter);
      _positionInAlphabet = letter % 32;
      _numberOfRows = _positionInAlphabet * 2 - 1;
      _diamondMatrix = new char[_numberOfRows][];
    }

    public void GenerateDiamond()
    {
      if(_letter == 'A')
      {
        _diamondMatrix[0] = new char[1] { 'A' };
      }
      else
      {
        _diamondMatrix[0] = GetARow();
        _diamondMatrix[_numberOfRows - 1] = GetARow();
        int start = 1;
        int end = _numberOfRows - 2;
        int position = _positionInAlphabet - 1;
        char nextLetter = 'B';
        while (start <= end)
        {
          _diamondMatrix[start] = GetLetterRow(nextLetter, position);
          _diamondMatrix[end] = GetLetterRow(nextLetter, position);
          position--;
          nextLetter = GetNextLetter(nextLetter);
          start++;
          end--;
        }
      }
    }

    public void PrintDiamond()
    {
      for (int i = 0; i < _numberOfRows; i++)
      {
        Console.WriteLine();
        for (int j = 0; j < _numberOfRows; j++)
        {
          Console.Write(_diamondMatrix[i][j]);
        }
      }
    }

    private char[] GetARow()
    {
      char[] aRow = new char[_numberOfRows];
      for(int i = 0; i < _numberOfRows; i++)
      {
        aRow[i] = (i == _positionInAlphabet - 1) ? 'A' : '-';
      }
      return aRow;
    }

    private char[] GetLetterRow(char letter, int position)
    {
      char[] row = new char[_numberOfRows];
      for (int i = 0; i < _numberOfRows; i++)
      {
        row[i] = (i == _numberOfRows - position || i == position - 1) ? letter : '-';
      }
      return row;
    }

    private char GetNextLetter(char letter)
    {
      return (char)(((int)letter) + 1);
    }
  }
}
