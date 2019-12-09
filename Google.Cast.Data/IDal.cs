namespace Google.Cast.Data
{
    public interface IDal
    {
        void CreateTable();
        void DeleteData();
        string GetPlayer();
        void InsertData();
        void ReadData();
        void UpdatePlayer(string player);
    }
}