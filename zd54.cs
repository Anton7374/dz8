 void Print2DArray(int[,] arrayToPrint)
 {
 Console.WriteLine();
     Console.WriteLine("\n");
     Console.WriteLine("Таблица значений:");
     for (int row = 0; row < arrayToPrint.GetLength(0); row++)
     {
        for (int column = 0; column < arrayToPrint.GetLength(1); column++)
        {
            Console.Write($"{arrayToPrint[row, column]}\t");
        }
        Console.WriteLine();
    }
}
int[,]GetFilledRandInt2DArray((int rows, int columns, int minValue, int maxValue) args)
{
    int[,] int2DArray = new int[args.rows, args.columns];
    Random randInt = new Random();
    for (int row = 0; row < int2DArray.GetLongLength(0); row++)
    {
        for (int column = 0; column < int2DArray.GetLongLength(1); column++)
        {
            int2DArray[row, column] = randInt.Next(args.minValue, args.maxValue + 1);
         }
    }
    return int2DArray;
}
int GetDefaultValues(int valueCode = -1)
{
    int defaultValue;
    switch (valueCode)
    {
        case 0: // Количество строк матрицы
            defaultValue = 3;
            break;
        case 1: // Количество столбцов матрицы
            defaultValue = 3;
            break;
        case 2: // Минимальное значение заполнения
            defaultValue = -10;
            break;
        case 3: // Максимальное значение заполнения
            defaultValue = 10;
            break;
        default:
            defaultValue = 0;
            break;
    }
    return defaultValue;
}
int[,] SetingsMenu()
{
    int[,] userConfiguredArray;
    (int rows, int columns, int min, int max) userInputs = (GetDefaultValues(0), 
                                                            GetDefaultValues(1),
                                                            GetDefaultValues(2),
                                                            GetDefaultValues(3));
    Console.Write("Настроить создаваемый двумерный массив?\n(Y for Yes, Any key for No)\n>>> ");
    switch (Console.ReadKey().Key)
    {
        case ConsoleKey.Y:
        Console.WriteLine();
            Console.Write("Введите количество строк двумерного массива:\n>>> ");
            bool rowsValid = int.TryParse(Console.ReadLine()!, out userInputs.rows);
            if (!rowsValid)
            {
                userInputs.rows = GetDefaultValues(0);
                Console.WriteLine("Не удалось преобразовать введенное количество строк к числу.\n"
                                + $"Будет использовано значение по умолчанию –> {userInputs.rows}");
            }
            Console.Write("Введите количество столбцов двумерного массива:\n>>> ");
            bool columnsValid = int.TryParse(Console.ReadLine()!, out userInputs.columns);
            if (!columnsValid)
            {
                userInputs.columns = GetDefaultValues(1);
                Console.WriteLine("Не удалось преобразовать введенное количество столбцов к числу.\n"
                                + $"Будет использовано значение по умолчанию –> {userInputs.columns}");
            }
            Console.Write("Введите минимальное значение для заполнения двумерного массива:\n>>> ");
            bool minValid = int.TryParse(Console.ReadLine()!, out userInputs.min);
            if (!minValid)
            {
                userInputs.min = GetDefaultValues(2);
                Console.WriteLine("Не удалось преобразовать введенное минимальное значение для заполнения к числу.\n"
                                + $"Будет использовано значение по умолчанию –> {userInputs.min}");
            }
            Console.Write("Введите максимальное значение для заполнения двумерного массива:\n>>> ");
            bool maxValid = int.TryParse(Console.ReadLine()!, out userInputs.max);
            if (!maxValid)
            {
                userInputs.max = GetDefaultValues(3);
                Console.WriteLine("Не удалось преобразовать введенное максимальное значение для заполнения к числу.\n"
                                + $"Будет использовано значение по умолчанию –> {userInputs.max}");
            }
            userConfiguredArray = GetFilledRandInt2DArray(userInputs);
            break;
        default:
            userConfiguredArray = GetFilledRandInt2DArray(userInputs);
            break;
    }
    return userConfiguredArray;
}
void Main()
{
    int[,] usersArray = SetingsMenu();
    Print2DArray(usersArray);
    SortOneDimensionOfNDimensionArray(usersArray);
    Print2DArray(usersArray);
}
Main();
