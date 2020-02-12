using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface IFileservice
    {
        Task<File> GetById(int id);
        Task<File> Create(File file);
    }
}
