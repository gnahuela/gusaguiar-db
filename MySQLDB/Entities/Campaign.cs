using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySQLDB.Entities
{
    [Table("Campaign")]
    public class Campaign : CrudEntity
    {
        [Required]
        public string FolderName { get; set; }

        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Para diferenciar de donde viene (niveles, afirmaciones, nostalgia)
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// A las horas que se envía la campaña (00,24)
        /// </summary>
        [Required]
        public string Hours { get; set; }

        /// <summary>
        /// Los días que se envía la campaña (MO,TU,WE,TH,FR,SA,SU)
        /// </summary>
        [Required]
        public string Days { get; set; }

        /// <summary>
        /// Solo si este valor esta seteado debería iniciarse una campaña
        /// </summary>
        public DateTime? InitiateOn { get; set; }

        /// <summary>
        /// Para campañas que no deberían iniciarse a partir de una fecha
        /// </summary>
        public DateTime? DisableOn { get; set; }

        /// <summary>
        /// Solo correra la newsletter del día actual si es true
        /// </summary>
        public bool CurrentDayOnly { get; set; }

        [ForeignKey(nameof(NextCampaign))]
        public int? NextCampaignId { get; set; }

        [ForeignKey(nameof(PreviousCampaign))]
        public int? PreviousCampaignId { get; set; }

        public Campaign NextCampaign { get; set; }

        public Campaign PreviousCampaign { get; set; }
    }
}