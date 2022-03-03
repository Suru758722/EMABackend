using EMA.Data;
using EMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.Services
{
    public interface IAdminService
    {
        List<string> GetSurwayData();
    }
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;
        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<string> GetSurwayData()
        {
            throw new NotImplementedException();
        }
    }
}
