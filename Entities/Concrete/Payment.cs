using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string CustomerName { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string CardPassword { get; set; }
    }
}