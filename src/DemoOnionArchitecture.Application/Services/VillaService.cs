using DemoOnionArchitecture.Application.Abstract;
using DemoOnionArchitecture.DataAccess.Interface;
using DemoOnionArchitecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOnionArchitecture.Application.Services
{
    public class VillaService : IVillaService
    {
        private readonly IUnitOfWork unitOfWork;

        public VillaService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Villa>> GetList()
        {
            var resukst = await unitOfWork.Villas.GetList();
            return resukst;
        }
    }
}
