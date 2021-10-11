namespace NET01._1.Versions
{
    interface IVersionable
    {
        byte [] GetVersion();
        void SetVersion(byte [] version);
    }
}
