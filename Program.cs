using System;

namespace calculator
{
  class Program
  {
    static void Main(string[] args)
    {
      CalculatorApp();
    }

    static void CalculatorApp()
    {
      double number1 = InputNumber("first");

      string mathOperator = InputOperator();

      double number2 = InputNumber("second");

      double result = Calculate(number1, number2, mathOperator);

      WriteResult(result);

      CheckIfContinue();
    }

    static double Calculate(double number1, double number2, string mathOperator)
    {
      double result = 0;
      switch (mathOperator)
      {
        case "+":
          result = number1 + number2;
          break;
        case "-":
          result = number1 - number2;
          break;
        case "*":
          result = number1 * number2;
          break;
        case "/":
          result = number1 / number2;
          break;
        default:
          break;
      }

      return result;
    }

    static double InputNumber(string order)
    {
      double number;
      try
      {
        Console.Write($"Write your {order} number: ");
        number = Convert.ToDouble(Console.ReadLine());
        return number;
      }
      catch (FormatException ex)
      {
        WriteError(ex.Message);
        return InputNumber(order);
      }
    }

    static string InputOperator()
    {
      Console.Write("Write your operator: ");
      string mathOperator = Console.ReadLine();
      while (mathOperator != "+" && mathOperator != "-" && mathOperator != "*" && mathOperator != "/")
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please put a valid operator!");
        Console.ResetColor();
        Console.Write("Write your operator: ");
        mathOperator = Console.ReadLine();
      }

      return mathOperator;
    }

    static void WriteResult(double result)
    {
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      Console.WriteLine($"Your result is: {result}");
      Console.ResetColor();
    }

    static void WriteError(string message)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine($"Error: {message}");
      Console.ResetColor();
    }

    static void CheckIfContinue()
    {
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine("Do you want to continue? Press Enter");
      Console.ResetColor();
      ConsoleKeyInfo keyInfo = Console.ReadKey();
      if (keyInfo.Key == ConsoleKey.Enter)
      {
        CalculatorApp();
      }
    }
  }
}
