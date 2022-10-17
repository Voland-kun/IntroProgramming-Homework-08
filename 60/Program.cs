// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int[,,] generate3dArray(int height, int width, int depth, int randomStart, int randomEnd)
{
    int[,,] threeDArray = new int[height, width, depth];
    int[] dictionaryArray = new int[threeDArray.Length];
    int count = 0;
    for (int i=0; i<height; i++)
    {
        for (int j=0; j<width; j++)
        {
            for (int k=0; k<depth; k++)
            {
                threeDArray[i,j,k] = uniqueElementCheck(dictionaryArray, randomStart, randomEnd);
                dictionaryArray[count] = threeDArray[i,j,k];
                count += 1;
            }
        }
    }
    return threeDArray;
}

int uniqueElementCheck(int[] currentArray, int randomStart, int randomEnd)
{
    int result = (new Random().Next(randomStart, randomEnd));
    bool retry = false;
    foreach (int number in currentArray)
    {
        if(number == result)
        retry = true;
    }
    if(retry == true)
    return uniqueElementCheck(currentArray, randomStart, randomEnd);
    else return result;
}

void print3DArrayInLines(int[,,] arrayToPrint)
{
    for (int k = 0; k < arrayToPrint.GetLength(0); k++)
    {
        for (int i = 0; i < arrayToPrint.GetLength(1); i++)
        {
            Console.WriteLine();
            for (int j = 0; j < arrayToPrint.GetLength(2); j++)
            {
                Console.Write($"{arrayToPrint[i,j,k]}({i},{j},{k}) ");
            }
        }
    }
}

int[,,] new3dArray = generate3dArray(2, 2, 2, 10, 100);
print3DArrayInLines(new3dArray);