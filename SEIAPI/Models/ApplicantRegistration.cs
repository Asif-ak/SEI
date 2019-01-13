using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;


namespace SEIAPI.Models
{
    [Table("A")]
    public class ApplicantRegistration
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required,MaxLength(15,ErrorMessage ="First Name length cannot exceed 15 characters")]
        public string fname { get; set; }
        [Required, MaxLength(15, ErrorMessage = "Last Name length cannot exceed 15 characters")]
        public string lname { get; set; }

    }
}
