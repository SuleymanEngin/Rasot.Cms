using Microsoft.EntityFrameworkCore;
using Rasot.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rasot.Data
{
    public interface IRasotDbContext
    {
        DbSet<T> Set<T>() where T : BaseEntity;
    }
}
