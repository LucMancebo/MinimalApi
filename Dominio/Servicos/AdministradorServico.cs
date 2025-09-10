using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.DTOs;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.infraestrutura.Db;


namespace MinimalApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _context;
    public AdministradorServico(DbContexto context)
    {
        _context = context;
    }

    public Administrador? Login(LoginDTO loginDTO)
    {
        var adm = _context.Administradores.Where
        (a => a.Email == loginDTO.Email && a.Password == loginDTO.Password).FirstOrDefault();
        return adm;
        
    }


}
