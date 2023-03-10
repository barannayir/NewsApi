﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class News : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Content { get; set; }
        public bool? IsActive { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
