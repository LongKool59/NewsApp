using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Contracts.Dtos
{
    public class TypeDto:BaseDto
    {
        [Required]
        [StringLength(maximumLength: 200)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Desc { get; set; }
        public ICollection<NewsDto> News { get; set; }
    }
}
