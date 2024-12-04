using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HistoricoEscolar : MonoBehaviour
{
    [HideInInspector] public int notaLinguagem;
    [HideInInspector] public int notaCieHumanas;
    [HideInInspector] public int notaCieNatureza;
    [HideInInspector] public int notaMatematica;

    private List<string> comunicacao = new List<string>();
    private List<string> tecnologia = new List<string>();
    private List<string> artes = new List<string>();
    private List<string> natureza = new List<string>();

    [HideInInspector] public string curso;

    [Header("Texto do Historico Escolar")]
    public TextMeshProUGUI nomeText;
    public TextMeshProUGUI ddnText;
    public TextMeshProUGUI sexoText;
    public TextMeshProUGUI linguagemText;
    public TextMeshProUGUI cieHumanasText;
    public TextMeshProUGUI cieNaturezaText;
    public TextMeshProUGUI matematicaText;
    public TextMeshProUGUI cursoText;

    public static HistoricoEscolar instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void GerarInformacoesHE()
    {
        Cursos();
        Notas();

        AtualizarHE();
    }

    public void AtualizarHE()
    {
        nomeText.text = "Nome: " + Gerador.instance.nome + " " + Gerador.instance.sobrenome;
        ddnText.text = "DDN: " + Gerador.instance.dia.ToString() + "/" + Gerador.instance.mes.ToString() + "/" + Gerador.instance.ano.ToString();
        sexoText.text = "Sexo: " + Gerador.instance.sexo;
        linguagemText.text = "Linguagem: " + notaLinguagem.ToString();
        cieHumanasText.text = "Ciências humanas: " + notaCieHumanas.ToString();
        cieNaturezaText.text = "Ciências da natureza: " + notaCieNatureza.ToString();
        matematicaText.text = "Matematica: " + notaMatematica.ToString();
        cursoText.text = "Curso: " + curso;
    }

    public void Cursos()
    {
        comunicacao.Clear();
        tecnologia.Clear();
        artes.Clear();
        natureza.Clear();

        comunicacao.Add("Comércio exterior");
        comunicacao.Add("Publicidade");

        tecnologia.Add("TI");
        tecnologia.Add("Engenharia");

        artes.Add("Design");
        artes.Add("Artes");

        natureza.Add("Biologia");
        natureza.Add("Quimica");

        switch (Random.Range(1, 5))
        {
            case 1:
                curso = comunicacao[Random.Range(0, comunicacao.Count)];
                break;

            case 2:
                curso = tecnologia[Random.Range(0, tecnologia.Count)];
                break;

            case 3:
                curso = artes[Random.Range(0, artes.Count)];
                break;

            case 4:
                curso = natureza[Random.Range(0, natureza.Count)];
                break;
        }
    }

    public void Notas()
    {
        if (Gerador.instance.invalido == false)
        {
            switch (curso)
            {
                case "Comércio exterior":
                    notaLinguagem = Random.Range(7, 11);

                    notaMatematica = Random.Range(4, 11);
                    notaCieHumanas = Random.Range(4, 11);
                    notaCieNatureza = Random.Range(4, 11);
                    break;

                case "Publicidade":
                    notaLinguagem = Random.Range(7, 11);

                    notaMatematica = Random.Range(4, 11);
                    notaCieHumanas = Random.Range(4, 11);
                    notaCieNatureza = Random.Range(4, 11);
                    break;

                case "TI":
                    notaMatematica = Random.Range(7, 11);

                    notaLinguagem = Random.Range(4, 11);
                    notaCieHumanas = Random.Range(4, 11);
                    notaCieNatureza = Random.Range(4, 11);
                    break;

                case "Engenharia":
                    notaMatematica = Random.Range(7, 11);

                    notaLinguagem = Random.Range(4, 11);
                    notaCieHumanas = Random.Range(4, 11);
                    notaCieNatureza = Random.Range(4, 11);
                    break;

                case "Design":
                    notaCieHumanas = Random.Range(6, 11);

                    notaLinguagem = Random.Range(4, 11);
                    notaMatematica = Random.Range(4, 11);
                    notaCieNatureza = Random.Range(4, 11);
                    break;

                case "Artes":
                    notaCieHumanas = Random.Range(6, 11);

                    notaLinguagem = Random.Range(4, 11);
                    notaMatematica = Random.Range(4, 11);
                    notaCieNatureza = Random.Range(4, 11);
                    break;

                case "Biologia":
                    notaCieNatureza = Random.Range(6, 11);

                    notaLinguagem = Random.Range(4, 11);
                    notaMatematica = Random.Range(4, 11);
                    notaCieHumanas = Random.Range(4, 11);
                    break;

                case "Quimica":
                    notaCieNatureza = Random.Range(6, 11);

                    notaLinguagem = Random.Range(4, 11);
                    notaMatematica = Random.Range(4, 11);
                    notaCieHumanas = Random.Range(4, 11);
                    break;
            }
        }

        else
        {
            switch (curso)
            {
                case "Comércio exterior":
                    notaLinguagem = Random.Range(4, 7);

                    notaMatematica = Random.Range(4, 11);
                    notaCieHumanas = Random.Range(4, 11);
                    notaCieNatureza = Random.Range(4, 11);
                    break;

                case "Publicidade":
                    notaLinguagem = Random.Range(4, 7);

                    notaMatematica = Random.Range(4, 11);
                    notaCieHumanas = Random.Range(4, 11);
                    notaCieNatureza = Random.Range(4, 11);
                    break;

                case "TI":
                    notaMatematica = Random.Range(4, 7);

                    notaLinguagem = Random.Range(4, 11);
                    notaCieHumanas = Random.Range(4, 11);
                    notaCieNatureza = Random.Range(4, 11);
                    break;

                case "Engenharia":
                    notaMatematica = Random.Range(4, 7);

                    notaLinguagem = Random.Range(4, 11);
                    notaCieHumanas = Random.Range(4, 11);
                    notaCieNatureza = Random.Range(4, 11);
                    break;

                case "Design":
                    notaCieHumanas = Random.Range(4, 6);

                    notaLinguagem = Random.Range(4, 11);
                    notaMatematica = Random.Range(4, 11);
                    notaCieNatureza = Random.Range(4, 11);
                    break;

                case "Artes":
                    notaCieHumanas = Random.Range(4, 6);

                    notaLinguagem = Random.Range(4, 11);
                    notaMatematica = Random.Range(4, 11);
                    notaCieNatureza = Random.Range(4, 11);
                    break;

                case "Biologia":
                    notaCieNatureza = Random.Range(4, 6);

                    notaLinguagem = Random.Range(4, 11);
                    notaMatematica = Random.Range(4, 11);
                    notaCieHumanas = Random.Range(4, 11);
                    break;

                case "Quimica":
                    notaCieNatureza = Random.Range(4, 6);

                    notaLinguagem = Random.Range(4, 11);
                    notaMatematica = Random.Range(4, 11);
                    notaCieHumanas = Random.Range(4, 11);
                    break;
            }
        }
    }
}
