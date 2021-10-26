namespace NET02._3
{
    public interface IListener
    {
        string Path { get; set; }
        Level Level { get; set; }
        void Write(string message, Level level);
    }
}
