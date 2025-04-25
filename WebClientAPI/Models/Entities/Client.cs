using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientAPI.Models.Entities
{
    public class Client
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual char Gender { get; set; }
    }
}