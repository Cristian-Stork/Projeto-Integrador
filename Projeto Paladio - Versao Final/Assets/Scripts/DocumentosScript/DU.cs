using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DU : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI casoText;
    [SerializeField] private List<TextMeshProUGUI> documentosText = new List<TextMeshProUGUI>();
    [SerializeField] private List<Image> documentosIcone = new List<Image>();
    [SerializeField] private List<string> documentosNome = new List<string>();
    [SerializeField] private List<Sprite> documentosSprite = new List<Sprite>();

    public static DU instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtualizarDU()
    {
        documentosNome.Clear();

        AtualizarCaso();
        AtualizarLista();
        AtualizarIcones();
        AtualizarTexto();
    }


    private void AtualizarCaso()
    {
        casoText.text = "Caso:";

        if (Gerador.instance.pedidoMedico == true)
        {
            casoText.text += " Médico";
            casoText.fontSize = 82.51f;
        }

        if (Gerador.instance.pedidoAbuso == true)
        {
            casoText.text += " Abuso";
            casoText.fontSize = 82.51f;
        }

        if (Gerador.instance.pedidoEscolar == true)
        {
            casoText.text += " Estudantil";
            casoText.fontSize = 65.96f;
        }
    }

    private void AtualizarLista()
    {
        for (var i = 0; i < Gerador.instance.documentosInvalidos.Count; i++)
        {
            documentosNome.Add(Gerador.instance.documentosInvalidos[i]);

            documentosNome[i] = documentosNome[i].Replace("Invalido", "");
        }

        documentosNome.Remove("du");
    }

    private void AtualizarIcones()
    {
        for (var i = 0; i < documentosIcone.Count; i++)
        {
            if (documentosNome.Count > i)
            {
                documentosIcone[i].sprite = Resources.Load<Sprite>(documentosNome[i]);
                documentosIcone[i].enabled = true;
            }

            else
            {
                documentosIcone[i].enabled = false;
            }
        }
    }

    private void AtualizarTexto()
    {
        for (var i = 0; i < documentosText.Count; i++)
        {
            if (documentosNome.Count > i)
            {
                switch (documentosNome[i])
                {
                    case "laudo":
                        documentosText[i].text = "Laudo\nMédico";
                        break;

                    case "bo":
                        documentosText[i].text = "Boletim de\nOcorrência";
                        break;

                    case "he":
                        documentosText[i].text = "Boletim\nEscolar";
                        break;

                    case "cdr":
                        documentosText[i].text = "Comprovante\nde Renda";
                        break;
                }

                documentosText[i].enabled = true;
            }

            else
                documentosText[i].enabled = false;
        }
    }
}
