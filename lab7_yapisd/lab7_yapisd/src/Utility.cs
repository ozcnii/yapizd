using Lab5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public static class Utility
    {
        private static Random random = new Random();

        public static void FillVectorRandomValues(IVectorable vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i + 1] = random.Next(-1000, 1001);
            }
        }

        public static IVectorable[] GetRadnomVectors(int vectorSize = 5)
        {
            IVectorable vector1 = new ArrayVector(vectorSize);
            FillVectorRandomValues(vector1);
            IVectorable vector2 = new ArrayVector(vectorSize);
            FillVectorRandomValues(vector2);
            IVectorable vector3 = new LinkedListVector(vectorSize);
            FillVectorRandomValues(vector3);
            IVectorable vector4 = new LinkedListVector(vectorSize);
            FillVectorRandomValues(vector4);
            IVectorable vector5 = new ArrayVector(vectorSize);
            FillVectorRandomValues(vector5);
            IVectorable vector6 = new LinkedListVector(vectorSize);
            FillVectorRandomValues(vector6);
            IVectorable vector7 = new LinkedListVector(vectorSize);
            FillVectorRandomValues(vector7);
            return new IVectorable[]
            {
                    vector1,
                    vector2,
                    vector3,
                    vector4,
                    vector5,
                    vector6,
                    vector7
            };
        }

        public static IVectorable[] GetVectorsArray()
        {
            IVectorable vector1 = new ArrayVector(3);
            vector1[1] = -1000;
            vector1[2] = 2000;
            vector1[3] = 3000;

            IVectorable vector2 = new ArrayVector(4);
            vector2[1] = 1;
            vector2[2] = 2;
            vector2[3] = 3;
            vector2[4] = 40;

            IVectorable vector3 = new LinkedListVector(2);
            vector3[1] = 100;
            vector3[2] = 200;

            IVectorable vector4 = new LinkedListVector(7);
            vector4[1] = 1;
            vector4[2] = 2;
            vector4[3] = 3;
            vector4[4] = 4;
            vector4[5] = 5;
            vector4[6] = 6;
            vector4[7] = 7;

            IVectorable vector5 = new ArrayVector(6);
            vector5[1] = 2;
            vector5[2] = 4;
            vector5[3] = 6;
            vector5[4] = 8;
            vector5[5] = 10;
            vector5[6] = 12;

            IVectorable vector6 = new LinkedListVector(2);
            vector6[1] = 1;
            vector6[2] = 3;

            IVectorable vector7 = new LinkedListVector(7);
            vector7[1] = 1;
            vector7[2] = 3;
            vector7[3] = 5;
            vector7[4] = 7;
            vector7[5] = 9;
            vector7[6] = 11;
            vector7[7] = 13;

            return new IVectorable[]
            {
                    vector1,
                    vector2,
                    vector3,
                    vector4,
                    vector5,
                    vector6,
                    vector7
            };
        }

        public static LinkedListVector GetRandomLLV(int vectorSize = 7)
        {
            LinkedListVector vector = new LinkedListVector(vectorSize);
            FillVectorRandomValues(vector);
            return vector;
        }

        public static ArrayVector GetRandomAV(int vectorSize = 5)
        {
            ArrayVector vector = new ArrayVector(vectorSize);
            FillVectorRandomValues(vector);
            return vector;
        }

        public static void TestVectorsEquality(IVectorable[] vectors, IVectorable[] newVectors)
        {
            for (int i = 0; i < vectors.Length; i++)
            {
                if (vectors[i].Equals(newVectors[i]))
                {
                    Console.WriteLine(i + ") (+) " + "Вектор { " + newVectors[i] + " } прошел проверку методом Equals после чтения из файла");
                }
                else
                {
                    Console.WriteLine(i + ") (-) " + "Вектор { " + newVectors[i] + " } не прошел проверку методом Equals после чтения из файла");
                }
            }
        }
    }
}
