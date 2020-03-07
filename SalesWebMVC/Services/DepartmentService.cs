using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services {
    public class DepartmentService {
        private readonly SalesWebMVCContext _context;

        public DepartmentService(SalesWebMVCContext context) {
            _context = context;
        }

        public async Task <List<Department>> FindAllAsync() {
            //linq prepara a consulta apenas
            //to list é o que transforma a expressão para listar
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }

    }
}
