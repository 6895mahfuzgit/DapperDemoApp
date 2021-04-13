using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DapperDemoApp.Context;
using DapperDemoApp.Models;
using DapperDemoApp.Repository.Interface;
using DapperDemoApp.Repository;

namespace DapperDemoApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICompanyRepository _companyRepository;

        public EmployeesController(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository)
        {
            _employeeRepository = employeeRepository;
            _companyRepository = companyRepository;
        }



        // GET: Employees
        public async Task<IActionResult> Index()
        {
            //var applicationDBContext =_employeeRepository.GetAll() //_context.Employees.Include(e => e.Company);
            var employees = _employeeRepository.GetAll();
            var allEmployee = employees.Result;
            return View(allEmployee);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeRepository.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee.Result);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {

            var companies = _companyRepository.GetAll();
            ViewData["CompanyId"] = new SelectList(companies.Result, "CompanyId", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Name,Email,Title,Phone,CompanyId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            var companies = _companyRepository.GetAll();
            ViewData["CompanyId"] = new SelectList(companies.Result, "CompanyId", "Name", employee.EmployeeId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeRepository.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            var companies = _companyRepository.GetAll();
            ViewData["CompanyId"] = new SelectList(companies.Result, "CompanyId", "Name", employee.Result.EmployeeId);
            return View(employee.Result);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Name,Email,Title,Phone,CompanyId")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _employeeRepository.Update(employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var companies = _companyRepository.GetAll();
            ViewData["CompanyId"] = new SelectList(companies.Result, "CompanyId", "Name", employee.EmployeeId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _employeeRepository.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee.Result);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = _employeeRepository.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _employeeRepository.IsEmployeeExists(id);
        }
    }
}
