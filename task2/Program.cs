/*

Задача 66: Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных элементов в промежутке от M до N.

M = 1; N = 15 -> 120
M = 4; N = 8. -> 30

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

int SumRange(int m, int n, int sum = 0)
{
    if (m <= n)
        return SumRange(m + 1, n, sum + m);
    
    else
        return sum;
}



Console.WriteLine();
Console.WriteLine("================ START ================");
Console.WriteLine();

int m = GetNumber("Введите число M", notNull: true);

int n = GetNumber("Введите число N", notNull: true, lowestValueExists: true, lowestValue: m);

Console.WriteLine($"Сумма натуральных элементов в промежутке от M до N: {SumRange(m, n)}");

Console.WriteLine();
Console.WriteLine("================== END ================");
Console.WriteLine();
