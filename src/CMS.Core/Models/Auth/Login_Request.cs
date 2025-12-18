namespace CMS.Core.Models.Auth
{
    public class Login_Request
    {
        public required string UserName {  get; set; }
        public required string PassWord { get; set; }
    }
}
