using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Logic : MonoBehaviour
{
    [Header("Número de casos por dia")]
    public int numMaxDeCasos;
    public int numDeCasos;
    public int numDoDia;

    [Header("Contadores")]
    public int contadorDeDiaAumento;
    public int contadorDeDiaAumentoMax;
    public int contadorDeDiaBanco;
    public int contadorDeDiaBancoMax;
    public int contadorDevendoLuz;
    public int contadorDevendoAgua;
    public int contadorDevendoAluguel;

    [Header("Canvas")]
    public GameObject despesasCanvas;
    public GameObject gameOverCanvas;

    [Header("Panels")]
    public GameObject avisoDespesasPanel;
    public GameObject aviso2DespesasPanel;

    [Header("Texto")]
    [SerializeField] private TextMeshProUGUI despesasText;

    public static Logic instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        despesasText.text = "Fim do dia " + (numDoDia - 1);

        if (numDeCasos == numMaxDeCasos)
        {
            despesasCanvas.SetActive(true);

            numDeCasos = 0;

            numDoDia += 1;

            contadorDeDiaAumento += 1;
            contadorDeDiaBanco += 1;

            if (contadorDeDiaAumento == contadorDeDiaAumentoMax)
            {
                contadorDeDiaAumento = 0;

                Despesas.instance.AumentarPrecos();
            }

            if (contadorDeDiaBanco == contadorDeDiaBancoMax)
            {
                contadorDeDiaBanco = 0;

                Despesas.instance.Banco();
            }

            if (Despesas.instance.devendoLuz == true)
            {
                contadorDevendoLuz += 1;

                if (contadorDevendoLuz > 1)
                    Despesas.instance.valorLuz += Despesas.instance.AumentarPrecosDevendo(Despesas.instance.valorLuz);
            }
            else
                contadorDevendoLuz = 0;

            if (Despesas.instance.devendoAgua == true)
            {
                contadorDevendoAgua += 1;

                if (contadorDevendoAgua > 1)
                    Despesas.instance.valorAgua += Despesas.instance.AumentarPrecosDevendo(Despesas.instance.valorAgua);
            }
            else
                contadorDevendoAgua = 0;

            if (Despesas.instance.devendoAluguel == true)
            {
                contadorDevendoAluguel += 1;

                if (contadorDevendoAluguel > 1)
                    Despesas.instance.valorAluguel += Despesas.instance.AumentarPrecosDevendo(Despesas.instance.valorAluguel);
            }
            else
                contadorDevendoAluguel = 0;

            Despesas.instance.PassarValores();

            //Despesas.instance.VerificarGameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        gameOverCanvas.SetActive(true);
    }
}
