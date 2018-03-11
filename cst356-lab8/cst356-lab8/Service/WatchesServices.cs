using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab8.Data.Entities;
using Lab8.Models.View;
using Lab8.Models.ViewModel;
using Lab8.Repository;

namespace Lab8.Service
{
    public class WatchesServices : IWatchesServices
    {
        private readonly IWatchesRepository repository;

        public WatchesServices(IWatchesRepository repo)
        {
            repository = repo;
        }

        public void CreateWatch(WatchesViewModel watch)
        {
            repository.CreateWatch(MapToWatch(watch));
        }

        public void DeleteWatch(int id)
        {
            repository.DeleteWatch(id);
        }

        public IEnumerable<WatchesViewModel> GetUsersWatches(string userid)
        {
            var watches = repository.GetUsersWatches(userid);
            return watches.Select(MapToWatchViewModel).ToList();
        }

        public WatchesViewModel GetWatches(int id)
        {
            return MapToWatchViewModel(repository.GetWatches(id));
        }

        public void UpdateWatch(WatchesViewModel watch)
        {
            var p = repository.GetWatches(watch.Id);
            CopyToWatch(watch, p);
            repository.UpdateWatch(p);
        }
        private Watches MapToWatch(WatchesViewModel watch)
        {

            return new Watches
            {
                Id = watch.Id,
                Name = watch.Name,
                PurchaseYears = watch.PurchaseYears,
                NextMaintaince = watch.NextMaintaince,
                UserId = watch.UserId
            };

        }

        private WatchesViewModel MapToWatchViewModel(Watches watch)
        {

            return new WatchesViewModel
            {
                Id = watch.Id,
                Name = watch.Name,
                PurchaseYears = watch.PurchaseYears,
                NextMaintaince = watch.NextMaintaince,

                UserId = watch.UserId,
                CheckupAlert = watch.NextMaintaince <= DateTime.Today.AddDays(14)
            };

        }

        private void CopyToWatch(WatchesViewModel view, Watches watch)
        {

            watch.Id = view.Id;
            watch.Name = view.Name;
            watch.PurchaseYears = view.PurchaseYears;
            watch.NextMaintaince = view.NextMaintaince;
            watch.UserId = view.UserId;

        }
    }
}