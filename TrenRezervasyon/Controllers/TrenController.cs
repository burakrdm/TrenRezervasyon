using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrenRezervasyon.Libs;
using TrenRezervasyon.Model;

namespace TrenRezervasyon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrenController : ControllerBase
    {
        //url/api/tren/rezervasyon
        [HttpPost("rezervasyon")]
        public YerlesimModel Rezervasyon(TrenModel trenModel) 
        {
            var res = new Rezervasyon();
            var sonuc = res.RezervasyonYap(trenModel);

            return sonuc;
        }
    }
}
