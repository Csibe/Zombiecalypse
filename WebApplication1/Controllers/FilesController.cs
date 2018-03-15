using WebApplication1.DAL;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class FileController : Controller
    {
        private DataContext db = new DataContext();
        //
        // GET: /File/
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}