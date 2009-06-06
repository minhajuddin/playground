using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using SubSonic;
using System.Collections;
using Subsonic.Web.Models;
using System.Text;

namespace Controllers
{
    public class AlbumController : Controller
    {
        
        IRepository<Album> _repository;
        /// <summary>
        /// Default Constructor - delete this if you use IoC
        /// </summary>
        public AlbumController(){
            _repository = new SubSonicRepository<Album>();
        }
        
        /// <summary>
        /// Injectable Constructor
        /// </summary>
        /// <param name="repository"></param>
        public AlbumController(IRepository<Album> repository){
            _repository = repository;
        }
        
        //
        // GET: /Album/
        public ActionResult Index()
        {
            int pageNumber=  1;
            string sPage = Request.Form["pg"];
            string sortBy = Request.QueryString["s"];
            string sortDir = Request.QueryString["dir"] ?? "";
            string query = Request.Form["q"];

            //handle the search
            if (!string.IsNullOrEmpty(query)) {
                var item = _repository.Search(Album.GetDescriptorColumn(), query).FirstOrDefault();
                return RedirectToAction("Edit", new { id = item.KeyValue() });
            } else {

                if (sortDir.Equals("desc") && !String.IsNullOrEmpty(sortBy))
                    sortBy += " desc";

                PagedList<Album> items = null;

                if (!String.IsNullOrEmpty(sPage))
                    int.TryParse(sPage, out pageNumber);


                if (String.IsNullOrEmpty(sortBy)) {
                    items = _repository.GetPaged(pageNumber, 20);
                } else {
                    items = _repository.GetPaged(sortBy, pageNumber, 20);

                }
                return View(items);
            }
        }


        /// <summary>
        /// Used for auto-complete
        /// </summary>
        /// <param name="q">Query sent in for auto-complete</param>
        /// <returns>String</returns>
        public string List(string q) {

            q = q ?? "";
            var items = _repository.Search(Album.GetDescriptorColumn(), q);
            var sb = new StringBuilder();
            items.ToList().ForEach(x => sb.AppendLine(x.ToString()));
            return sb.ToString();
        }

        //
        // GET: /Album/Details/5
        public ActionResult Details(int id)
        {
            var item = _repository.GetByKey(id);
            return View(item);
        }

        //
        // GET: /Album/Create

        //[Authorize]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Album/Create
        [AcceptVerbs(HttpVerbs.Post)]
        //[Authorize]
        public ActionResult Create(Album item)
        {
            if(ModelState.IsValid)
            {
                _repository.Add(item);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /Album/Edit/5
        //[Authorize]
        public ActionResult Edit(int id)
        {
            var item = _repository.GetByKey(id);
            return View(item);
        }

        //
        // POST: /Album/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]
        //[Authorize]
        public ActionResult Edit(Album item)
        {
            if(ModelState.IsValid)
            {
                string resultMessage = "";
                try {
                    _repository.Update(item);
                    resultMessage = item.DescriptorValue() + " updated!";
                } catch(Exception x) {
                    //edit this to return a message
                    resultMessage = "ERROR: "+ item.DescriptorValue() + " failed: "+x.Message;

                }
                //if this is an Ajax request - just send back a message
                if (Request.IsAjaxRequest()) {
                    return Content(resultMessage);
                } else {
                    return RedirectToAction("Index");
                }
            } 
            else 
            {
                return View();
            }
        }
        [AcceptVerbs(HttpVerbs.Post)]
        //[Authorize]
        public ActionResult Delete() {

            string id = Request.Form["id"];
            if (!string.IsNullOrEmpty(id)) {
                //delete from the repo
                string resultMessage = "";
                try {
                    _repository.Delete(id);
                    resultMessage = "Artist deleted";
                } catch (Exception x) {
                    resultMessage = "ERROR: " + x.Message;
                }
                if (Request.IsAjaxRequest()) {
                    return Content(resultMessage);
                } else {
                    return RedirectToAction("Index");
                }
            } else {
                return new EmptyResult();
            }
        }
    }
}
