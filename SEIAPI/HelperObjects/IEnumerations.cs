
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace SEIAPI.HelperObjects
{
    public enum ApplicantAppliedFor : byte
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
   
    public static class Hashing
    {
        public static string ComputeHash(this string input)
        {
            using (var sha = new SHA512Managed())
            {
                var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(input.ToLower()));
                var sb = new StringBuilder();
                foreach (var item in hash)
                {
                    sb.Append(item.ToString("x2"));
                }
                return sb.ToString().ToLower();
            }
        }
    }
    public static class UniqueNames
    {
        public static async Task<string> UniqueID(this SEIAPI.Models.ApplicantRegistration applicant)
        {
            
            return await Task.Factory.StartNew(() =>
             {
                 char[] applicantcredentials = (applicant.Fname + applicant.Lname + applicant.Email + applicant.DOB).ToCharArray();
                 //char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
                 byte[] data = new byte[8];
                 using (var random = new RNGCryptoServiceProvider())
                 {
                     random.GetBytes(data);
                 }
                 StringBuilder sb = new StringBuilder();
                 foreach (var item in data)
                 {
                     sb.Append(applicantcredentials[item % (applicantcredentials.Length)]);
                 }
                 return sb.ToString();
             });
            
        }
    }
    
}
