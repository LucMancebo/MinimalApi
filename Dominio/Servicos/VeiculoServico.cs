using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.DTOs;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.infraestrutura.Db;


namespace MinimalApi.Dominio.Servicos;

public class VeiculoServico : IAdministradorServico
{
    private readonly DbContexto _context;
    public VeiculoServico(DbContexto context)
    {
        _context = context;
    }

    public void Deletar(Veiculo veiculo)
    {
        _context.Veiculos.Remove(veiculo);
        _context.SaveChanges();
    }

    public void Atualizar(Veiculo veiculo)
    {
        _context.Veiculos.Update(veiculo);
        _context.SaveChanges();
    }

    public Veiculo? BuscaPorId(int id)
    {
        return _context.Veiculos.Where(v => v.Id == id).FirstOrDefault();
    }

    public void Incluir(Veiculo veiculo)
    {
        _context.Veiculos.Add(veiculo);
        _context.SaveChanges();
    }

    public List<Veiculo> Todos(string? nome, int pagina = 1, string? marca = null)
    {
        var query = _context.Veiculos.AsQueryable();

        if (!string.IsNullOrEmpty(nome))
        {
            query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{nome}%"));
        }

        int ItensPorPagina = 10;

        query = query.Skip((pagina - 1) * ItensPorPagina).Take(ItensPorPagina);
        return query.ToList();
    }

    public Administrador? Login(LoginDTO loginDTO)
    {
        throw new NotImplementedException();
    }
}
