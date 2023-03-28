using Items.EFDbContext;
using Items.Models;
using Microsoft.EntityFrameworkCore;

namespace Items.Services
{
    public class DBService <T>  where T : class
    {
        public async Task<List<T>> GetObjects()
        {
            using (var context = new ItemDbContext())
            {
                return await context.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task AddObject(T obj)
        {
            using (var context = new ItemDbContext())
            {
                context.Set<T>().Add(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task SaveObject(List<T> t)
        {
            using (var context = new ItemDbContext())
            {
                foreach (T obj in t)
                {
                    context.Set<T>().Add(obj);
                    context.SaveChanges();
                }

                context.SaveChanges();
            }
        }

        public async Task DeleteObject(T t)
        {
            using (var context = new ItemDbContext())
            {
                context.Set<T>().Remove(t);
                context.SaveChanges();
            }
        }

        public async Task UpdateObject(T t)
        {
            using (var context = new ItemDbContext())
            {
                context.Set<T>().Update(t);
                context.SaveChanges();
            }
        }


        //public async Task<List<T>> GetItems()
        //{
        //    using (var context = new ItemDbContext())
        //    {
        //        return await context.Items.ToListAsync();
        //    }
        //}

        //public async Task<List<User>> GetUsers()
        //{
        //    using (var context = new ItemDbContext())
        //    {
        //        return await context.Users.ToListAsync();
        //    }
        //}

        //public async Task AddItem(Item item)
        //{
        //    using (var context = new ItemDbContext())
        //    {
        //        context.Items.Add(item);
        //        context.SaveChanges();
        //    }
        //}

        //public async Task AddUser(User user)
        //{
        //    using (var context = new ItemDbContext())
        //    {
        //        context.Users.Add(user);
        //        context.SaveChanges();
        //    }
        //}

        //public async Task SaveItems(List<Item> items)
        //{
        //    using (var context = new ItemDbContext())
        //    {
        //        foreach (Item item in items)
        //        {
        //            context.Items.Add(item);
        //            context.SaveChanges();
        //        }

        //        context.SaveChanges();
        //    }
        //}

        //public async Task SaveUsers(List<User> users)
        //{
        //    using (var context = new ItemDbContext())
        //    {
        //        foreach (User user in users)
        //        {
        //            context.Users.Add(user);

        //        }
        //        context.SaveChanges();
        //    }
        //}


    }


}
