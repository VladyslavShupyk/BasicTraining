namespace NET03._1
{
    class IDGenerator
    {
        private static IDGenerator instance;
        private int Id;
        private IDGenerator()
        {
            Id = 1;
        }
        public static IDGenerator GetInstance()
        {
            if(instance == null)
            {
                instance = new IDGenerator();
            }
            return instance;
        }
        public int GetId()
        {
            return Id++;
        }
    }
}
