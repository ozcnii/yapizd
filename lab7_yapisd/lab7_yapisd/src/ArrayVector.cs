using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    [Serializable]
    public class ArrayVector : IVectorable
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
                return vector[index - 1];
            }
            set
            {
                vector[index - 1] = value;
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
            string res = Length + "";
            for (int i = 0; i < Length; i++)
            {
                res += " " + this[i + 1];
            }
            return res;
        }

        public override bool Equals(Object obj)
        {
            IVectorable vector = obj as IVectorable;

            if (obj == null || vector.Length != Length)
            {
                return false;
            }

            for (int i = 1; i <= Length; i++)
            {
                if (vector[i] != this[i])
                {
                    return false;
                }

            }

            return true;
        }

        public int CompareTo(object other)
        {
            if (other == null)
            {
                return -1;
            }

            return Length.CompareTo((other as IVectorable).Length);
        }

        public object Clone()
        {
            ArrayVector clone = new ArrayVector(Length);

            for (int i = 1; i <= Length; i++)
            {
                clone[i] = this[i];
            }

            return clone;
        }
    }
}