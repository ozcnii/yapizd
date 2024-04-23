using System;

namespace winlab21
{
    internal class ArrayVector
    {
        public int[] vector;

        public ArrayVector(int size)
        {
            if (size < 1)
            {
                throw new Exception("Размерность вектора должна быть больше нуля!");
            }
            vector = new int[size];
        }

        public int Length
        {
            get
            {
                return vector.Length;
            }
        }

        public ArrayVector() // конструктор без параметра
        {
            vector = new int[5];
        }

        public int this[int i] // индексатор
        {
            get
            {
                return vector[i];
            }
            set
            {
                vector[i] = value;
            }
        }

        public double GetNorm() // метод получения модуля вектора
        {
            int temp = 0;
            foreach (int i in vector)
            {
                temp += i * i;
            }
            return Math.Sqrt(temp);
        }

        public int SumPositivesFromChetIndex()
        {
            int sumPositives = 0;
            for (int i = 1; i < vector.Length; i += 2) // чётные по номерам, а не по индексам, начиная со второго элемента
            {
                if (vector[i] > 0)
                {
                    sumPositives += vector[i];
                }
            }
            if (sumPositives == 0)
            {
                throw new Exception("Нет положительных элементов с чётным номером!");
            }
            return sumPositives;
        }

        public int SumLessFromNechetIndex()
        {
            int sumLess = 0;
            foreach (int i in vector)
            {
                sumLess += Math.Abs(i);
            }
            double sumAverage = sumLess / vector.Length;
            int sum = 0;
            for (int i = 0; i < vector.Length; i += 2)
            {
                if (vector[i] < sumAverage)
                {
                    sum += vector[i];
                }
            }
            if (sum == 0)
            {
                throw new Exception("Нет элементов с нечётным номером, которые были бы меньше среднего значения всех модулей элементов массива!");
            }
            return sum;
        }

        public int MultChet()
        {
            int multChet = 1;
            bool isError = true;

            foreach (int i in vector)
            {
                if ((i % 2 == 0) && i > 0)
                {
                    multChet *= i;
                    isError = false;
                }
            }

            if (isError)
            {
                throw new Exception("Нет положительных чётных элементов!");
            }
            return multChet;
        }

        public int MultNechet()
        {
            int multNechet = 1;
            bool isError = true;

            foreach (int i in vector)
            {
                if (i % 2 != 0 && i % 3 != 0)
                {
                    multNechet *= i;
                    isError = false;
                }
            }

            if (isError)
            {
                throw new Exception("Нет нечётных элементов, не делящихся на три!");
            }
            return multNechet;
        }

        public void SortUp()
        {            
            Array.Sort(vector);
        }

        public void SortDown()
        {            
            Array.Sort(vector);
            Array.Reverse(vector);
        }

        public void PrintArray()
        {
            Console.Write("{ ");
            for (int i = 0; i < vector.Length; i++)
            {
                Console.Write(vector[i]);
                if (i < vector.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(" }");
        }
        public override string ToString()
        {
            string result = "{ ";
            for (int i = 0; i < vector.Length; i++)
            {
                result += vector[i];
                if (i < vector.Length - 1)
                {
                    result += ", ";
                }
            }
            return result + " }";
        }
    }
}