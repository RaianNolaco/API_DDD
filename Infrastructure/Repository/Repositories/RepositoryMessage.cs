using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Repositories
{
    internal class RepositoryMessage : RepositoryGenerics<Message>, IMessage
    {
        private readonly DbContextOptions<ContextBase> _OptionBuilder;

        public RepositoryMessage()
        {
            //Commit 
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }
    
    }
}
