using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace NetUnit.Core.EF
{
    public class DbContextInMemory
    {

// public static TContext DoMock<TId, TData, TContext>(List<TData> listData, Expression<Func<TContext, DbSet<TData>>> dbSetSelectionExpression) 
//             where TData : BaseModel<TId> 
//             where TContext : DbContext
//         {
//             var options = new DbContextOptionsBuilder<TContext>()
                
//                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
//                 .Options;

//             var databaseContext = new DatabaseContext(options);
//             databaseContext.Database.EnsureCreated();
//             if (await databaseContext.Users.CountAsync() <= 0)
//             {
//                 for (int i = 1; i <= 10; i++)
//                 {
//                     databaseContext.Users.Add(new User()
//                     {
//                         Id = i,
//                         Email = $"testuser{i}@example.com",
//                         IsLocked = false,
//                         CreatedBy = "SYSTEM",
//                         CreatedDate = DateTime.UtcNow
//                     });
//                     await databaseContext.SaveChangesAsync();
//                 }
//             }
//             return databaseContext;
//         }
       
     }
}