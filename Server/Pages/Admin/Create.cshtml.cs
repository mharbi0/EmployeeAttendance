using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Server.Models;

namespace Server.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public CreateModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EmployeeDTO Employee { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Invalid request";
                return Page();
            }

            //_context.Employees.Add(Employee);
            //await _context.SaveChangesAsync();

            await _httpClient.PostAsJsonAsync("/api/employee/", Employee);

            TempData["success"] = "Employee added successfully";
            return RedirectToPage("./Index");
        }
    }
}
