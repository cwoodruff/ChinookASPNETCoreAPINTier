namespace Chinook.MockData.Extensions
{
    public class PaginationHeader
    {
        private int CurrentPage { get; set; }
        private int ItemsPerPage { get; set; }
        private int TotalItems { get; set; }
        private int TotalPages { get; set; }

        public PaginationHeader(int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }
    }
}
