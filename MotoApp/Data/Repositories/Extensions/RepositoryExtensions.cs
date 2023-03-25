using MotoApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp.Data.Repositories.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddBatch<T>(this IRepository<T> repository, T[] items)
            where T : class, IEntity
        {
            foreach (var employee in items)
            {
                repository.Add(employee);
            }

            repository.Save();
        }

        public static void RemoveBatch<T>(this IRepository<T> repository, T[] items)
            where T : class, IEntity
        {
            foreach (var employee in items)
            {
                repository.Remove(employee);
            }

            repository.Save();
        }
    }
}
