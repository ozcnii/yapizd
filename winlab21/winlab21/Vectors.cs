using System;

namespace winlab21
{
    internal class Vectors
    {
        public static ArrayVector Sum(ArrayVector vector1, ArrayVector vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new Exception("Размерность векторов не совпадает!");
            }
            ArrayVector sum = new ArrayVector(vector1.Length);
            for (int i = 0; i < vector1.Length; i++)
            {
                sum[i] = vector1[i] + vector2[i];
            }
            return sum;
        }

        public static double Scalar(ArrayVector vector1, ArrayVector vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new FormatException("Размерность векторов не совпадает!");
            }
            double scalar = 0;
            for (int i = 0; i < vector1.Length; i++)
            {
                scalar += vector1[i] * vector2[i];
            }
            return scalar;
        }

        public static ArrayVector MultNumber(ArrayVector vector, int number)
        {
            ArrayVector multNumber = new ArrayVector(vector.Length);
            for (int i = 0; i < vector.Length; i++)
            {
                multNumber[i] = vector[i] * number;
            }
            return multNumber;
        }

        public static double GetNormSt(ArrayVector vector)
        {
            return vector.GetNorm();
        }
    }
}