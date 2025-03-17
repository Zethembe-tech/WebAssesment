using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDLL.DTO;

namespace CommonDLL.DTO
{
    public class Persons
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Identity Number")]

        public string IdNumber { get; set; }

        public ICollection<Accounts> Accounts { get; set; }
    }
}
