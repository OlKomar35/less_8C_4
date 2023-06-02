// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
//Напишите программу, которая будет построчно выводить массив,
// добавляя индексы каждого элемента.
//Массив размером 2 x 2 x 2
//66(0,0,0) 27(0,0,1) 25(0,1,0)  90(0,1,1)
//34(1,0,0) 26(1,0,1) 41(1,1,0)  55(1,1,1)

//!!!! мое виденье построчного вывода такое, размерность массива 2*2*2, следовательно 
//строки 2, а не 4, как в примере в задании, все элементы с одинаковым индексом строки
//расположены в одном ряду 


int[,,] CreateArray(int m, int n, int k, int start, int finish)
{
    int[] arrRandom = new int[m * n * k];
    int t = 0;
    while (t < arrRandom.Length)
    {
        Random random = new Random();
        int num = random.Next(start, finish + 1);
        if (!arrRandom.Contains(num))
        {
            arrRandom[t] = num;
            t++;  
        }
    }
 
    int f = 0;
    int[,,] array = new int[m, n, k];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            for (int l = 0; l < k; l++)
            {
                array[i, j, l] = arrRandom[f];
                f++;
            }
        }
    }
    return array;
}


void PrintArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int l = 0; l < array.GetLength(2); l++)
            {
                Console.Write($"{array[i, j, l]} ({i},{j},{l}) ");
            }
        }
        Console.WriteLine();
    }
}


Console.Write("Введите количество строк массива  m= ");
int m = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов массива n= ");
int n = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите третью размерность массива k= ");
int k = Convert.ToInt32(Console.ReadLine());
bool isSelect = true;
int start = 0;
int finish = 0;
while (isSelect)
{
    Console.Write("Введите начало диапозона start = ");
    start = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите окончание диапазона finish= ");
    finish = Convert.ToInt32(Console.ReadLine());
    if (start >= 10 && start < 100 && finish >= 10 && finish < 100)
    {
        isSelect = false;
        if (finish < start)
        {
            int temp = finish;
            finish = start;
            start = temp;
        }
    }
    else
    {
        isSelect = true;
        Console.WriteLine("Заполнять массив нужно двузначными числами");
    }
}

PrintArray(CreateArray(m, n, k, start, finish));


