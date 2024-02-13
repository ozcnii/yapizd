using Lab1;

class Program
{

    public static void Main()
    {
        Console.WriteLine("Лабораторная работа №1. Выполнил студент 6103-020302D группы Фокин Евгений");

        RunMenu(new Dictionary<string, Action> {
            {"Работа с класом ArrayVector", () => {
                Console.WriteLine("Введите значения вектора через пробел");
                var vectorElems = Console.ReadLine()!.Trim().Split(" ").Select((el) => int.Parse(el)).ToArray();
                var vector = new ArrayVector(vectorElems.Length);

                for(int i = 0; i < vectorElems.Length; i++) {
                    vector[i] = vectorElems[i];
                }

                Console.WriteLine("Модуль вектора: " + vector.GetNorm());

                RunWithCatch("Сумма всех положительных элементов массива с четными номерами: ", vector.SumPositivesFromChetIndex);
                RunWithCatch("Сумма элементов с нечётными номерами, которые меньше среднего значения всех модулей элементов: ", vector.SumLessFromNechetIndex);
                RunWithCatch("Произведение всех четных положительных элементов: ", vector.MulChet);
                RunWithCatch("Произведение всех нечетных элементов, не делящихся на три: ", vector.MulNechet);

                Console.Write("Сортировка по возрастанию: ");
                PrintArray(vector.SortUp());

                Console.Write("Сортировка по убыванию: ");
                PrintArray(vector.SortDown());
            }},
            {"Работа с класом Vectors", () => {
                Console.WriteLine("Введите значения вектора через пробел");
                var vectorElems = Console.ReadLine()!.Trim().Split(" ").Select((el) => int.Parse(el)).ToArray();
                var vector = new ArrayVector(vectorElems.Length);

                for(int i = 0; i < vectorElems.Length; i++) {
                    vector[i] = vectorElems[i];
                }

                Console.WriteLine("Введите значения вектора через пробел");
                var vectorElems2 = Console.ReadLine()!.Trim().Split(" ").Select((el) => int.Parse(el)).ToArray();
                var vector2 = new ArrayVector(vectorElems.Length);

                for(int i = 0; i < vectorElems2.Length; i++) {
                    vector2[i] = vectorElems2[i];
                }

                try {
                    Console.WriteLine("Сумма векторов: " + Vectors.Sum(vector, vector2));
                    Console.WriteLine("Скалярное произведение: " + Vectors.Scalar(vector, vector2));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Введите число для на которое нужно умножить первый вектор: ");
                var n = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Умножение первого вектора на число: " + Vectors.MultNumber(vector, n));
            }}
        });
    }

    private static void RunMenu(Dictionary<string, Action> menuActions)
    {
        while (true)
        {
            Console.WriteLine("Выберите один из пунтов меню");
            Console.WriteLine("0 - Осознанное завершение");

            for (int index = 0; index < menuActions.Count; index++)
            {
                var item = menuActions.ElementAt(index);
                Console.WriteLine($"{index + 1} - {item.Key}");
            }

            string menuAction = Console.ReadLine()!.Trim();
            bool parsed = int.TryParse(menuAction, out int actionIndex);

            if (!parsed || 0 > actionIndex || actionIndex > menuActions.Count)
            {
                Console.WriteLine("Не выбран ни один пункт меню\n");
                continue;
            }
            else if (actionIndex == 0)
                return;
            else
            {
                menuActions.ElementAt(actionIndex - 1).Value();
            }
        }
    }

    private static void RunWithCatch(string message, Func<int> action)
    {
        try
        {
            var actionResult = action();
            Console.WriteLine(message + actionResult);
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
        }
    }

    private static void PrintArray(int[] array)
    {
        Console.Write("{ ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i]);
            if (i < array.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine(" }");
    }
}