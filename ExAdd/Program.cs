// Дополнительная задача
// https://acmp.ru/asp/do/index.asp?main=task&id_course=1&id_section=6&id_topic=116&id_problem=717

async void PrintMatrix(string[,] matrix, bool inConsole)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        string outFileName = "output.txt";
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (inConsole) Console.Write($"{matrix[i, j]}\t");
            else
            {
                bool fileAppendFlag = !inConsole && i == 0 && j == 0; //флаг перезаписывания файла - перезапись только в случае если это первая итерация обоих циклов и метод вызван для записи в файл, а не в консоль
                using (StreamWriter writer = new StreamWriter(outFileName, !fileAppendFlag))
                    await writer.WriteAsync($"{matrix[i, j]}\t");
            }
        }
        if (inConsole) Console.WriteLine();
        else
            using (StreamWriter writer = new StreamWriter(outFileName, true))
                await writer.WriteLineAsync();
    }
}

void ReverseMatrixHorizontal(string[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0) / 2; i++)               // Классический проход до середины первого измерения с заменой значений и временным сохранением в переменной
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            string tmp = matrix[i, j];                              // Сохраняем во временной переменной
            matrix[i, j] = matrix[matrix.GetLength(0) - 1 - i, j];  // Присваиваем транспонированные значения
            matrix[matrix.GetLength(0) - 1 - i, j] = tmp;           // Заполняем из временной переменной     
        }
    }
}


var sr = new StreamReader("input.txt");                             // Открываем текстовый файл, используя StreamReader
string[] dimensionalArr = sr.ReadLine().Split(' ');

string[,] matrix = new string[Convert.ToInt32(dimensionalArr[0]),   // Новая строковая матрица с размерностями из первой строки
                              Convert.ToInt32(dimensionalArr[1])];

int i = 0;
while (i < matrix.GetLength(0))                                     // Формирование матрицы из данных в файле 
{
    string[] matrixString = sr.ReadLine().Split(' ');               // Считываем строку входной матрицы в строковый массив
    for (int j = 0; j < matrixString.Length; j++)                   // Поэлементно парсим строку в матрицу
        matrix[i, j] = matrixString[j];
    i++;
}

Console.WriteLine("Входная матрица:");
PrintMatrix(matrix, true);                                          // Печатаем исходную матрицу в консоль
ReverseMatrixHorizontal(matrix);                                    // Транспонируем
Console.WriteLine("Транспонированная по горизонтали матрица:");
PrintMatrix(matrix, true);                                          // Печатаем транспонированную матрицу в консоль
PrintMatrix(matrix, false);                                         // Печатаем транспонированную матрицу в файл





