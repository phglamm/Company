using Company.Data;
using Company.Interface;
using Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Department>> GetAllDepartmentAsync()
        {
            return await _context.Departments.Include(u => u.Users).ToListAsync();
        }

        public async Task<Department> AddDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return (department);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var deletedDepartment = await _context.Departments.FindAsync(id);
            if (deletedDepartment != null)
            {
                _context.Departments.Remove(deletedDepartment);
                _context.SaveChangesAsync();
            }

        }


        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var department = await _context.Departments.Include(u => u.Users).FirstOrDefaultAsync(d => d.DepartmentId == id);
            return (department);

        }

        public async Task<Department> UpdateDepartmentAsync(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return (department);
        }
    }
}
