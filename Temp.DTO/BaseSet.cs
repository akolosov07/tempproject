using System.Collections.Generic;
namespace Temp.DTO
{
    public abstract class BaseSet<T> : List<T> where T : BaseModel
    {
        internal BaseSet(IEnumerable<T> set, int itemsCount, int itemsPerPage, int page)
            : base(set)
        {
            ItemsCount = itemsCount;
            itemsPerPage = itemsPerPage <= 0 ? 1 : itemsPerPage;
            PagesCount = itemsCount / itemsPerPage + (itemsCount % itemsPerPage == 0 ? 0 : 1);
            Page = page;
        }

        public int ItemsCount { get; private set; }
        public int PagesCount { get; private set; }
        public int Page { get; private set; }
    }
}
