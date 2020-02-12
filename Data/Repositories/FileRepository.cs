using Core;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class FileRepository : Repository<File>, IFileRepository
    {
        private TestContext _context => Context as TestContext;
        public FileRepository(TestContext context) : base(context)
        {

        }
    }
}
