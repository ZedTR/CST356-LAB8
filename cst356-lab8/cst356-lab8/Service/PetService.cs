using Lab8.Data.Entities;
using Lab8.Models.View;
using Lab8.Repository;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab8.Service
{
    public class PetService : IPetService
    {
        private readonly IPetRepository repo;
       

        public PetService(IPetRepository repository)
        {
            repo = repository;
        }

        public PetViewModel GetPet(int id)
        {  
          return MapToPetViewModel(repo.GetPet(id));         
          
        }

        public IEnumerable<PetViewModel> GetUsersPets(string userid)
        {
                var pets = repo.GetUsersPets(userid);
                return pets.Select(MapToPetViewModel).ToList();           
        }

        public void CreatePet(PetViewModel pet)
        {
                repo.CreatePet(MapToPet(pet));
        }

        public void UpdatePet(PetViewModel pet)
        {
                var p = repo.GetPet(pet.Id);
                CopyToPet(pet, p);
                repo.UpdatePet(p);       
     
        }

        public void DeletePet(int id)
        {
            repo.DeletePet(id);
     
        }


        private Pet MapToPet(PetViewModel pet)
        {
           
                return new Pet
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    Age = pet.Age,
                    NextCheckup = pet.NextCheckup,
                    VetName = pet.VetName,
                    UserId = pet.UserId
                };
         
        }

        private PetViewModel MapToPetViewModel(Pet pet)
        {
    
                return new PetViewModel
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    Age = pet.Age,
                    NextCheckup = pet.NextCheckup,
                    VetName = pet.VetName,
                    UserId = pet.UserId,
                    CheckupAlert = pet.NextCheckup <= DateTime.Today.AddDays(150)
                };
      
        }

        private void CopyToPet(PetViewModel view, Pet pet)
        {
 
                pet.Id = view.Id;
                pet.Name = view.Name;
                pet.Age = view.Age;
                pet.NextCheckup = view.NextCheckup;
                pet.VetName = view.VetName;
                pet.UserId = view.UserId;
      
        }
    }
}