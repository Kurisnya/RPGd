namespace RPGd;

//C: A classe Habilidade representa uma habilidade especial de uma raça/classe.
//Cada habilidade fica vinculada a um nível: o jogador só pode usá-la quando
//atinge o NivelNecessario. Os campos são privados e acessados por propriedades
//(encapsulamento), seguindo o mesmo padrão da classe Equipamento.
public class Habilidade
{
    private string nome;
    public string Nome { get => this.nome; set => this.nome = value; }

    private string descricao;
    public string Descricao { get => this.descricao; set => this.descricao = value; }

    private int nivelNecessario;
    public int NivelNecessario { get => this.nivelNecessario; set => this.nivelNecessario = value; }

    //C: Polimorfismo - sobrescreve ToString para exibir a habilidade já formatada.
    public override string ToString() => $"{Nome} (Nível {NivelNecessario})";
}
