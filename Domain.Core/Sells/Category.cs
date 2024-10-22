using SlnAssembly.Attributes;

namespace Domain.Core.Sells
{
    [DALRepository]
    public class Category : Model
    {        
        public string Name { get; set; }
        public string Description { get; set; }

        public Category? RootCategory { get; set; }
        public IQueryable<Category>? ChildCategories { get; set; }
    }
}
