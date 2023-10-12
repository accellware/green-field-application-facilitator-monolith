using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFAF.Domain.Repositories.Core
{
    public interface IUnitOfWork: IDisposable
    {
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
