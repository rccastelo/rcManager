using System;

namespace rcManagerSystemDomain.Transports
{
    public class SystemResponseItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Key { get; set; }
    }
}
