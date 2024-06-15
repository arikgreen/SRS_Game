namespace SRS_Game.Services
{
    public interface IReadableSqlFile
    {
        string LoadText();
    }
    public interface IWritableSqlFile
    {
        void SaveText();
    }

    public class SqlFileService : IWritableSqlFile, IReadableSqlFile
    {
        public required string FilePath { get; set; }
        public required string FileText { get; set; }
        public string LoadText()
        {
            /* Code to read text from sql file */
            throw new NotImplementedException();
        }
        public void SaveText()
        {
            /* Code to save text into sql file */
            throw new NotImplementedException();
        }
    }
}
