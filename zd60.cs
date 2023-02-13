int[] GetRand2SizeNumber()
{
    int[] randNumbers = new int[89];
    for (int i = 0; i < randNumbers.Length; i++)
    {
        randNumbers[i] = 10 + i;
    }
   
    Random randomazer = new Random();
    for (int k = 0; k < randNumbers.Length; k++)
    {
        int j = randomazer.Next(k + 1);
        if (j != k)
        {
            var temp = randNumbers[j];
            randNumbers[j] = randNumbers[k];
            randNumbers[k] = temp;
        }
    }

    return randNumbers;
}

int[,,] GetArray3D(int rowCount, int columnCount, int depthCount, int minValue, int maxValue)
{
    int[] allPossibleCount = GetRand2SizeNumber();
    int count = 0;
    int[,,] result = new int[rowCount, columnCount, depthCount];
    for (int i = 0; i < rowCount; i++)
    {
        for (int j = 0; j < columnCount; j++)
        {
            for (int k = 0; k < depthCount; k++)
            {
                result[i, j, k] = allPossibleCount[count++];
            }
        }
    }
    return result;
}

void PrintArray(int[,,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            for (int k = 0; k < inArray.GetLength(2); k++)
            {
                Console.Write($"{inArray[i, j, k]}\t ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

bool CheckMulty(int a, int b, int c, int multy)
{
    if (a * b * c > multy)
    {
        return false;
    }
    else return true;
}

void Main()
{
    Console.Clear();
    Console.Write("Программа выведет послойно каждую глубину 3-х мерного массива.\nВведите кол-во строк: ");
    int row = int.Parse(Console.ReadLine()!);
    Console.Write("Введите кол-во столбцов: ");
    int col = int.Parse(Console.ReadLine()!);
    Console.Write("Введите глубину: ");
    int depth = int.Parse(Console.ReadLine()!);
    if (CheckMulty(row, col, depth, 89))
    {
        int[,,] ourArray = GetArray3D(row, col, depth, 10, 99);
        System.Console.WriteLine();
        PrintArray(ourArray);
    }
    else
    {
        System.Console.WriteLine("Массив таких размеров невозможно заполниь уникальными FF значениями");
    }
}

Main();