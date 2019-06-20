﻿namespace IteratorsAndComparators
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.Title.CompareTo(y.Title) == 0)
            {
                return y.Year.CompareTo(x.Year);
            }
            else
            {
                return x.Title.CompareTo(y.Title);
            }
        }
    }

}