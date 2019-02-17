using Eksamensopgave2f.Interfaces;
using Eksamensopgave2f.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eksamensopgave2f.Infrastructure
{
    public class GroceryRepository : IGroceryRepository
    {
        private readonly Eksamensopgave2DBContext _context;

        //ctor
        public GroceryRepository(Eksamensopgave2DBContext context)
        {
            _context = context;
        }

        public IEnumerable<GroceryTable> Get()
        {
            return _context.GroceryTable.AsEnumerable();
        }

        //Asynkront kald
        public async Task Post([FromBody] GroceryTable value)
        {
            _context.GroceryTable.Add(value);
            await _context.SaveChangesAsync();
        }

        public void Put(int id)
        {
            //Hvis istedet [FromBody] GroceryTable value var input kunne følgende bruges:
            //_context.Entry(value).State = EntityState.Modified

            var grocery = _context.GroceryTable.FirstOrDefault(x => x.Id == id);
            grocery.Checkmark = !grocery.Checkmark;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.GroceryTable.FirstOrDefault(x => x.Id == id);
            _context.Remove(product);
            _context.SaveChanges();
        }
    }
}
