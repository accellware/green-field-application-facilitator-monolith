using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAF.Domain.Events
{
    public class EventBase: INotification
    {
        public DateTime Occured { get; set; } = DateTime.UtcNow;
    }
}
