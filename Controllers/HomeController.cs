using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCcoreCURD.Models;
namespace MVCcoreCURD.Controllers
{
    public class HomeController : Controller
    {
        private readonly MvccoreContext studentdb; 

        public HomeController(MvccoreContext studentdb)
        {
            this.studentdb = studentdb;
        }

        public async Task<IActionResult> Index()
        {
            var s = await studentdb.Students.ToListAsync();
            return View(s);
        }



        public IActionResult create()
        {
           
            return View();
        }


        [HttpPost]  
        public async Task<IActionResult> Create(Student s)
        {
            if (ModelState.IsValid)
            {
                await studentdb.Students.AddAsync(s);
                await studentdb.SaveChangesAsync(); 

                return RedirectToAction("Index");
            }

            return View(s); 
        }



        public IActionResult edit(int id)
        {
            var s = studentdb.Students.Find(id);

            if(s == null)
            {
                return NotFound();  
            }

         return View(s);
        }


        [HttpPost]
        public async Task<IActionResult> edit(Student s,int id)
        {
            if (ModelState.IsValid) 
            {
                  var a=await studentdb.Students.FindAsync(id);
                if(a == null)
                {
                    return NotFound();  
                }

                else
                {
                    a.Sname = s.Sname;
                    a.Sage = s.Sage;
                    a.Sstd = s.Sstd;

                    await studentdb.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                
            }


            return View();
        }



        public IActionResult details(int id)
        {
            var s = studentdb.Students.Find(id);

            if (s == null)
            {
                return NotFound();
            }

            return View(s);
        }

        public IActionResult delete(int id)
        {
            var s = studentdb.Students.Find(id);

            if (s == null)
            {
                return NotFound();
            }

            return View(s);
        }


        [HttpPost]
        public async Task<IActionResult> delete(Student s, int id)
        {
           var a=await studentdb.Students.FindAsync(id);

            if (a == null)
            {
                return NotFound();
            }

            else
            {
                studentdb.Students.Remove(a);
                await studentdb.SaveChangesAsync();

                return RedirectToAction("Index");
            }


        }







    }
}
