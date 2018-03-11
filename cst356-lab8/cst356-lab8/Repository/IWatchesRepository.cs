using Lab8.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Repository
{
    public interface IWatchesRepository 
    {
        Watches GetWatches(int id);

        IEnumerable<Watches> GetUsersWatches(string userid);

        void CreateWatch(Watches watch);

        void UpdateWatch(Watches watch);

        void DeleteWatch(int id);
    }
}
