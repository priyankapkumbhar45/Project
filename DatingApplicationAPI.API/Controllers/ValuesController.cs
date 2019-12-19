using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApplicationAPI.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{   
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context =context;
        }
        // GET api/values
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
           // throw new exception("Test exception");
             var values= await _context.Values.ToListAsync();
            // Dictionary<int, string> dict= new Dictionary<int, string>();
            // dict.Add(3,"is divisible by 3");
            // dict.Add(5,"is divisible by 5");
            // dict.Add(7,"is divisible by 7");
            // bool printNo;

            // for(int i=1;i<=100;i++){
            //     printNo=true;                
            //     foreach (KeyValuePair<int, string> item in dict)
            //     {
            //         if(i% item.Key==0){
            //             System.Console.WriteLine(i +item.Value);
            //             printNo =false;
            //              break;
            //         }
                                       
            //     }
            // if(printNo)
            // {
            //     System.Console.WriteLine(i);
            // }

            // }
            return Ok(values);
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            
            var value= await _context.Values.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
