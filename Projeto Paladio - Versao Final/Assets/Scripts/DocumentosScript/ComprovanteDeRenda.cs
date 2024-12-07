using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ComprovanteDeRenda : MonoBehaviour
{
    private int janelas;
    private int carros;

    [Header("Image")]
    [SerializeField] private Image casaImage;
    [SerializeField] private Sprite[] casaSprite;

    public static ComprovanteDeRenda instance;

    // Start is called before the first frame update
    void Start()
    {
        casaSprite = Resources.LoadAll<Sprite>("Casa 2 shett");

        instance = this;
    }

    public void GerarInformacoesCDR()
    {
        Renda();

        AtualizarCDR();
    }

    public void AtualizarCDR()
    {
        switch (carros)
        {
            case 0:

                if (janelas == 0)
                    casaImage.sprite = casaSprite[12];

                else if (janelas == 1)
                    casaImage.sprite = casaSprite[13];

                else if (janelas == 2)
                    casaImage.sprite = casaSprite[14];

                else if (janelas == 3)
                    casaImage.sprite = casaSprite[11];

                else if (janelas == 4)
                    casaImage.sprite = casaSprite[10];

                break;

            case 1:

                if (janelas == 0)
                    casaImage.sprite = casaSprite[0];

                else if (janelas == 1)
                    casaImage.sprite = casaSprite[1];

                else if (janelas == 2)
                    casaImage.sprite = casaSprite[2];

                else if (janelas == 3)
                    casaImage.sprite = casaSprite[3];

                else if (janelas == 4)
                    casaImage.sprite = casaSprite[4];

                break;

            case 2:

                if (janelas == 0)
                    casaImage.sprite = casaSprite[5];

                else if (janelas == 1)
                    casaImage.sprite = casaSprite[6];

                else if (janelas == 2)
                    casaImage.sprite = casaSprite[7];

                else if (janelas == 3)
                    casaImage.sprite = casaSprite[8];

                else if (janelas == 4)
                    casaImage.sprite = casaSprite[9];

                break;
        }
    }

    public void Renda()
    {
        int renda;

        if (Gerador.instance.pedidoEscolar == true && Gerador.instance.invalido == false)
        {
            do
            {
                renda = 0;

                janelas = Random.Range(1, 5);

                carros = Random.Range(0, 3);

                renda += CalcularRenda(janelas, 1000);

                renda += CalcularRenda(carros, 1500);
            }
            while (renda > 3000);
        }

        else if (Gerador.instance.pedidoEscolar == true && Gerador.instance.invalido == true)
        {
            do
            {
                renda = 0;

                janelas = Random.Range(1, 5);

                carros = Random.Range(0, 3);

                renda += CalcularRenda(janelas, 1000);

                renda += CalcularRenda(carros, 1500);
            }
            while (renda <= 3000);
        }
    }

    public int CalcularRenda(int bens, int valorBens)
    {
        int renda = 0;

        for (int i = 0; i < bens; i++)
        {
            renda += valorBens;
        }

        return renda;
    }
}
