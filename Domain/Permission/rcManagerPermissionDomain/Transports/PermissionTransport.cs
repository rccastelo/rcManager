using System;

namespace rcManagerPermissionDomain.Transports
{
    public class PermissionTransport
    {
        public long Id { get; set; }
        public long User_Id { get; set; }
        public long System_Id { get; set; }
        public bool Status { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool Weekday { get; set; }
        public bool Weekend { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public PermissionTransport() { }

        public PermissionTransport(PermissionTransport transport)
        {
            if (transport != null)
            {
                this.Id = transport.Id;
                this.User_Id = transport.User_Id;
                this.System_Id = transport.System_Id;
                this.DateFrom = transport.DateFrom;
                this.DateTo = transport.DateTo;
                this.Status = transport.Status;
                this.Weekday = transport.Weekday;
                this.Weekend = transport.Weekend;
                this.StartTime = transport.StartTime;
                this.EndTime = transport.EndTime;
            }
        }
    }
}
