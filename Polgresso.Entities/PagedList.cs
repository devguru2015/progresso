using System.Collections.Generic;

namespace Polgresso.Entities
{
    public class PagedList<T>
    {
        public int TotalRecords { get; set; }

        public IList<T> List { get; set; }
    }
}