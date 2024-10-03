namespace RepoFinder.Business.DTOs
{
    public class ActionResult<TModel> where TModel : class
    {
        public bool IsValid { get; set; }
        public string Message { get; set; } = string.Empty;
        public IList<TModel>? Results { get; set; }

        public TModel? Result { get; set; }
    }
}
