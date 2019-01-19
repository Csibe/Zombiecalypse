using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Zombiecalypse.DAL;
using Zombiecalypse.Models;

namespace Zombiecalypse.Controllers.api
{
    public class DefaultController : ApiController
    {

        [Route("/api/Default/test")]
        [HttpGet]
        public IHttpActionResult test()
        {
            return Ok();
        }

    [Route("/api/Default/GrowUpPlant")]
        [HttpGet]
        public IHttpActionResult GrowUpPlant(int fieldID)
        {
            DataContext db = new DataContext();
            CharacterFieldVM model = new CharacterFieldVM();

            model.CharacterField = db.CharacterFields.Find(fieldID);
            model.CharacterField.isFinished = true;
            model.CharacterField.FinishDate = DateTime.MaxValue;
            db.SaveChanges();

            return Ok();

        }
    }
}
