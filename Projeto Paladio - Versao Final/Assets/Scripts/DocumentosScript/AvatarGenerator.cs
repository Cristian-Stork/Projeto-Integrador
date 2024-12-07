using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarGenerator : MonoBehaviour
{
    public Sprite[] peleSpritesA;
    public Sprite[] peleSpritesB;
    public Sprite[] peleSpritesN;

    public Sprite[] olhosSpritesA;
    public Sprite[] olhosSpritesB;
    public Sprite[] olhosSpritesN;
    
    public Sprite[] narizSpritesA;
    public Sprite[] narizSpritesB;
    public Sprite[] narizSpritesN;
    
    public Sprite[] cabelosMasculinos;
    public Sprite[] cabelosFemininos;
    
    public Sprite[] bocaMasculinaA;
    public Sprite[] bocaMasculinaB;
    public Sprite[] bocaMasculinaN;
   
    public Sprite[] bocaFemininaA;
    public Sprite[] bocaFemininaB;
    public Sprite[] bocaFemininaN;

    public Sprite[] corposSprites;

    public Image peleImage;
    public Image cabeloImage;
    public Image olhosImage;
    public Image bocaImage;
    public Image narizImage;
    public Image corpoImage;

    private string raca;

    public static AvatarGenerator instance;

    // Start is called before the first frame update
    void Start()
    {
        peleSpritesA = Resources.LoadAll<Sprite>("Pele/Asiatico");
        peleSpritesB = Resources.LoadAll<Sprite>("Pele/Branco");
        peleSpritesN = Resources.LoadAll<Sprite>("Pele/Negro");

        olhosSpritesA = Resources.LoadAll<Sprite>("Olhos/Asiatico");
        olhosSpritesB = Resources.LoadAll<Sprite>("Olhos/Branco");
        olhosSpritesN = Resources.LoadAll<Sprite>("Olhos/Negro");

        narizSpritesA = Resources.LoadAll<Sprite>("Nariz/Asiatico");
        narizSpritesB = Resources.LoadAll<Sprite>("Nariz/Branco");
        narizSpritesN = Resources.LoadAll<Sprite>("Nariz/Negro");

        cabelosMasculinos = Resources.LoadAll<Sprite>("Cabelom");
        cabelosFemininos = Resources.LoadAll<Sprite>("Cabelof");

        bocaMasculinaA = Resources.LoadAll<Sprite>("BocaM/Boca masculinas-Sheet");
        bocaMasculinaB = Resources.LoadAll<Sprite>("BocaM/Boca masculinab-Sheet");
        bocaMasculinaN = Resources.LoadAll<Sprite>("BocaM/Boca masculinap-Sheet");

        bocaFemininaA = Resources.LoadAll<Sprite>("Bocaf/Asiatico");
        bocaFemininaB = Resources.LoadAll<Sprite>("Bocaf/Branco");
        bocaFemininaN = Resources.LoadAll<Sprite>("Bocaf/Negro");

        corposSprites = Resources.LoadAll<Sprite>("Corpos");

        instance = this;
    }

    public void GerarAvatar()
    {
        GerarRaca();

        switch (raca)
        {
            case "A":
                SelecionarSprite(peleImage, peleSpritesA);
                SelecionarSprite(olhosImage, olhosSpritesA);
                SelecionarSprite(narizImage, narizSpritesA);
                break;

            case "B":
                SelecionarSprite(peleImage, peleSpritesB);
                SelecionarSprite(olhosImage, olhosSpritesB);
                SelecionarSprite(narizImage, narizSpritesB);
                break;

            case "N":
                SelecionarSprite(peleImage, peleSpritesN);
                SelecionarSprite(olhosImage, olhosSpritesN);
                SelecionarSprite(narizImage, narizSpritesN);
                break;
        }

        switch (Gerador.instance.sexo)
        {
            case "M":
                SelecionarSprite(cabeloImage, cabelosMasculinos);
                break;

            case "F":
                SelecionarSprite(cabeloImage, cabelosFemininos);
                break;
        }

        if (Gerador.instance.sexo == "M")
        {
            switch (raca)
            {
                case "A":
                    SelecionarSprite(bocaImage, bocaMasculinaA);
                    break;

                case "B":
                    SelecionarSprite(bocaImage, bocaMasculinaB);
                    break;

                case "N":
                    SelecionarSprite(bocaImage, bocaMasculinaN);
                    break;
            }
        }

        else
        {
            switch (raca)
            {
                case "A":
                    SelecionarSprite(bocaImage, bocaFemininaA);
                    break;

                case "B":
                    SelecionarSprite(bocaImage, bocaFemininaB);
                    break;

                case "N":
                    SelecionarSprite(bocaImage, bocaFemininaN);
                    break;
            }
        }

        SelecionarSprite(corpoImage, corposSprites);
    }

    private void GerarRaca()
    {
        int sortearRaca = Random.Range(1, 4);

        if (sortearRaca == 1)
            raca = "A";

        else if (sortearRaca == 2)
            raca = "B";

        else
            raca = "N";
    }

    private void SelecionarSprite(Image image, Sprite[] sprite)
    {
        image.sprite = sprite[Random.Range(0, sprite.Length)];
    }
}
