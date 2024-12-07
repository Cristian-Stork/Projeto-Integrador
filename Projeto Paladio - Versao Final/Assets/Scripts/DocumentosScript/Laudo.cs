using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Laudo : MonoBehaviour
{
    [HideInInspector] public int diagnostico;
    [HideInInspector] public int cda;

    [Header("Texto do Laudo")]
    public TextMeshProUGUI nomeText;
    public TextMeshProUGUI rpfText;
    public TextMeshProUGUI ddnText;
    public TextMeshProUGUI sexoText;
    public TextMeshProUGUI cdaText;
    public TextMeshProUGUI ndrText;

    [Header("Carimbos do Laudo")]
    public GameObject cd;
    private Image cdImage;

    public static Laudo instance;

    // Start is called before the first frame update
    void Start()
    {
        cdImage = cd.GetComponent<Image>();

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GerarInformacoesLaudo()
    {
        CD();
        CDA();

        AtualizarLaudo();
    }

    public void AtualizarLaudo()
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
        cdaText.text = "CDA: " + Random.Range(100, 1000).ToString() + " - 0" + cda;

        if (Gerador.instance.ano > 2106)
        {
            ndrText.text = "Nome do responsavel: \n" + Gerador.instance.ndr;
        }

        else
        {
            ndrText.text = "Nome do responsavel: ";
        }
    }

    public void CD()
    {
        diagnostico = Random.Range(1, 7);

        if (Gerador.instance.pedidoAbuso == true)
        {
            cdImage.color = new Color(0.9339623f, 0.4625756f, 0.771394f, 1);
        }

        else if (Gerador.instance.invalido == false)
        {
            switch (diagnostico)
            {
                case 1:
                    cdImage.color = Color.green;
                    break;

                case 2:
                    cdImage.color = Color.red;
                    break;

                case 3:
                    cdImage.color = Color.yellow;
                    break;

                case 4:
                    cdImage.color = Color.blue;
                    break;

                case 5:
                    cdImage.color = Color.white;
                    break;

                case 6:
                    cdImage.color = new Color(0.9339623f, 0.4625756f, 0.771394f, 1);
                    break;
            }
        }

        else
        {
            Color colorO = cdImage.color;

            while (cdImage.color == colorO)
            {
                switch (Random.Range(1, 7))
                {
                    case 1:
                        cdImage.color = Color.green;
                        break;

                    case 2:
                        cdImage.color = Color.red;
                        break;

                    case 3:
                        cdImage.color = Color.yellow;
                        break;

                    case 4:
                        cdImage.color = Color.blue;
                        break;

                    case 5:
                        cdImage.color = Color.white;
                        break;

                    case 6:
                        cdImage.color = new Color(0.9339623f, 0.4625756f, 0.771394f, 1);
                        break;
                }
            }
        }
    }

    public void CDA()
    {
        if (Gerador.instance.pedidoAbuso == true)
        {
            if (Gerador.instance.invalido == false)
            {
                cda = Random.Range(41, 49);
            }

            else
            {
                cda = Random.Range(10, 41);
            }
        }

        else
        {
            switch (diagnostico)
            {
                case 1:
                    cda = Random.Range(10, 20);
                    break;

                case 2:
                    cda = Random.Range(20, 25);
                    break;

                case 3:
                    cda = Random.Range(25, 31);
                    break;

                case 4:
                    cda = Random.Range(31, 34);
                    break;

                case 5:
                    cda = Random.Range(34, 41);
                    break;

                case 6:
                    cda = Random.Range(41, 49);
                    break;
            }
        }
    }
}
