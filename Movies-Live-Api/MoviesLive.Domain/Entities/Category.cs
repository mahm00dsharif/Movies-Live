using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLive.Domain.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [MaxLength(300)]
        public string Name { get; set; }
        public Guid? ParentId { get; set; }

        public virtual Category Parent { get; set; }

        public ICollection<Category> SubCategories { get; } = new List<Category>();
    }
}
