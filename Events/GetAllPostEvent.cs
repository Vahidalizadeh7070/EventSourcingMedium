using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class GetAllPostEvent : Event
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }
}
