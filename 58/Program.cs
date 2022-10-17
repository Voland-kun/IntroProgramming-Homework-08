// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

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

int[,] matrixRowXColumnMultiplication(int[,] multiplayer, int[,] multiplicand)
{
    int[,] product = new int[multiplayer.GetLength(0),multiplicand.GetLength(1)];
    for(int i=0; i < multiplayer.GetLength(0); i++)
    {
        for(int j=0; j < multiplicand.GetLength(1); j++)
        {
            for(int k=0; k < multiplicand.GetLength(0); k++)
            {
                product[i,j] += multiplayer[i,k] * multiplicand[k,j];
            }
        }    
    }
    return product;
}

int getArrayDimensions(string userInformation)
{
    Console.Write(userInformation);
    int result = Convert.ToInt32(Console.ReadLine());
    return result;
}

Console.WriteLine("Введите размер множимого массива:");
int multiplayerRows = getArrayDimensions("количество строк ");
int multiplayerColumns = getArrayDimensions("количество столбцов ");
Console.WriteLine("Введите размер массива-множителя");
int multiplicandRows = getArrayDimensions("количество строк ");
int multiplicandColumns = getArrayDimensions("количество столбцов ");
int[,] multiplayerArray = generate2dArray(multiplayerRows, multiplayerColumns, 1, 10);
int[,] multiplicandArray = generate2dArray(multiplicandRows, multiplicandColumns, 1, 10);
Console.WriteLine("Множимый массив:");
print2DArray(multiplayerArray);
Console.WriteLine("Массив-множитель:");
print2DArray(multiplicandArray);
if(multiplayerArray.GetLength(1) == multiplicandArray.GetLength(0))
    {
        int[,] productArray = matrixRowXColumnMultiplication(multiplayerArray, multiplicandArray);
        printColorData("Произведение матриц:");
        print2DArray(productArray);
    }
else printColorData("Матрицы не согласованы.");