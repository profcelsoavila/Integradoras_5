﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CaoLendario.Models;

namespace CaoLendario.Models
{
    public class EFAnimalRepositorio : IAnimalRepositorio
    {
        public ApplicationDbContext context;

        public EFAnimalRepositorio(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Animal> Animal => context.Animais;

        public void Create(Animal animal)
        {
            context.Add(animal);
            context.SaveChanges();
        }

        public Animal ObterAnimal(int id)
        {
            var animal = context.Animais
            .FirstOrDefault(a => a.AnimalID == id);
            return animal;
        }

        public void Edit(Animal animal)
        {
            context.Entry(animal).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Animal animal)
        {
            context.Remove(animal);
            context.SaveChanges();
        }
    }
}
