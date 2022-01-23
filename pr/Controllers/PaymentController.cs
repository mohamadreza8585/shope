using BEE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;

namespace pr.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private UserManager<User> userManager;
        public PaymentController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult> pyment()
        {
            var listbasket = new List<int>();
            if (HttpContext.Session.GetString("basket") != null)
            {
                listbasket = JsonConvert.DeserializeObject<List<int>>(HttpContext.Session.GetString("basket")).ToList();
                var blc = new blcours();
                var courss = blc.searchbyids(listbasket);
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                blorder blo = new blorder();
                var listOrder = new List<Order_cours>();
                foreach (var item in courss)
                {
                    listOrder.Add(new Order_cours { coursId = item.id });
                }
                blo.create(new Order {
                    totalpric = courss.Sum(s => s.price),
                    cours = listOrder,
                    userid = user.Id });
            };
            return RedirectToAction("index","Profile",new { masege= "پرداخت با موققیت انجام شد " },"active");


        } 
        public IActionResult Index()
        {
            return View();
        }
    }
}
