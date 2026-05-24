namespace CanteiroAPI.Models;

public class Funcionario
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public string CPF {get; set;} = string.Empty;
    public string Cargo {get; set;} = string.Empty;
    public string Status {get; set;} = "Ativo";
}