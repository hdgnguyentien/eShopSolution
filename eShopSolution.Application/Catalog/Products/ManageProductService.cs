﻿using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Manage;
using eShopSolution.Application.Dtos;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDbContext _context;
        public ManageProductService(EShopDbContext context) { _context = context; }

        public async Task AddViewcount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice= request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated= DateTime.Now,
                ProductTranslations = new List<ProductTranslation> { new ProductTranslation()
                {
                    Name = request.Name,
                    Description= request.Description,
                    Details= request.Details,
                    SeoDescription= request.SeoDescription,
                    SeoAlias = request.SeoAlias,
                    SeoTitle= request.SeoTitle,
                    LanguageId= request.LanguageId,
                } }
            };
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EShopException($"Cannot find a product: {productId}");

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            //1 select join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        where pt.Name.Contains(request.Keyword)
                        select new { p, pt,pic };
            //2 filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            }
            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }
            //3 paging
            int totalRow = await query.CountAsync();

            var data  = await query.Skip((request.PageIndex - 1)*request.PageSize).
                Take(request.PageSize).
                Select(x=>new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated= x.p.DateCreated,
                    Description= x.pt.Description,
                    Details= x.pt.Details,
                    LanguageId= x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription= x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                }).
                ToListAsync();

            //4 select and projection
            var pagedResult  = new PageResult<ProductViewModel>() { 
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslations = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id
            && x.LanguageId == request.LanguageId);

            if (product == null)
            {
                throw new EShopException($"Cannot find a product with id: {request.Id}");
            }
            productTranslations.Name = request.Name;
            productTranslations.Description = request.Description;
            productTranslations.SeoDescription= request.SeoDescription;
            productTranslations.SeoTitle= request.SeoTitle;
            productTranslations.SeoAlias= request.SeoAlias;
            productTranslations.Description= request.Description;
            productTranslations.Details = request.Details;
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) { throw new EShopException($"Cannot find a product with id: {productId}"); }
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) { throw new EShopException($"Cannot find a product with id: {productId}"); }
            product.Price += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
