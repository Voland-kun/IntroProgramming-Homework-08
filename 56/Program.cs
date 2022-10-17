// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:

// 1 4 7 2

// 5 9 2 3

// 8 4 2 4

// 5 2 6 7

// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

void printColorData(string data)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(data);
    Console.ResetColor();
}

int[,] generate2dArray(int height, int width, int randomStart, int randomEnd)
{
    int[,] twoDArray = new int[height, width];
    for (int i=0; i<height; i++)
    {
        for (int j=0; j<width; j++)
        {
            twoDArray[i,j] = (new Random().Next(randomStart, randomEnd+1));
        }
    }
    return twoDArray;
}

void print2DArray(int[,] arrayToPrint)
{
    Console.WriteLine();
    Console.Write(" \t");
    for (int i = 0; i < arrayToPrint.GetLength(1); i++)
    {
        printColorData(i + "\t");
    }
    Console.WriteLine();
    for (int i = 0; i < arrayToPrint.GetLength(0); i++)
    {
        printColorData(i + "\t");
        for (int j = 0; j < arrayToPrint.GetLength(1); j++)
        {
            Console.Write(arrayToPrint[i,j] + "\t");
        }
        Console.WriteLine();
    }
}

int getArrayRowSum(int[,] currentArray, int rowCount)
{
    int result = 0;
    for(int j = 0; j<currentArray.GetLength(1); j++)
    {
        result += currentArray[rowCount, j];
    }
    return result;
}


void getNumberOfRowWithMinimalElementsSum(int[,] arrayToSort)
{
    int rowCount = 0;
    int rowSum = getArrayRowSum(arrayToSort, 0);
    for(int i=1; i<arrayToSort.GetLength(0); i++)
    {
        int compareRowSum = getArrayRowSum(arrayToSort, i);
        if(rowSum > compareRowSum)
        {
            rowSum = compareRowSum;
            rowCount = i;
        }
    }
    //вывод номера при нумерации от единицы, по примеру из условия вроде бы так выходит, поэтому на всякий случай
    //Console.WriteLine($"Строка с наименьшей суммой элементов:  {rowCount+1} строка");

    //вывод номера при нумерации от нуля
    Console.WriteLine($"Строка с наименьшей суммой элементов:  {rowCount} строка");
}


Console.WriteLine("Введите количество строк массива");
int arrayRows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество стролбцов массива");
int arrayColumns = Convert.ToInt32(Console.ReadLine());

int[,] generateArray = generate2dArray(arrayRows,arrayColumns,0,10);
print2DArray(generateArray);
Console.ForegroundColor = ConsoleColor.Green;
//Console.WriteLine("Вывод с \"человеческой\" нумерацией от первой строки");

Console.WriteLine("С нумерацией от нуля");
Console.ResetColor();

getNumberOfRowWithMinimalElementsSum(generateArray);
