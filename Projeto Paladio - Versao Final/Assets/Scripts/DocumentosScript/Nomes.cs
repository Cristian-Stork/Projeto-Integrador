using System.Collections;
using System.Collections.Generic;

public class Nomes
{
    private List<string> feminino = new List<string>();
    private List<string> masculino = new List<string>();
    private List<string> sobrenome = new List<string>();

    public List<string> Masculino { get => masculino; set => masculino = value; }
    public List<string> Feminino { get => feminino; set => feminino = value; }
    public List<string> Sobrenome { get => sobrenome; set => sobrenome = value; }
}