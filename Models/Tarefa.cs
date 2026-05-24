namespace CanteiroAPI.Models;

public class Tarefa
{
    public int Id {get; set;}
    public string Descricao {get; set;} = string.Empty;
    public string Status {get; set;} = "Pendente";
    public DateTime DataPrazo {get; set;}
    public int FuncionarioId {get; set;}
    public Funcionario? Funcionario{get; set;}
    public int EquipamentoId {get; set;}
    public Equipamento? Equipamento{get; set;}
}