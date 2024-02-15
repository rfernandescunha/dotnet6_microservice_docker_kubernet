﻿using GeekShopping.Api.Domain.Dto;

namespace GeekShopping.Api.Domain.Interfaces.IServices
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductDto>> FindAll();
        Task<ProductDto> FindById(long Id);
        Task<ProductDto> Create(ProductDto product);
        Task<ProductDto> Update(ProductDto product);
        Task<bool> Delete(long Id);
    }
}
