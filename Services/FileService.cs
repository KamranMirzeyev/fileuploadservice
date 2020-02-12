using Core;
using Core.Services.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FileService : IFileservice
    {
        private readonly IUnitOfWork _unitOfWork;
        public FileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<File> Create(File file)
        {
            file.CreatedAt = DateTime.UtcNow;
            file.ModifiedAt = DateTime.UtcNow;
            file.CreatedBy = "System";
            file.ModifiedBy = "System";
            await _unitOfWork.File.AddAsync(file);
            await _unitOfWork.CommitAsync();
            return file;
        }

        public async Task<File> GetById(int id)
        {
            return await _unitOfWork.File.GetByIdAsync(id);
        }
    }
}
