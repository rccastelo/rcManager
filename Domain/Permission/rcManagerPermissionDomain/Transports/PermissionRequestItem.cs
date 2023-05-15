using System;

namespace rcManagerPermissionDomain.Transports
{
    public class PermissionRequestItem
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
    }
}
