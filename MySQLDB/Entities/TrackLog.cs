using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQLDB.Entities
{
    [Table("TrackLog")]
    public class TrackLog : CrudEntity
    {
        [Required]
        [MaxLength(100)]
        public string SessionId { get; set; }

        [MaxLength(200)]
        public string? Email { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Event { get; set; }

        [MaxLength(250)]
        public string? Message { get; set; }

        [MaxLength(250)]
        public string? Path { get; set; }

        [MaxLength(50)]
        public string? TrafficSource { get; set; }

        [MaxLength(100)]
        public string? NavigatorUserAgent { get; set; }

        [MaxLength(100)]
        public string? NavigatorLanguage { get; set; }

        [MaxLength(100)]
        public string? NavigatorPlatform { get; set; }

        public DateTime? FrontendTimeStamp { get; set; }

        public int? Priority { get; set; }
    }
}