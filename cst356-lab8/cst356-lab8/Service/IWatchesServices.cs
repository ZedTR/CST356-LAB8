using Lab8.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Service
{
    public interface IWatchesServices
    {
        WatchesViewModel GetWatches(int id);

        IEnumerable<WatchesViewModel> GetUsersWatches(string userid);

        void CreateWatch(WatchesViewModel watch);

        void UpdateWatch(WatchesViewModel watch);

        void DeleteWatch(int id);
    }
}
