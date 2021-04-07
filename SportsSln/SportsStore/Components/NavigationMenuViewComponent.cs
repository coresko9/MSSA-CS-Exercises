using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;
using System.Collections.Generic;
namespace SportsStore.Components
{



    public class NavigationMenuViewComponent : ViewComponent
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        private IStoreRepository repository;
        public NavigationMenuViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
            
        }
        
    }
}

