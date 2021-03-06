﻿using System;
using System.Collections.Generic;
using System.Text;
using KeepHome.Models;

namespace KeepHome.Services.Contracts
{
    public interface IChildCategoryService
    {
        IEnumerable<ChildCategory> GetChildCategories();

        ChildCategory GetChildCategoryById(int id);

        ChildCategory CreateChildCategory(string name, int categoryId,string imageUrl);

        bool EditChildCategory(int id, string name, int categoryId,string imageUrl);

        bool DeleteChildCategory(int id);
    }
}
