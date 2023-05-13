﻿using System;

namespace rcManagerUserDomain.Transports
{
    public class UserTransport
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public UserTransport() { }

        public UserTransport(UserTransport transport)
        {
            if (transport != null) {
                this.Id = transport.Id;
                this.Name = transport.Name;
                this.Description = transport.Description;
                this.Status = transport.Status;
                this.CreatedAt = transport.CreatedAt;
                this.UpdatedAt = transport.UpdatedAt;
            }
        }
    }
}
