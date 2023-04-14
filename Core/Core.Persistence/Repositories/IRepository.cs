using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IRepository<T>:IQuery<T> where T:Entity
    {
        //Predicate verilen koşulu sağlayanı getir.
        T Get(Expression<Func<T, bool>> predicate);
        //Eğer parametre olarak verirsem şartı sağlayan,verilen sıralama şekli ile verirsem isteğim tablo ile join atarak 
        //default index 0 size 10 olarak sayfalayarak trackingi default true olarak verileri listele
        IPaginate<T> GetList(Expression<Func<T, bool>>? predicate = null,
                         Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                         Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                         int index = 0, int size = 10,
                         bool enableTracking = true);
        //Verilen dinamik sorguya göre ,eğer istersem join atarak
        //default index 0 size 10 tracking açık şekilde verileri listele.
        IPaginate<T> GetListByDynamic(Dynamic.Dynamic dynamic,
                                 Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                 int index = 0, int size = 10, bool enableTracking = true);

        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
