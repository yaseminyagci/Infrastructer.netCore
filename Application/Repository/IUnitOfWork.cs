using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IUnitOfWork 
    {
        Task complateSaveAsync();
    }
}
