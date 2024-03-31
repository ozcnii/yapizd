using System.Text;

namespace Lab6
{
    public class Vectors
    {
        public static IVectorable Sum(IVectorable vector1, IVectorable vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new FormatException("Размерность векторов должна быть одинаковой");
            }

            ArrayVector result = new ArrayVector(vector1.Length);

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

        public static void OutputVectors(IVectorable[] vectors, Stream stream)
        {
            for (int i = 0; i < vectors.Length; i++)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(vectors[i].ToString() + "\n");
                stream.Write(buffer, 0, buffer.Length);
            }
        }

        public static IVectorable[] InputVectors(Stream stream)
        {
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return ParseVectors(Encoding.UTF8.GetString(buffer));
        }

        public static void WriteVectors(IVectorable[] vectors, TextWriter writer)
        {
            for (int i = 0; i < vectors.Length; i++)
            {
                writer.WriteLine(vectors[i]);
            }
        }

        public static IVectorable[] ReadVectors(TextReader reader)
        {
            string vectorsString = reader.ReadToEnd();
            return ParseVectors(vectorsString);
        }

        private static IVectorable[] ParseVectors(string vectorsStr)
        {
            vectorsStr = vectorsStr.Trim();
            string[] vectorsStrArr = vectorsStr.Split("\n");

            IVectorable[] vectors = new IVectorable[vectorsStrArr.Length];

            for (int i = 0; i < vectorsStrArr.Length; i++)
            {
                string[] vectorStrArr = vectorsStrArr[i].Trim().Split();
                int size = int.Parse(vectorStrArr[0]);
                IVectorable vector = new ArrayVector(size);

                for (int j = 1; j < vectorStrArr.Length; j++)
                {
                    vector[j] = int.Parse(vectorStrArr[j]);
                }

                vectors[i] = vector;
            }

            return vectors;
        }
    }
}