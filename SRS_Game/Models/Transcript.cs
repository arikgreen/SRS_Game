using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System.Globalization;

namespace SRS_Game.Models
{
    public class Transcript
    {
        [Required]
        [StringLength(50)]
        [DisplayName("Speaker")]
        public string Speaker { get; set; }
        
        [Required]
        [DisplayName("Message")]
        public string Message { get; set; }

        [Required]
        [DisplayName("TimeStamp")]
        public DateTime TimeStamp { get; set; }

        public Transcript() { }

        public Transcript(string speaker, string message, DateTime timeStamp)
        {
            Speaker = speaker;
            Message = message;
            TimeStamp = timeStamp;
        }

        public static string ParseTextTranscript(MemoryStream memoryStream)
        {
            memoryStream.Seek(0, SeekOrigin.Begin); // Ensure we're at the beginning
            using (var reader = new StreamReader(memoryStream))
            {
                string transcriptContent = reader.ReadToEnd();
                return transcriptContent; // Return or process the text content
            }
        }
    }
}
