namespace XPathBuilder.Service.Models
{
    using System.Collections.Generic;

    public class XPathResponse
    {
       public int TotalCount { get; set; }

        public int ResultCount { get; set; }

        public long Elapsed { get; set; }

        public List<ItemResponse> Items { get; set; }
    }
}