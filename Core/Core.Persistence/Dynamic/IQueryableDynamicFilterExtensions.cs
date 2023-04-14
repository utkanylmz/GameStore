using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Dynamic
{
    public static class IQueryableDynamicFilterExtensions
    {
        //Nesnelerin üzerinde Dynamic sorgu yapmaya yarayan extansions metotlar içerir
        private static readonly IDictionary<string, string>
            Operators = new Dictionary<string, string>
            {
            { "eq", "=" },
            { "neq", "!=" },
            { "lt", "<" },
            { "lte", "<=" },
            { "gt", ">" },
            { "gte", ">=" },
            { "isnull", "== null" },
            { "isnotnull", "!= null" },
            { "startswith", "StartsWith" },
            { "endswith", "EndsWith" },
            { "contains", "Contains" },
            { "doesnotcontain", "Contains" }
            };

        //Generic verilen nesne üzerindeki Dynamic nesnesi ile parametere olarak alınan sorgu filtreleri ve sıralama
        //bilgileri ile filtreleme ve sorgulama işlemi yapar.

        public static IQueryable<T> ToDynamic<T>(
            this IQueryable<T> query, Dynamic dynamic)
        {
            if (dynamic.Filter is not null) query = Filter(query, dynamic.Filter);
            if (dynamic.Sort is not null && dynamic.Sort.Any()) query = Sort(query, dynamic.Sort);
            return query;
        }

        //Filter metodu, verilen IQueryable<T> nesnesinde sorgu filtrelemesi yapar. Sorgu filtreleri,
        //Filter sınıfından türetilen bir nesne kullanılarak sağlanır.
        //Bu metod, Transform metodu ile oluşturulan sorgu ifadesini kullanarak IQueryable<T> nesnesini filtreler.
        //GetAllFilters() filter nesnesindeki tüm filtreleri alır.
        //Transform metodu ise Operators Dictionary'sini kullarak filtreleri sorguya çevirir.
        private static IQueryable<T> Filter<T>(
            IQueryable<T> queryable, Filter filter)
        {
            IList<Filter> filters = GetAllFilters(filter);
            string?[] values = filters.Select(f => f.Value).ToArray();
            string where = Transform(filter, filters);
            queryable = queryable.Where(where, values);

            return queryable;
        }



        //Sort metodu, verilen IQueryable<T> nesnesinde sorgu sıralaması yapar. Sorgu sıralaması,
        //Sort sınıfından türetilen bir nesne kullanılarak sağlanır.
        //Bu metod, OrderBy metodu ile oluşturulan sıralama ifadesini kullanarak IQueryable<T> nesnesini sıralar.
        private static IQueryable<T> Sort<T>(
            IQueryable<T> queryable, IEnumerable<Sort> sort)
        {
            if (sort.Any())
            {
                string ordering = string.Join(",", sort.Select(s => $"{s.Field} {s.Dir}"));
                return queryable.OrderBy(ordering);
            }

            return queryable;
        }

        public static IList<Filter> GetAllFilters(Filter filter)
        {
            List<Filter> filters = new();
            GetFilters(filter, filters);
            return filters;
        }

        private static void GetFilters(Filter filter, IList<Filter> filters)
        {
            filters.Add(filter);
            if (filter.Filters is not null && filter.Filters.Any())
                foreach (Filter item in filter.Filters)
                    GetFilters(item, filters);
        }

        //Transform metodu, belirtilen Filter nesnesine göre sorgu ifadesini dönüştürür. Bu metot, Operators sözlüğü
        //ile filtre karşılaştırma işlemi için gerekli işleçleri sağlar. Dönüştürülmüş sorgu ifadesi,
        //Filter metodu tarafından kullanılır.
        public static string Transform(Filter filter, IList<Filter> filters)
        {
            int index = filters.IndexOf(filter);
            string comparison = Operators[filter.Operator];
            StringBuilder where = new();

            if (!string.IsNullOrEmpty(filter.Value))
            {
                if (filter.Operator == "doesnotcontain")
                    where.Append($"(!np({filter.Field}).{comparison}(@{index}))");
                else if (comparison == "StartsWith" ||
                         comparison == "EndsWith" ||
                         comparison == "Contains")
                    where.Append($"(np({filter.Field}).{comparison}(@{index}))");
                else
                    where.Append($"np({filter.Field}) {comparison} @{index}");
            }
            else if (filter.Operator == "isnull" || filter.Operator == "isnotnull")
            {
                where.Append($"np({filter.Field}) {comparison}");
            }

            if (filter.Logic is not null && filter.Filters is not null && filter.Filters.Any())
                return
                    $"{where} {filter.Logic} ({string.Join($" {filter.Logic} ", filter.Filters.Select(f => Transform(f, filters)).ToArray())})";

            return where.ToString();
        }
    }
}
