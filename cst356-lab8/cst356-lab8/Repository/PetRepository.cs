using Lab8.Data.Entities;
using Lab8.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab8.Repository
{
    public class PetRepository : IPetRepository
    {
        private readonly ApplicationDbContext db;


        public PetRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public Pet GetPet(int id)
        {
                return db.Pets.Find(id);
       
        }

        public IEnumerable<Pet> GetUsersPets(string userid)
        {
            return db.Pets.Where(p => p.UserId == userid).ToList();
               
        }

        public void CreatePet(Pet pet)
        {
                db.Pets.Add(pet);
                db.SaveChanges();
        }

        public void UpdatePet(Pet pet)
        { 
                db.SaveChanges(); 
        }

        public void DeletePet(int id)
        {
             Pet _p;
             _p = db.Pets.Find(id);
             db.Pets.Remove(_p);
             db.SaveChanges();
       
        }
    }
}