using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Interfaces.Api;

namespace WebStore.Controllers
{
    public class WebAPITestController : Controller
    {
        readonly IValuesService _Values;
        public WebAPITestController(IValuesService value)
        {
            _Values = value;
        }
        public async Task<IActionResult> Index()
        {
            var tempValue = await _Values.GetAsync();
            return View(tempValue);
        }
    }
}