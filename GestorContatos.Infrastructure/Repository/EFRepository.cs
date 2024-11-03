﻿using GestorContatos.Core.Entities.Base;
using GestorContatos.Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace GestorContatos.Infrastructure.Repository;
public class EFRepository<T> : IRepository<T> where T : EntityBase
{
    protected ApplicationDbContext _context;
    protected DbSet<T> _dbSet;

    public EFRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public void Alterar(T entidade)
    {
        _dbSet.Update(entidade);
        _context.SaveChanges();
    }

    public void Cadastrar(T entidade)
    {
        _dbSet.Add(entidade);
        _context.SaveChanges();
    }

    public void Deletar(int id)
    {
        _dbSet.Remove(ObterPorId(id));
        _context.SaveChanges();
    }

    public T ObterPorId(int id) 
        => _dbSet.FirstOrDefault(entity => entity.Id == id);

    public IList<T> ObterTodos()
        => _dbSet.ToList();
}
