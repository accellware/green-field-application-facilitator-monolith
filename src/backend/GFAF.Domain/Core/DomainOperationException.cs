using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAF.Domain.Core
{
    public class DomainOperationException: Exception
    {
        public DomainOperationException() { }

        public DomainOperationException(string message): base(message) { }

        public DomainOperationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
