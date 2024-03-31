namespace Lab6
{
    public class VectorAscComparer : IComparer<IVectorable>
    {
        public int Compare(IVectorable? vector1, IVectorable? vector2)
        {
            if (vector1 == null || vector2 == null)
            {
                return -1;
            }
            return vector1.GetNorm().CompareTo(vector2.GetNorm());
        }
    }
}