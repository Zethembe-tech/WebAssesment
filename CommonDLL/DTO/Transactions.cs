using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDLL.DTO
{
    public class Transactions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }

        [Required]
        public int AccountCode { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public DateTime CaptureDate { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [ForeignKey("AccountCode")]
        public Accounts Account { get; set; }
        public int AccountNumber { get; set; }
    }
}
