namespace Lab4
{
    public class Vectors
    {
        public static IVectorable Sum(IVectorable vector1, IVectorable vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new FormatException("Размерность векторов должна быть одинаковой");
            }

            var result = new ArrayVector(vector1.Length);

            for (int i = 1; i < vector1.Length + 1; i++)
            {
                result[i] = vector1[i] + vector2[i];
            }

            return result;
        }

        public static double Scalar(IVectorable vector1, IVectorable vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new FormatException("Размерность векторов должна быть одинаковой");
            }

            double result = 0;

            for (int i = 1; i < vector1.Length + 1; i++)
            {
                result += vector1[i] * vector2[i];
            }

            return result;
        }

        public static double GetNormSt(IVectorable vector)
        {
            return vector.GetNorm();
        }
    }
}