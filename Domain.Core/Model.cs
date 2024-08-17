namespace Domain.Core
{
    public abstract class Model
    {
        [GraphQLIgnore]
        public int Id { get; set; }
    }
}
