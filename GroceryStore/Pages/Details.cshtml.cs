using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GroceryStore.Models;

namespace GroceryStore.Pages
{
    public class DetailsModel : PageModel
    {
        public List<GroceryItem> Foods { get; set; }
        public GroceryItem CurrentFood { get; set; }

        public async Task<IActionResult> OnGetAsync(string name)
        {
            Foods = Inventory.ToList();

            // Asynchronous code
            using (StreamWriter writer = new StreamWriter("log.txt", append: true))
            {
                await writer.WriteLineAsync($"{DateTime.Now} {name}");
            }

            CurrentFood = Foods.Find(food => food.Name == name);
            if (CurrentFood == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}