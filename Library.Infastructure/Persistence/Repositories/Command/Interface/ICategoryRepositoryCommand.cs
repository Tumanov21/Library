﻿using Library.Domain.Entities;

namespace Library.Infastructure.Data.Repositories.Command.Interface
{
    public interface ICategoryRepositoryCommand
    {
        Task Add(Category category);
        Task Remove(int Id);
        Task Update(Category category);
    }
}