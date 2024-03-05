namespace Lab2
{
    public class Vectors
    {
        public static ArrayVector Sum(ArrayVector vector1, ArrayVector vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new FormatException("Размерность векторов должна быть одинаковой");
            }

            var result = new ArrayVector(vector1.Length);

            for (int i = 0; i < vector1.Length; i++)
            {
                result[i] = vector1[i] + vector2[i];
            }

            return result;
        }

        public static double Scalar(ArrayVector vector1, ArrayVector vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new FormatException("Размерность векторов должна быть одинаковой");
            }

            double result = 0;

            for (int i = 0; i < vector1.Length; i++)
            {
                result += vector1[i] * vector2[i];
            }

            return result;
        }

        public static double GetNormSt(ArrayVector vector)
        {
            return vector.GetNorm();
        }
    }
}