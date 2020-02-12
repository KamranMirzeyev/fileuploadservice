using Core;
using Core.Repositories;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestContext _context;
        private IFileRepository _fileRepository;

        public IFileRepository File => _fileRepository ?? new FileRepository(_context);


        public UnitOfWork(TestContext context)
        {
            this._context = context;
        }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
