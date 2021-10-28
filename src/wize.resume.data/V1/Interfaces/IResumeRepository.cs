using System;
using System.Collections.Generic;
using System.Text;
using wize.resume.data.V1.Models;
using wize.common.use.repository.Interfaces;
using System.Threading.Tasks;

namespace wize.resume.data.V1.Interfaces
{
    public interface IResumeRepository : IRepositoryBase<Guid, Resume>
    {
        Task<Resume> GetResumeCompleteAsync(Guid id);
    }
}
