using System;
using System.Collections.Generic;
using System.Text;
using wize.resume.data.V1.Models;
using wize.common.use.repository.Interfaces;

namespace wize.resume.data.V1.Interfaces
{
    public interface IProjectRepository : IRepositoryBase<int, Project>
    {
    }
}
