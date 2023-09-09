using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class GetByIdPostEvent : Event
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
