using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;

namespace SRS_Game.Models
{
    public class Attachement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Document")]
        [DisplayName("Document")]
        public int DocumentId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("File name")]
        public string FileName { get; set; }
        
        [DisplayName("Content type")]
        public string ContentType { get; set; }

        [DisplayName("File content")]
        public byte[] FileContent { get; set; } = [];

        [Required]
        [DisplayName("Create date")]
        public DateTime CreateDate { get; set; } = DateTime.MinValue;

        [Required]
        [DisplayName("Update date")]
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        [DisplayName("Is transcript")]
        public bool IsTranscript { get; set; } = false;

        public Attachement() { }

        public Attachement(int documentId, string fileName, DateTime createDate, DateTime updateDate, byte[] fileContent, string contentType, bool isTranscript = false)
        {
            DocumentId = documentId;
            FileName = fileName;
            CreateDate = createDate;
            UpdateDate = updateDate;
            ContentType = contentType;
            FileContent = fileContent;
            IsTranscript = isTranscript;
        }
    }

    public class AttachementViewModel : Attachement
    { 
        public required string Document { get; set; }
    }

    public class TranscriptParser
    {
        public string Topic { get; set; }

        public string Participants { get; set; }

        public DateTime MeetingDate { get; set; }

        public string MeetingContent { get; set; }


        public TranscriptParser(byte[] fileContent)
        {
            string transcriptContent = Encoding.ASCII.GetString(fileContent);

            Match mTopic = Regex.Match(transcriptContent, @"\*\*Topic:\*\* ([\w ]+)");

            Topic = (mTopic.Success) ? mTopic.Groups[1].ToString() : "";

            Match mDate = Regex.Match(transcriptContent, @"\*\*Date:\*\* ([\w ,]+)");
            Match mTime = Regex.Match(transcriptContent, @"\*\*Time:\*\* (\d+:\d+ [a-zA-Z]{2})");

            MeetingDate = (mDate.Success && mTime.Success) ? DateTime.Parse(mDate.Groups[1] + " " + mTime.Groups[1]) : DateTime.Now;

            Match mContent = Regex.Match(transcriptContent, @"-{3}\r*\n([\s\S]*)");

            MeetingContent = mContent.Success ? mContent.Groups[1].ToString() : string.Empty;

            MatchCollection mParticipants = Regex.Matches(transcriptContent, @"\*\*Participants:\*\*\r*\n\- ([\s\S]*\))[\r*\n]");

            var aaa = mParticipants.First().Groups[1].ToString();

            Participants = (mParticipants.Count > 0) ? Regex.Replace(mParticipants.First().Groups[1].ToString(), @"\- ", "") : "";

            //Participants = mParticipants != null ? mParticipants.Cast<Match>().Select(match => match.Groups[1].Value).ToList() : [];
        }
    }
}
