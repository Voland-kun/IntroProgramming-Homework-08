// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2




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

void sortRows2DArray(int[,] arrayToSort)
{
    for(int i=0; i<arrayToSort.GetLength(0); i++)
    {
        for(int j=0; j<arrayToSort.GetLength(1); j++)
        {
            int temp = 0;
            for(int k=j+1; k<arrayToSort.GetLength(1); k++)
            {
                if(arrayToSort[i,k]<arrayToSort[i,j])
                {
                    temp = arrayToSort[i,j];
                    arrayToSort[i,j] = arrayToSort[i,k];
                    arrayToSort[i,k] = temp;
                }    
            }
        }
    }
}



Console.WriteLine("Введите количество строк массива");
int arrayRows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество стролбцов массива");
int arrayColumns = Convert.ToInt32(Console.ReadLine());
int[,] generateArray = generate2dArray(arrayRows,arrayColumns,0,10);
print2DArray(generateArray);
sortRows2DArray(generateArray);
Console.WriteLine();
print2DArray(generateArray);