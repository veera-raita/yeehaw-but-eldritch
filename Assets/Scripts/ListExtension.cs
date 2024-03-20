using System;
using System.Collections.Generic;

namespace GBE
{
    public static class ListExtension
    {
        // More convenient function to avoid making a separate shuffle function each time.
        public static void Shuffle<T>(this IList<T> t_list)
        {
            Random t_random = new();
            for (var i = 0; i < t_list.Count; i++)
            {
                t_list.Change(i, t_random.Next(i, t_list.Count));
            }
        }

        public static void Change<T>(this IList<T> t_list, int a, int b)
        {
            T t_temp = t_list[a];
            t_list[a] = t_list[b];
            t_list[b] = t_temp;
        }
    }
}