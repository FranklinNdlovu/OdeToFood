using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{

    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IHtmlHelper HtmlHelper { get; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            HtmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = HtmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetRestaurantById(restaurantId.Value);
            }
            else
                Restaurant = new Restaurant();
            if (this.Restaurant == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                Cuisines = HtmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            if (Restaurant.Id > 0)
                Restaurant = restaurantData.UpdateRestaurant(Restaurant);
            else
                Restaurant = restaurantData.AddRestaurant(Restaurant);

            restaurantData.Commit();
            TempData["Message"] = "Restaurant has been saved";
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}
