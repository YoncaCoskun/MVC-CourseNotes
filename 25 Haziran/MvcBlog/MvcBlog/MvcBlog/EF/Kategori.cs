using System.Collections.Generic;

namespace MvcBlog.EF
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public virtual ICollection<Makale> Makaleler { get; set; } 
    }
}