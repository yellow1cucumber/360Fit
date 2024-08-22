namespace Domain.Core.Sells
{
    public class CategoryDTO
    {        
        public string Name { get; set; }
        public string Description { get; set; }

        public CategoryDTO? RootCategory { get; set; }
        public IQueryable<CategoryDTO>? ChildCategories { get; set; }
    }
}
