using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace SRS_Game.Models
{
    public enum FileSourceTypes
    {
        MSTEAMS, ZOOM
    }
    
    public class ChatHistoryFile
    {
        public int Id {  get; set; }
        public int DocumentId { get; set; }
        public byte[] FileData {  get; set; } 
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Type of source chat history file
        /// </summary>
        public FileSourceTypes FileSourceType { get; set; }

        public ChatHistoryFile() { }

        public ChatHistoryFile(int documentId, byte[] fileData, FileSourceTypes fileSourceType) {
            DocumentId = documentId;
            FileData = fileData;
            FileSourceType = fileSourceType;
        }
    }
}
