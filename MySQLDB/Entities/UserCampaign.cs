using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQLDB.Entities
{
    [Table("UserCampaign")]
    public class UserCampaign : CrudEntity
    {
        public int UserId { get; set; }

        [Required]
        public int CampaignId { get; set; }

        public int? NextCampaignId { get; set; }

        public int? PreviousCampaignId { get; set; }

        public DateTime? CompletedOn { get; set; }

        public User User { get; set; }

        public Campaign Campaign { get; set; }

        public Campaign NextCampaign { get; set; }

        public Campaign PreviousCampaign { get; set; }
    }
}