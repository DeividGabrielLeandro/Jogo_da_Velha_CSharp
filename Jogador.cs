namespace Jogo;
public class Jogador
{

    public string Nome { get; set; }
    public char Simbolo { get; set; }

    public Jogador(char Simbolo, string Nome)
    {
        this.Nome = Nome;
        this.Simbolo = Simbolo;
    }
}



public class Maquina
{

    public string NomeMaquina { get; set; }
    public char SimboloMaquina { get; set; }

    public Maquina(char SimboloMaquina, string NomeMaquina)
    {
        this.NomeMaquina = NomeMaquina;
        this.SimboloMaquina = SimboloMaquina;

    }
}





