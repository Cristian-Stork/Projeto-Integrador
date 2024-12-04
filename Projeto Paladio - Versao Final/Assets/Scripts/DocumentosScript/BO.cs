using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class BO : MonoBehaviour
{
    [HideInInspector] public int crime;
    [HideInInspector] public int ic1, ic2, ic3;
    [HideInInspector] public string ic4;
    private string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    [HideInInspector] public int[] icPar = {2, 4, 6, 8};
    [HideInInspector] public int[] icInpar = {1, 3, 5, 7, 9};

    [Header("Texto do BO")]
    public TextMeshProUGUI nomeText;
    public TextMeshProUGUI rpfText;
    public TextMeshProUGUI ddnText;
    public TextMeshProUGUI sexoText;
    public TextMeshProUGUI icText;
    public TextMeshProUGUI ndrText;

    [Header("Carimbos do BO")]
    public GameObject co;
    private Image coImage;

    public static BO instance;

    // Start is called before the first frame update
    void Start()
    {
        coImage = co.GetComponent<Image>();

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GerarInformacoesBO()
    {
        CO();
        IC();

        AtualizarBO();
    }

    public void AtualizarBO()
    {
        nomeText.text = "Nome: " + Gerador.instance.nome + " " + Gerador.instance.sobrenome;
        rpfText.text = "RPF: " + Gerador.instance.rpfL + " - " + Gerador.instance.rpfN;

        if (Gerador.instance.dia < 10)
        {
            ddnText.text = "DDN: " + "0" + Gerador.instance.dia.ToString();
        }

        else
        {
            ddnText.text = "DDN: " + Gerador.instance.dia.ToString();
        }

        if (Gerador.instance.mes < 10)
        {
            ddnText.text = ddnText.text + "/0" + Gerador.instance.mes.ToString();
        }

        else
        {
            ddnText.text = ddnText.text + "/" + Gerador.instance.mes.ToString();
        }

        ddnText.text = ddnText.text + "/" + Gerador.instance.ano.ToString();

        sexoText.text = "Sexo: " + Gerador.instance.sexo;
        icText.text = "IC: " + ic1.ToString() + ic2.ToString() + ic3.ToString() + " - " + ic4.ToString();

        if (Gerador.instance.ano > 2106)
        {
            ndrText.text = "Nome do responsavel: " + Gerador.instance.ndr;
        }

        else
        {
            ndrText.text = "Nome do responsavel: ";
        }
    }

    public void CO()
    {
        crime = Random.Range(1, 5);

        if (Gerador.instance.invalido == false)
        {
            switch (crime)
            {
                case 1:
                    coImage.color = Color.yellow;
                    break;

                case 2:
                    coImage.color = Color.red;
                    break;

                case 3:
                    coImage.color = Color.green;
                    break;

                case 4:
                    coImage.color = Color.blue;
                    break;
            }
        }

        else
        {
            Color colorO = coImage.color;

            while (coImage.color == colorO)
            {
                switch (Random.Range(1, 5))
                {
                    case 1:
                        coImage.color = Color.yellow;
                        break;

                    case 2:
                        coImage.color = Color.red;
                        break;

                    case 3:
                        coImage.color = Color.green;
                        break;

                    case 4:
                        coImage.color = Color.blue;
                        break;
                }
            }
        }
    }

    public void IC()
    {
        switch (crime)
        {
            case 1:
                ic1 = icPar[Random.Range(0, icPar.Length)];
                ic2 = icPar[Random.Range(0, icPar.Length)];
                break;

            case 2:
                ic1 = icInpar[Random.Range(0, icInpar.Length)];
                ic2 = icInpar[Random.Range(0, icInpar.Length)];
                break;

            case 3:
                ic1 = icPar[Random.Range(0, icPar.Length)];
                ic2 = icInpar[Random.Range(0, icInpar.Length)];
                break;

            case 4:
                ic1 = icInpar[Random.Range(0, icInpar.Length)];
                ic2 = icPar[Random.Range(0, icPar.Length)];
                break;
        }

        ic3 = Random.Range(1, 10);

        ic4 = letras[Random.Range(0, letras.Length)].ToString();
    }
}
