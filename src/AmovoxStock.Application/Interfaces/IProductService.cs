using AmovoxStock.Application.Common.Models;
using AmovoxStock.Application.Dtos.Product;


namespace AmovoxStock.Application.Interfaces;

public interface IProductService
{
    Task<BaseResponse<PagedResponse<ProductDto>>> GetAllAsync(ProductRequest request);
    Task<BaseResponse<ProductDto>> GetByIdAsync(int id);
    Task<BaseResponse<int>> CreateProductAsync(CreateProductRequest request);
    Task<BaseResponse<ProductDto>> UpdateProductAsync(int id, UpdateProductRequest request);
    Task<BaseResponse<bool>> DeleteProductAsync(DeleteProductRequest request);
}