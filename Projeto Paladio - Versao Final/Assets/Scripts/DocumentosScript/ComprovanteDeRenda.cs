using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ComprovanteDeRenda : MonoBehaviour
{
    [HideInInspector] private int janelas;
    [HideInInspector] private int carros;

    [HideInInspector] private string casaCorNome;
    [HideInInspector] private string carroCor1Nome;
    [HideInInspector] private string carroCor2Nome;

    [Header("Renderes do Comprovante de Renda")]
    public SpriteRenderer casaSprite;
    public SpriteRenderer carro1Sprite;
    public SpriteRenderer carro2Sprite;

    [Header("Texto do Comprovante de Renda")]
    public TextMeshProUGUI casaText;
    public TextMeshProUGUI carro1Text;
    public TextMeshProUGUI carro2Text;

    public static ComprovanteDeRenda instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void GerarInformacoesCDR()
    {
        Renda();
        Cor();

        AtualizarCDR();
    }

    public void AtualizarCDR()
    {
        //casaSprite.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Casas/" + janelas + " janelas.png");

        if (carros != 0)
        {
            //carro1Sprite.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Carros/" + carros + " carro.png");
            carro1Sprite.enabled = true;
        }

        else
        {
            carro1Sprite.enabled = false;
        }

        if (carros == 0)
        {
            carro1Sprite.enabled = false;
            carro2Sprite.enabled = false;
        }

        else if (carros == 1)
        {
            //carro1Sprite.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Carros/1 carro.png");
            carro1Sprite.enabled = true;
            carro2Sprite.enabled = false;
        }

        else if (carros == 2)
        {
            //carro1Sprite.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Carros/1 carro.png");
            //carro2Sprite.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Carros/2 carro.png");
            carro1Sprite.enabled = true;
            carro2Sprite.enabled = true;
        }

        casaText.text = "Cor da casa: " + casaCorNome;

        if (carros == 0)
        {
            carro1Text.text = " ";
            carro2Text.text = " ";
        }

        else if (carros == 1)
        {
            carro1Text.text = "Cor do carro: " + carroCor1Nome;
        }

        else if (carros == 2)
        {
            carro1Text.text = "Cor do carro: " + carroCor1Nome;
            carro2Text.text = "Cor do outro carro: " + carroCor2Nome;
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

        //else if (Gerador.instance.pedidoPobreza == true && Gerador.instance.invalido == false)
        //{
        //    do
        //    {
        //        renda = 0;

        //        janelas = Random.Range(1, 5);

        //        carros = Random.Range(0, 3);

        //        renda += CalcularRenda(janelas, 1000);

        //        renda += CalcularRenda(carros, 1500);
        //    }
        //    while (renda > 3500);
        //}

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

        //else if (Gerador.instance.pedidoPobreza == true && Gerador.instance.invalido == true)
        //{
        //    do
        //    {
        //        renda = 0;

        //        janelas = Random.Range(1, 5);

        //        carros = Random.Range(0, 3);

        //        renda += CalcularRenda(janelas, 1000);

        //        renda += CalcularRenda(carros, 1500);
        //    }
        //    while (renda <= 3500);
        //}
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

    public void Cor()
    {
        if (Gerador.instance.invalido == false)
        {
            casaCorNome = EscolherCor(casaCorNome, casaSprite);

            carroCor1Nome = EscolherCor(carroCor1Nome, carro1Sprite);
            carroCor2Nome = EscolherCor(carroCor2Nome, carro2Sprite);
        }

        else
        {
            int nSorteado = Random.Range(1, 3);

            if (nSorteado == 1)
            {
                casaCorNome = EscolherCorInvalido(casaCorNome);
            }

            else
            {
                if (carros == 0)
                {
                    casaCorNome = EscolherCorInvalido(casaCorNome);
                }

                else if (carros == 1)
                {
                    carroCor1Nome = EscolherCorInvalido(carroCor1Nome);
                }

                else if (carros == 2)
                {
                    nSorteado = Random.Range(1, 3);

                    if (nSorteado == 1)
                    {
                        carroCor1Nome = EscolherCorInvalido(carroCor1Nome);
                    }

                    if (nSorteado == 1)
                    {
                        carroCor2Nome = EscolherCorInvalido(carroCor2Nome);
                    }
                }
            }
        }
    }

    public string EscolherCor(string bensCor, SpriteRenderer bensSprite)
    {
        switch (Random.Range(1, 5))
        {
            case 1:
                bensCor = "Azul";
                bensSprite.color = Color.blue;
                break;

            case 2:
                bensCor = "Amarelo";
                bensSprite.color = Color.yellow;
                break;

            case 3:
                bensCor = "Vermelho";
                bensSprite.color = Color.red;
                break;

            case 4:
                bensCor = "Branco";
                bensSprite.color = Color.white;
                break;
        }

        return bensCor;
    }

    public string EscolherCorInvalido(string bensCor)
    {
        switch (bensCor)
        {
            case "Azul":
                switch (Random.Range (1, 4))
                {
                    case 2:
                        bensCor = "Amarelo";
                        break;

                    case 3:
                        bensCor = "Vermelho";
                        break;

                    case 4:
                        bensCor = "Branco";
                        break;
                }
                break;

            case "Amarelo":
                switch (Random.Range(1, 4))
                {
                    case 2:
                        bensCor = "Azul";
                        break;

                    case 3:
                        bensCor = "Vermelho";
                        break;

                    case 4:
                        bensCor = "Branco";
                        break;
                }
                break;

            case "Vermelho":
                switch (Random.Range(1, 4))
                {
                    case 2:
                        bensCor = "Amarelo";
                        break;

                    case 3:
                        bensCor = "Azul";
                        break;

                    case 4:
                        bensCor = "Branco";
                        break;
                }
                break;

            case "Branco":
                switch (Random.Range(1, 4))
                {
                    case 2:
                        bensCor = "Amarelo";
                        break;

                    case 3:
                        bensCor = "Vermelho";
                        break;

                    case 4:
                        bensCor = "Azul";
                        break;
                }
                break;
        }

        return bensCor;
    }
}
