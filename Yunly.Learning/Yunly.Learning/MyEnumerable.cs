using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Yunly.Learning
{
    public static class MyEnumerable
    {


        public static TSource ElementAt<TSource>(this IEnumerable<TSource> source, int index)
        {
            if (source == null) throw new ArgumentNullException("source");
            IList<TSource> list = source as IList<TSource>;
            if (list != null) return list[index];
            if (index < 0) throw new ArgumentOutOfRangeException("index");
            using (IEnumerator<TSource> e = source.GetEnumerator())
            {
                while (true)
                {
                    if (!e.MoveNext()) throw new ArgumentOutOfRangeException("index");
                    if (index == 0) return e.Current;
                    index--;
                }
            }
        }
    }
}
