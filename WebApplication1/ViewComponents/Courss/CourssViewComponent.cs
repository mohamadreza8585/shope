using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using BEE;
using BLL;
namespace webstor.ViewsComponenets.cours
{
    public class CourssViewComponent : ViewComponent
    {
        public async Task< IViewComponentResult> InvokeAsync()
        {
            var blcours = new blcours();
            var list =  blcours.readall_cours();
            return View(list);
        }
    }
}
