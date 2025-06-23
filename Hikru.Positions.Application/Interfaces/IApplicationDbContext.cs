using Hikru.Positions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Hikru.Positions.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Position> Positions { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
