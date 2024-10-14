namespace Survivor.Entites
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Competitor> Competitors { get; set; } // Bir kategorinin birden fazla yarışmacısı olabilir
    }

}
