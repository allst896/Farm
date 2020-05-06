using Farm.Models.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farm.Tracker.Application.C
{
    public class AnimalsService
    {
        private readonly FarmContext farmContext;
        private readonly ILogger<AnimalsService> logger;

        public AnimalsService(FarmContext farmContext, ILogger<AnimalsService> logger)
        {
            this.farmContext = farmContext;
            this.logger = logger;
        }

        public async Task<List<Animals>> GetAnimalsByTypeAsync(AnimalTypes animalType)
        {
            var animals = await farmContext.Animals
                .Where(a => a.AnimalType == animalType)
                .ToListAsync();
            
            if (animals != null)
            {
                return animals;
            }

            return new List<Animals>();
        }

        public async Task<List<Animals>> GetAnimalsBySex(Sex sex)
        {
            var animals = await farmContext.Animals
                .Where(a => a.SexType == sex)
                .ToListAsync();

            if (animals != null)
            {
                return animals;
            }

            return new List<Animals>();
        }
    }
}
