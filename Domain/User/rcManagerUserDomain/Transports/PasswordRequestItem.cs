namespace rcManagerUserDomain.Transports
{
    public class PasswordRequestItem
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Confirmation { get; set; }
        public long User_Id { get; set; }
    }
}
