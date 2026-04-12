namespace RPGd;

public class Equipamento
{
    private string nome;
    public string Nome{get => this.nome; set => this.nome=value;}
    private string tipo;
    public string Tipo{get => this.tipo; set => this.tipo=value;}

    private double atq;
    public double Atq{get => this.atq; set => this.atq=value;}

    private double def;
    public double Def{get => this.def; set => this.def=value;}

    public string Descrição;
    public string Imagem;
}