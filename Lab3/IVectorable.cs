namespace Lab3
{
    public interface IVectorable
    {
        int this[int index] { get; set; }
        int Length { get; }
        double GetNorm();
    }
}
