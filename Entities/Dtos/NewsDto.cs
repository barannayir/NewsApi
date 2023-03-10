using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class NewsDto : IDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

    }
}
