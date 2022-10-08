// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
// и возвращает значение этого элемента или же указание, что такого элемента нет.

// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4

// Строка 1
// Столбец 2
// Вывод: 4


void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            Console.Write($"{matrix[i,j]}\t");
        Console.WriteLine();
    }
}

int[,] arr = new int[,]
           {{1, 4, 7, 2},
            {5, 9, 2, 3},
            {8, 4, 2, 4}};

Console.Clear();
Console.Write("Введите строку: ");
int n = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите столбец: ");
int m = Convert.ToInt32(Console.ReadLine());

if ((n < 1 || n > arr.GetLength(0))  || (m < 1 || m > arr.GetLength(1)))
{
    Console.Write("За пределами допустимого диапазона");
    return;
}
Console.WriteLine("Массив:");
PrintMatrix(arr);
Console.Write($"{m}-й элемент {n}-й строки равен {arr[n-1, m-1]}");