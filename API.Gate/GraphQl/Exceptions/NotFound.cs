namespace API.Gate.GraphQl.Exceptions
{
    public class NotFound : Exception
    {
        public NotFound(string? message, Exception? innerException, int id)
            : base(message, innerException)
            => this.ModelId = id;

        public NotFound(string? message, int id)
            : this(message, null, id) { }

        /// <summary>
        /// Id of model, that was not found
        /// </summary>
        public int ModelId { get; set; }
    }
}
