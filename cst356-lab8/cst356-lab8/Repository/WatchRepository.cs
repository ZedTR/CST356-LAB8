using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab8.Data.Entities;
using Lab8.Models;


namespace Lab8.Repository
{
    public class WatchRepository : IWatchesRepository
    {
        private readonly ApplicationDbContext db;


        public WatchRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public void CreateWatch(Watches watch)
        {

            db.Watches.Add(watch);
            db.SaveChanges();
        }

        public void DeleteWatch(int id)
        {
            Watches w;
            w = db.Watches.Find(id);
            db.Watches.Remove(w);
            db.SaveChanges();
        }

        public IEnumerable<Watches> GetUsersWatches(string userid)
        {
            return db.Watches.Where(p => p.UserId == userid).ToList();
        }

        public Watches GetWatches(int id)
        {
            return db.Watches.Find(id);
        }

        public void UpdateWatch(Watches watch)
        {
            db.SaveChanges();
        }
    }
}