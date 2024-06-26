﻿using CleanArchitecture.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<CategoryDTO> GeByIdAsync(int? id);
        Task Add(CategoryDTO categoryDto);
        Task Update(CategoryDTO categoryDto);
        Task Remove(int? id);
    }
}
