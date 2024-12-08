using DiPatternDemo.Models;
using DiPatternDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiPatternDemo.Controllers
{
    [UserLog]
    public class ProductController : Controller
    {
        private readonly IProductService service;
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment env;   //image upload
        private readonly ICategoryService cat;
        public ProductController(IProductService service, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env, ICategoryService cat)
        {
            this.service = service;
            this.env = env;
            this.cat = cat;
        }

        // GET: ProductController
        public ActionResult Index(int pg = 2)
        {
            var products = service.GetProducts();
            const int pagesize = 5;
            if (pg < 1)
            {
                pg = 1;
            }

            int recscount = products.Count();

            var pager = new Pager(recscount, pg, pagesize);

            int recskip = (pg - 1) * pagesize;

            var data = products.Skip(recskip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;
            return View(data);

        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(service.GetProductById(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Categories=cat.GetCategories();
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod, IFormFile file)
        {
            try
            {
                //to upload image in the images folder
                using(var fs=new FileStream(env.WebRootPath+"\\images\\"+file.FileName,FileMode.Create,FileAccess.Write))
                {
                    file.CopyTo(fs);
                }
                prod.ImageURL="~/images/"+file.FileName;
                var result=service.AddProduct(prod);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Something went wrong";
                    return View();
                }
                
            }
            catch(Exception ex)
            {
                ViewBag.Error=ex.Message;
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Categories = cat.GetCategories();
            var prod=service.GetProductById(id);
            TempData["OldUrl"] = prod.ImageURL;
            TempData.Keep("OldUrl");
            return View(prod);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prod,IFormFile file)
        {
            try
            {
                string oldimageurl = TempData["OldUrl"].ToString();
                if (file != null) // to check user has uploaded new image
                {
                    // new image adde to project
                    using (var fs = new FileStream(env.WebRootPath + "\\images\\" + file.FileName, FileMode.Create, FileAccess.Write))
                    {
                        file.CopyTo(fs);
                    }
                    prod.ImageURL = "~/images/" + file.FileName;

                    // remove old image
                    string[] str = oldimageurl.Split("/");
                    string str1 = (str[str.Length - 1]);
                    string path = env.WebRootPath + "\\images\\" + str1;
                    System.IO.File.Delete(path);
                }
                else
                {
                    prod.ImageURL = oldimageurl;
                }

                int res = service.UpdateProduct(prod);
                if (res == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }


        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(service.GetProductById(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                var p = service.GetProductById(id);
                // remove old image
                string[] str = p.ImageURL.Split("/");
                string str1 = (str[str.Length - 1]);
                string path = env.WebRootPath + "\\images\\" + str1;
                System.IO.File.Delete(path);

                int res = service.DeleteProduct(id);
                if (res == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }
    }
}
