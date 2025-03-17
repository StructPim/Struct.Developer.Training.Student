namespace Website.Models
{
    public class ProductsListViewModel
    {
        public List<ListProductViewModel> Products { get; set; } = new List<ListProductViewModel>();
        public int CurrentPage { get; set; }
        public int PageSize { get; set; } = 24;
        public int TotalResults { get; set; }
        public int TotalPages
        {
            get
            {
                if (TotalResults == 0)
                {
                    return 0;
                }
                return TotalResults / PageSize;
            }
        }
    }
}
