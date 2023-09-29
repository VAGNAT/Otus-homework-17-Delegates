using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus_homework_17_Delegates
{
    public static class ExtensionsEnumerable
    {
        public static T? GetMax<T>(this IEnumerable<T> collection, Func<T, float> getParameter) where T : class
        {
            return collection?.FirstOrDefault(c => getParameter(c) == collection.Max(getParameter));
        }
    }
}
