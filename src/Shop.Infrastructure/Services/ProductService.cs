using Microsoft.EntityFrameworkCore;
using Shop.Core.DTO.Responses;
using Shop.Core.Entities;
using Shop.Core.Interfaces;
using Shop.Core.Interfaces.Repositories;
using Shop.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Productos>> FindAllAsync()
        {
            return await this._productRepository.FindAll().ToListAsync();
        }

        public Productos FindById(int id)
        {
            return this._productRepository.FindById(id);
        }

        public async Task<BaseCRUDResponse> SaveAsync(Productos product)
        {
            try
            {
                this._productRepository.Add(product);
                await _unitOfWork.CompleteAsync();

                return new SuccessCRUDResponse("Producto creado", product);
            }
            catch (Exception e)
            {
                return new ErrorCRUDResponse(e.Message, 400);
            }
        }

        public async Task<BaseCRUDResponse> UpdateAsync(int id, Productos product)
        {
            var result = this._productRepository.FindById(id);
            if (result == null)
            {
                return new ErrorCRUDResponse($"No existe producto con id {id}", 404);
            }

            result.Marca = product.Marca;
            result.Nombre = product.Nombre;
            result.PrecioUnitario = product.PrecioUnitario;
            result.Stock = product.Stock;
            result.Tipo = product.Tipo;
            result.Unidades = product.Unidades;

            this._productRepository.Update(result);
            await _unitOfWork.CompleteAsync();

            return new SuccessCRUDResponse("Producto actualizado", result);
        }

        public async Task<BaseCRUDResponse> DeleteAsync(int id)
        {
            var result = this._productRepository.FindById(id);
            if (result == null)
            {
                return new ErrorCRUDResponse($"No existe producto con id {id}", 404);
            }

            this._productRepository.Delete(result);
            await _unitOfWork.CompleteAsync();

            return new SuccessCRUDResponse("Producto eliminado", result);
        }
    }
}