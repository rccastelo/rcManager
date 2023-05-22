using System;

namespace rcManagerSystemDomain.Transports
{
    public class SystemRequestItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string Key { get; set; }
    }
}
