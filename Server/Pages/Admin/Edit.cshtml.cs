using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public EditModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public EmployeeDTO Employee { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {

            //var employee =  await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeId == id);
            var employee = await _httpClient.GetAsync("/api/employee/" + id);
            if (employee == null)
            {
                return NotFound();
            }
            //Employee = employee.Content;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    TempData["error"] = "Invalid request";
            //    return Page();
            //}

            //_context.Attach(Employee).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!EmployeeExists(Employee.EmployeeId))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //TempData["success"] = "Employee details edited successfully";
            return RedirectToPage("./Index");
        }

        //private bool EmployeeExists(int id)
        //{
        //  return _context.Employees.Any(e => e.EmployeeId == id);
        //}
    }
}
