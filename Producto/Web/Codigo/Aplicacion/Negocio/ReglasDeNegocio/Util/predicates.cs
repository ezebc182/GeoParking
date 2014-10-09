using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio.Util
{
    public static class predicates
    {
        public static Func<T, bool> And<T>(
    this Func<T, bool> predicate1,
    Func<T, bool> predicate2)
        {
            return arg => predicate1(arg) && predicate2(arg);
        }

        public static Func<T, bool> Or<T>(
            this Func<T, bool> predicate1,
            Func<T, bool> predicate2)
        {
            return arg => predicate1(arg) || predicate2(arg);
        }
    }
}
