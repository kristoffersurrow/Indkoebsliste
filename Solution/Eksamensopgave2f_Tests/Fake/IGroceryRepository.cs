using Eksamensopgave2f.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eksamensopgave2f.Interfaces
{
    public interface IGroceryRepository
    {
        IEnumerable<GroceryTable> Get();
        void Post([FromBody] GroceryTable value);
        void Put(int id);
        void Delete(int id);
    }
}
