using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace SEIAPI.Models
{
    public class Enumerations
    {
        public enum ApplicantAppliedFor:byte
        {
            student,
            staff
        }
        public enum ApplicantStatus : byte
        {
            pending,
            student,
            staff
        }
    }
    [Table("A")]
    public class ApplicantRegistration
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required,MaxLength(15,ErrorMessage ="First Name length cannot exceed 15 characters")]
        public string Fname { get; set; }
        [Required, MaxLength(15, ErrorMessage = "Last Name length cannot exceed 15 characters")]
        public string Lname { get; set; }
        [Required,MaxLength(13,ErrorMessage ="Invalid CNIC")]
        public ulong CNIC { get; set; }
        [Required]
        public Enumerations.ApplicantAppliedFor ApplicantAppliedFor { get; set; }
        [Required]
        public Enumerations.ApplicantStatus ApplicantStatus { get; set; }

        //public string CNICHash
        //{
        //    get
        //    {
        //        return CNICHash;
        //    }
        //    private set
        //    {
        //        using (SHA512 sha1 = new SHA512Managed())
        //        {
        //            //var array = BitConverter.GetBytes(CNIC);
                    
        //            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(CNIC.ToString()));
        //            var sb = new StringBuilder(hash.Length * 2);

        //            foreach (byte b in hash)
        //            {
        //                sb.Append(b.ToString("x2")); // x2 is lowercase
        //            }
        //            value= sb.ToString().ToLower();
                    
        //        }
        //    }
        //}
    }
    [Table("B")]
    public class LoginCredentials
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

    }
}
