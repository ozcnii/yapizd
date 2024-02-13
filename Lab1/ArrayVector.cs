namespace Lab1
{
    public class ArrayVector
    {
        private int[] vector;

        public int Length
        {
            get
            {
                return vector.Length;
            }
        }

        public ArrayVector()
        {
            vector = new int[5];
        }

        public ArrayVector(int size)
        {
            if (size < 1)
            {
                throw new Exception("Размерность не может быть отрицательной");
            }

            vector = new int[size];
        }

        public int this[int index]
        {
            get
            {
                return vector[index];
            }
            set
            {
                vector[index] = value;
            }
        }

        public double GetNorm()
        {
            int sum = 0;
            foreach (int el in vector)
            {
                sum += el * el;
            }
            return Math.Sqrt(sum);
        }

        public int SumPositivesFromChetIndex()
        {
            int sum = 0;
            for (int i = 1; i < vector.Length; i += 2)
            {
                if (vector[i] > 0)
                {
                    sum += vector[i];
                }
            }

            if (sum == 0)
            {
                throw new Exception("Не найдено ни одного положительного элемента с чётным номером");
            }

            return sum;
        }

        public int SumLessFromNechetIndex()
        {
            int normSum = 0;

            foreach (int el in vector)
            {
                normSum += Math.Abs(el);
            }

            double averageNormSum = normSum / vector.Length;

            int totalSum = 0;

            for (int i = 0; i < vector.Length; i += 2)
            {
                if (vector[i] < averageNormSum)
                {
                    totalSum += vector[i];
                }
            }

            if (totalSum == 0)
            {
                throw new Exception("Не найдено ни одного элемента с нечётным номером, который бы был меньше среднего значения всех модулей элементов массива");
            }

            return totalSum;
        }

        public int MulChet()
        {
            int result = 1;
            bool isError = true;

            foreach (int el in vector)
            {
                if ((el % 2 == 0) && el > 0)
                {
                    result *= el;
                    isError = false;
                }
            }

            if (isError)
            {
                throw new Exception("Не найдено ни одного чётного положительного элемента");
            }

            return result;
        }

        public int MulNechet()
        {
            int result = 1;
            bool isError = true;

            foreach (int el in vector)
            {
                if (el % 2 != 0 && el % 3 != 0)
                {
                    result *= el;
                    isError = false;
                }
            }

            if (isError)
            {
                throw new Exception("Не найдено ни одного нечётного элемента, не делящегося на три");
            }

            return result;
        }

        public int[] SortUp()
        {
            return Sort();
        }

        public int[] SortDown()
        {
            return Sort(false);
        }

        private int[] Sort(bool asc = true)
        {
            var clone = (int[])this.vector.Clone();
            Array.Sort(clone);

            if (!asc)
            {
                Array.Reverse(clone);
            }

            return clone;
        }
    }
}