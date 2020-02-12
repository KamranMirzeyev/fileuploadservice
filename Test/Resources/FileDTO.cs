using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Resources
{
    public class FileDTO
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
        public IFormFile File { get; set; }
    }
}
