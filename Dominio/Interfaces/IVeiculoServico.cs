using MinimalApi.Dominio.DTOs;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Dominio.Interfaces;

public interface IVeiculoServico
{
    List<Veiculo> Todos(string? nome, int pagina = 1, string? marca = null);

    Veiculo? BuscaPorId(int id);

    void Incluir (Veiculo veiculo);

    void Atualizar(Veiculo veiculo);

    void Deletar(Veiculo veiculo);

}