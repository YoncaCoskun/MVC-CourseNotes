namespace MvcBlog.EF
{
    public class MakaleEtiket
    {
        public int Id { get; set; }
        public int MakaleId { get; set; }
        public int EtiketId { get; set; }
        
        //navigation properties
        public virtual Makale Makale { get; set; }
        public virtual Etiket Etiket { get; set; }
    }
}