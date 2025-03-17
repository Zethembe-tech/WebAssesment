using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CommonDLL.DTO
{
    public class AccountViewModel
    {
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
        public SelectList PersonList { get; set; }
        public SelectList AccountList { get; set; }

        public ICollection<Transactions> Transactions { get; set; }
    }
}
