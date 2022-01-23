using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEE;
using BLL;
namespace webstor.ViewsComponenets.cours
{
    public class CourssViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blcours = new blcours();

            return View(blcours.readall_cours());
        }
    }
}
