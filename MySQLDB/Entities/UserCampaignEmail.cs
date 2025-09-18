//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace MySQLDB.Entities
//{
//    [Table("UserCampaignEmail")]
//    public class UserCampaignEmail : CrudEntity
//    {
//        [Required]
//        public string FileName { get; set; }

//        [Required]
//        public string FolderName { get; set; }

//        public string? FullPath { get; set; }

//        [Required]
//        public string Status { get; set; }

//        public string? ErrorMessage { get; set; }

//        [Required]
//        public int UserCampaignId { get; set; }

//        public int? PreviousUserCampaignEmailId { get; set; }

//        public UserCampaign UserCampaign { get; set; }

//        public UserCampaignEmail PreviousUserCampaignEmail { get; set; }
//    }
//}