using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Domain.Entites;
using InvestmentPoint.Admin.Persistence;
using InvestmentPoint.Admin.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This is implementation of IEmployeeService
/// </summary>
namespace InvestmentPoint.Admin.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Employee
        /// <summary>
        /// This service method is implemented to add employee.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> AddEmployee(EmployeeModel model)
        {
            try
            {
               if(!string.IsNullOrEmpty(model.Email))
                {
                    Employee employee = new()
                    {
                        Name = model.Name,
                        MobileNo = model.MobileNo,
                        Email = model.Email,
                        AadharNo = model.AadharNo,
                        Password = model.Password
                    };
                    await _context.Employees.AddAsync(employee);
                    await _context.SaveChangesAsync();
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }

        #endregion
    }
}
