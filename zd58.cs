int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]}\t ");
        }
        Console.WriteLine();
    }
}

int[,] MultiplicationArrays(int[,] arrA, int[,] arrB)
{
    int rowArrA = arrA.GetLength(0);
    int colunmArrA = arrA.GetLength(1);
    int rowArrB = arrB.GetLength(0);
    int colunmArrB = arrB.GetLength(1);

    int[,] multyArr = new int[rowArrA, colunmArrB];

    for (int i = 0; i < rowArrA; i++)
    {
        for (int j = 0; j < colunmArrB; j++)
        {
            for (int k = 0; k < rowArrB; k++)
            {
                multyArr[i, j] += arrA[i, k] * arrB[k, j];
            }
        }
    }
    return multyArr;
}

void Main()
{
    Console.Clear();
    Console.Write("Введите кол-во строк матрицы A: ");
    int rowA = int.Parse(Console.ReadLine()!);
    Console.Write("Введите кол-во столбцов матрицы A: ");
    int colA = int.Parse(Console.ReadLine()!);

    Console.Write("Введите кол-во строк матрицы B: ");
    int rowB = int.Parse(Console.ReadLine()!);
    Console.Write("Введите кол-во столбцов матрицы B: ");
    int colB = int.Parse(Console.ReadLine()!);

    if (colA != rowB)
    {
        System.Console.WriteLine("Произведение матриц невозможно");
        return;
    }
    System.Console.WriteLine("\nМатрица A:\n");
    int[,] arrayA = GetArray(rowA, colA, 1, 5);
    PrintArray(arrayA);
    System.Console.WriteLine("\nМатрица B:\n");
    int[,] arrayB = GetArray(rowB, colB, 5, 9);
    PrintArray(arrayB);
    System.Console.WriteLine("\nМатрица AB:\n");
    PrintArray(MultiplicationArrays(arrayA, arrayB));

}

Main();