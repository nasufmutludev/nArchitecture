using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Brands.Rules
{
    public class BrandEntityBusinessRules
    {
        private readonly IBrandRepository _brandRepository;


        public BrandEntityBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Brand> result = await _brandRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Brand name exists.");
        }

        //public async Task BrandShouldExistWhenRequested(int id)
        //{
        //    Brand brand = await _brandRepository.GetAsync(b => b.Id == id);
        //    if (brand == null) throw new BusinessException("Requested brand does not exists.");
        //}

        public void BrandShouldExistWhenRequested(Brand brand)
        {
            if (brand == null) throw new BusinessException("Requested brand does not exists.");
        }
    }
}
