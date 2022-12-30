/*

Задача 64: Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от N до 1. Выполнить с помощью рекурсии.

N = 5 -> "5, 4, 3, 2, 1"
N = 8 -> "8, 7, 6, 5, 4, 3, 2, 1"

*/



// Получает целое число от пользователя
int GetNumber(string message, bool notNull = false, bool notNegative = false, bool lowestValueExists = false, int lowestValue = 0)
{
    bool isCorrect = false;
    int number = 0;

    while (!isCorrect)
    {
        Console.Write(message+": ");
        string input = Console.ReadLine() ?? "";

        if (int.TryParse(input, out number))
        {
            if (notNull && number == 0)
                Console.WriteLine("Число не должно быть равно нулю.");
            
            else if (notNegative && number < 0)
                Console.WriteLine("Число должно быть положительным.");
            
            else if (lowestValueExists && number <= lowestValue)
                Console.WriteLine($"Число должно быть больше {lowestValue}.");
            
            else
                isCorrect = true;
        }
            
        else
            Console.WriteLine(input.Trim() == "" ? "Вы ничего не ввели." : "Вы ввели некорректные данные.");
    }
    
    return number;
}

string NaturalDigitsRow(int n, bool positive)
{
    if (positive && n > 1)
        return $"{n}, {NaturalDigitsRow(n - 1, positive)}";
    
    else if (!positive && n < 1)
        return $"{n}, {NaturalDigitsRow(n + 1, positive)}";

    else
        return $"{n}";
}



Console.WriteLine();
Console.WriteLine("================ START ================");
Console.WriteLine();

int n = GetNumber("Введите число N", notNull: true);

Console.WriteLine($"Натуральные числа в промежутке от N до 1: {NaturalDigitsRow(n, n > 0)}");

Console.WriteLine();
Console.WriteLine("================== END ================");
Console.WriteLine();
