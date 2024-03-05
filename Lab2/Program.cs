namespace Lab2
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Лабораторная работа №2. Выполнил студент 6103-020302D группы Фокин Евгений");

            RunMenu(new Dictionary<string, Action>{
                {"Работа с классом ArrayVector", () => {
                    Console.WriteLine("Введите значения вектора через пробел");
                    var vectorElems = Console.ReadLine()!.Trim().Split(" ").Select((el) => int.Parse(el)).ToArray();
                    var vector = new ArrayVector(vectorElems.Length);

                    for(int i = 0; i < vectorElems.Length; i++) {
                        vector[i] = vectorElems[i];
                    }

                    Console.WriteLine("Модуль вектора: " + vector.GetNorm());
                    Console.WriteLine("Размерность вектора: ", vector.Length);

                    Console.WriteLine("Введите индекс элемента, который хотите получить");
                    var index = int.Parse(Console.ReadLine()!);
                    RunWithCatch("Элемент с индексом " + index + ": ", () => vector[index]);

                    Console.WriteLine("Введите индекс элемента, который хотите изменить");
                    index = int.Parse(Console.ReadLine()!);

                    RunWithCatch("Найден элемент с индексом " + index + ": ", () => vector[index]);

                    Console.WriteLine("Введите значение (целое число), на которое хотите изменить");
                    var value = int.Parse(Console.ReadLine()!);

                    RunWithCatch("Значение изменено, теперь вектор выглядит так: ", () => {
                        vector[index] = value;
                        return vector;
                    });
                }},

                {"Работа с классом Vectors", () => {
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

                    RunWithCatch("Сумма векторов: ", () => Vectors.Sum(vector, vector2));
                    RunWithCatch("Скалярное произведение: ", () => Vectors.Scalar(vector, vector2));
                }},

                {"Работа с классом LinkedListVector", () => {
                    Console.Write("Введите размерность: ");
                    int size = int.Parse(Console.ReadLine()!);
                    var list = new LinkedListVector(size);
                    Console.WriteLine("Список: " + list);

                    RunMenu(new Dictionary<string, Action> {
                        {"Вывести список и размерность", () => {
                            Console.WriteLine("Список: " + list );
                            Console.WriteLine("Размерность: " + list.Length);
                        }},
                        {"Вставить в начало", () => {
                            Console.Write("Введите число, которое вставить: ");
                            int num = int.Parse(Console.ReadLine()!);
                            list.InsertStart(num);
                            Console.WriteLine("Список: " + list);
                            Console.WriteLine("Размерность списка: " + list.Length);
                        }},

                        {"Удалить из начала", () => {
                            list.DeleteStart();
                            Console.WriteLine("Список: " + list);
                            Console.WriteLine("Размерность списка: " + list.Length);
                        }},

                        {"Вставить в конец", () => {
                            Console.Write("Введите число, которое вставить: ");
                            int num = int.Parse(Console.ReadLine()!);
                            list.InsertEnd(num);
                            Console.WriteLine("Список: " + list);
                            Console.WriteLine("Размерность списка: " + list.Length);
                        }},

                        {"Удалить из конца", () => {
                            list.DeleteEnd();
                            Console.WriteLine("Список: " + list);
                            Console.WriteLine("Размерность списка: " + list.Length);
                        }},

                        {"Вставить по индексу", () => {
                            Console.Write("Введите индекс: ");
                            var index = int.Parse(Console.ReadLine()!);

                            Console.WriteLine("Найден элемент с индексом " + index + ": " + list[index]);

                            Console.Write("Введите значение (целое число): ");
                            var value = int.Parse(Console.ReadLine()!);
                            list.InsertByIndex(index, value);

                            Console.WriteLine("Вставка произошла успешно, новый список: " + list);
                        }},

                        {"Удалить по индексу", () => {
                            Console.Write("Введите индекс: ");
                            var index = int.Parse(Console.ReadLine()!);
                            list.DeleteByIndex(index);
                            Console.WriteLine("Удаление произошла успешно, новый список: " + list);
                        }},

                        {"Модуль списка", () => {
                            Console.WriteLine("Модуль списка: " + list.GetNorm());
                        }},

                        {"Получить элемент по индексу", () => {
                            Console.Write("Введите индекс элемента, который хотите получить: ");
                            int index = int.Parse(Console.ReadLine()!);
                            RunWithCatch("Элемент с индексом " + index + ": ", () => list[index]);
                        }},

                        {"Изменить элемент по индексу", () => {
                            Console.WriteLine("Введите индекс элемента, который хотите изменить");
                            var index = int.Parse(Console.ReadLine()!);

                            Console.WriteLine("Найден элемент с индексом " + index + ": " + list[index]);

                            Console.WriteLine("Введите значение (целое число), на которое хотите изменить");
                            var value = int.Parse(Console.ReadLine()!);

                            list[index] = value;

                            Console.WriteLine("Значение изменено, теперь список выглядит так: " + list);
                        }}
                    });
                }},
            });
        }

        private static void RunMenu(Dictionary<string, Action> menuActions)
        {
            while (true)
            {
                Console.WriteLine("\nВыберите один из пунтов меню");
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
                    try
                    {
                        menuActions.ElementAt(actionIndex - 1).Value();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Ошибка: индекс вышел за переделы");

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Ошибка: " + e.Message);
                    }
                }
            }
        }

        private static void RunWithCatch(string message, Func<object> action)
        {
            try
            {
                var actionResult = action();
                Console.WriteLine(message + actionResult);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Ошибка: индекс вышел за переделы");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }
    }
}