namespace Lab2
{
    public class ArrayVector
    {
        private int[] vector;

        public ArrayVector() : this(5) { }

        public ArrayVector(int size)
        {
            if (size < 1)
            {
                throw new Exception("Размерность не может быть отрицательной");
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

        public override string ToString()
        {
            string res = "{ ";
            for (int i = 0; i < Length - 1; i++)
            {
                res += this[i] + ", ";
            }
            return res + this[Length - 1] + " }";
        }
    }
}