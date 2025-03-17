using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDLL.DTO
{
    public class Accounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }

        [Required]
        [Display(Name = "Person Code")]
        public int PersonCode { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Display(Name = "Outstanding Balance")]
        public decimal OutstandingBalance { get; set; }
        public string Status { get; set; }

        [ForeignKey("PersonCode")]
        public Persons Person { get; set; }

        public ICollection<Transactions> Transactions { get; set; }
    }
}
