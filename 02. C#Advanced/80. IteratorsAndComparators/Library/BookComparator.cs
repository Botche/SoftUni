using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            var titleDiff = x.Title.CompareTo(y.Title);

            if (titleDiff != 0)
            {
                return titleDiff;
            }

            return y.Year.CompareTo(x.Year);
        }
    }
}