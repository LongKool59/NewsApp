
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsApp.DataAccessor.Entities
{
    [Table("News")]
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public Guid TypeID { get; set; }
        public Type Type { get; set; }
        public string AuthorName { get; set; }
        public IEnumerable<Pictures> Pictures { get; set; }
        public IEnumerable<Comments> Comments { get; set; }


    }
}
