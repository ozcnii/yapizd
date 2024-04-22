using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public interface IVectorable : IComparable, ICloneable
    {
        int this[int index] { get; set; }
        int Length { get; }
        double GetNorm();
    }
}
