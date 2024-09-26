namespace SRS_Game.Models
{
    public enum AlertType
    {
        primary,
        secondary,
        success,
        danger,
        warning,
        info,
        light,
        dark
    }

    public class Alert
    {
        public AlertType Type { get; set; }
        public required string Text { get; set; }
    }
}
