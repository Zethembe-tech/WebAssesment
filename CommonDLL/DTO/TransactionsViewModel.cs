using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CommonDLL.DTO
{
    public class TransactionsViewModel
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
        public string Status { get; set; }

        [ForeignKey("AccountCode")]
        public Accounts Account { get; set; }
        public int AccountNumber { get; set; }
        public List<SelectListItem> AccountList { get; set; }
    }
}
