using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Prac.Models;
using WebAPI_Prac.DB;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_Prac.API
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        DB.DBRegister datatest = new DB.DBRegister();

        private readonly IOptions<ModelConnectionString> appsettings;
        public RegisterController(IOptions<ModelConnectionString> app)
        {
            appsettings = app;
        }



        // GET: api/Register/GetRegisterList
        [HttpGet]
        [ActionName("GetRegisterList")]
        public IEnumerable<ModelRegister> GetRegisterdList()
        {
            return datatest.GetRegisterList(appsettings.Value.DefaultConnection);
        }

        // EDIT api/Register/EditRegisterList
        [HttpGet]
        [ActionName("EditRegisterList")]
        public IEnumerable<ModelRegister> EditRegisteredList(int id)
        {
            return datatest.EditRegisterList(id,appsettings.Value.DefaultConnection);
        }

        // POST api/Register/SaveRegister
        [HttpPost]
        [ActionName("SaveRegister")]
        public string Post(ModelRegister stud)
        {
            return datatest.Post(stud, appsettings.Value.DefaultConnection);
        }

        // PUT api/Register/UpdateRegister
        [HttpPut]
        [ActionName("UpdateRegister")]
        public string Put(ModelRegister stud)
        {
            return datatest.Put(stud, appsettings.Value.DefaultConnection);
        }

        // DELETE api/Register/DeleteRegister
        [HttpDelete]
        [ActionName("DeleteRegister")]
        public string Delete(int id)
        {
            return datatest.Delete(id, appsettings.Value.DefaultConnection);
        }
    }
}
