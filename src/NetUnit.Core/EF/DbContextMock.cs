using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace NetUnit.Core.EF
{
    public class DbContextMock
   {
        public static TContext DoMock<TId, TData, TContext>(List<TData> listData, Expression<Func<TContext, DbSet<TData>>> dbSetSelectionExpression) 
            where TData : BaseModel<TId> 
            where TContext : DbContext
        {
            Mock<DbSet<TData>> dbSetMock = MockDbSet<TId, TData>(listData);

            Mock<TContext> dbContextMock = new Mock<TContext>();
            dbContextMock.Setup(dbSetSelectionExpression).Returns(dbSetMock.Object);

            return dbContextMock.Object;
        }

        
        private static Mock<DbSet<TEntity>> MockDbSet<TId, TEntity>(List<TEntity> data)
            where TEntity : BaseModel<TId> 
        {

            IQueryable<TEntity> queryable = data.AsQueryable();
            Mock<DbSet<TEntity>> dbSetMock = new Mock<DbSet<TEntity>>();

            dbSetMock.As<IAsyncEnumerable<TEntity>>()
                .Setup(x => x.GetAsyncEnumerator(default))
                .Returns(new EFAsyncEnumerator<TEntity>(queryable.GetEnumerator()));

            dbSetMock.As<IQueryable<TEntity>>()
                .Setup(m => m.Provider)
                .Returns(new EFAsyncQueryProvider<TEntity>(queryable.Provider));
            
            dbSetMock.As<IQueryable<TEntity>>()
                .Setup(m => m.Expression).Returns(queryable.Expression);
            
            dbSetMock.As<IQueryable<TEntity>>()
                .Setup(m => m.ElementType).Returns(queryable.ElementType);
            
            dbSetMock.As<IQueryable<TEntity>>()
                .Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            dbSetMock.Setup(x => x.Add(It.IsAny<TEntity>()))
                .Callback<TEntity>(data.Add);
            
            dbSetMock.Setup(x => x.AddRange(It.IsAny<IEnumerable<TEntity>>()))
                .Callback<IEnumerable<TEntity>>(data.AddRange);

            dbSetMock.Setup(x => x.Remove(It.IsAny<TEntity>()))
                .Callback<TEntity>(t => data.Remove(t));

            dbSetMock.Setup(x => x.RemoveRange(It.IsAny<IEnumerable<TEntity>>()))
                .Callback<IEnumerable<TEntity>>(ts =>
                {
                    foreach (var t in ts) { data.Remove(t); }
                });

            dbSetMock.Setup(x => x.Update(It.IsAny<TEntity>()))
                .Callback<TEntity>(t =>
                {
                    var found = data.FirstOrDefault(item => item.Id.Equals(t.Id));
                    if(found==null)
                        return;

                    data.Remove(found);
                    data.Add(t);
                });

            dbSetMock.Setup(x => x.UpdateRange(It.IsAny<IEnumerable<TEntity>>()))
                .Callback<IEnumerable<TEntity>>(ts =>
                {
                    foreach (var t in ts) { 
                        
                        var found = data.FirstOrDefault(item => item.Id.Equals(t.Id));
                        if(found==null)
                            continue;

                        data.Remove(found);
                        data.Add(t);
                    }
                });

            return dbSetMock;
        }
    }

}