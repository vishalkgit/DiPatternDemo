﻿namespace DiPatternDemo.Models
{
    public class Pager
    {
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }

        public int PageSize { get; private set; }

        public int TotalPages { get; private set; }

        public int StartPage { get; private set; }

        public int EndPage { get; private set; }

        public Pager()
        {

        }

        public Pager(int totalItems, int page, int pagesize =5)
        {
            int totalpages = (int)Math.Ceiling((decimal)totalItems / (decimal)pagesize);

            int currentpage = page;

            int startpage = currentpage - 1;
            int endpage = currentpage + 4;

            if (startpage <= 0)
            {
                endpage = endpage - (startpage - 1);
                startpage = 1;
            }

            if (endpage > totalpages)
            {
                endpage = totalpages;
                if (endpage > 10)
                {
                    startpage = endpage - 9;
                }

            }
        }
    }
}
