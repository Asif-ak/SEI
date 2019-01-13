using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SEIAPI.HelperObjects;

namespace SEIAPI.Models
{

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
        public string CNICHash { get; set; }
        [Required]
        public ApplicantAppliedFor ApplicantAppliedFor { get; set; }
        [Required]
        public ApplicantStatus ApplicantStatus { get; set; }
        [Required,EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }
        [Required,DataType(DataType.Date)]
        public string DOB { get; set; }

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
        [Required]
        public string UniqueId { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public byte[] QRCode { get; set; }
        public byte[] ImageBytes { get; set; }
    }
}
