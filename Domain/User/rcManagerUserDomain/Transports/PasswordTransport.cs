namespace rcManagerUserDomain.Transports
{
    public class PasswordTransport
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Confirmation { get; set; }
        public long User_Id { get; set; }

        public PasswordTransport() { }

        public PasswordTransport(PasswordTransport transport)
        {
            if (transport != null)
            {
                this.Id = transport.Id;
                this.Login = transport.Login;
                this.User_Id = transport.User_Id;
                this.Password = transport.Password;
                this.Confirmation = transport.Confirmation;
            }
        }
    }
}
