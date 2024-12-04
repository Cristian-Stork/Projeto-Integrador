using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject laudoCanvas;
    public GameObject boCanvas;
    public GameObject heCanvas;
    public GameObject cdrCanvas;
    public GameObject laudoManualCanvas;
    public GameObject boManualCanvas;
    public GameObject heManualCanvas;
    public GameObject cdrManualCanvas;
    public GameObject confirmarCanvas;
    public GameObject respostaPanel;
    public GameObject comecarPanel;

    [SerializeField] private List<GameObject> documentosMedico = new List<GameObject>();
    [SerializeField] private List<GameObject> documentosAbuso = new List<GameObject>();
    [SerializeField] private List<GameObject> documentosEscolar = new List<GameObject>();

    [SerializeField] private int contador = 0;

    private bool manual;

    [SerializeField] private List<GameObject> manuaisMedico = new List<GameObject>();
    [SerializeField] private List<GameObject> manuaisAbuso = new List<GameObject>();
    [SerializeField] private List<GameObject> manuaisEscolar = new List<GameObject>();

    [Header("Buttons")]
    public GameObject botaoEsquerdo;
    public GameObject botaoDireito;
    public Button botaoManual;

    [Header("Texto")]
    public TextMeshProUGUI respostaText;
    public TextMeshProUGUI feedbackText;

    [Header("Sprites")]
    [SerializeField] private Sprite manualFechado;
    [SerializeField] private Sprite manualAberto;

    private bool aceitou = false;
    private bool rejeitou = false;

    public static ButtonManager instance;

    void Start()
    {
        documentosMedico.Add(laudoCanvas);
        documentosAbuso.Add(laudoCanvas);
        documentosAbuso.Add(boCanvas);
        documentosEscolar.Add(heCanvas);
        documentosEscolar.Add(cdrCanvas);

        manuaisMedico.Add(laudoManualCanvas);
        manuaisAbuso.Add(laudoManualCanvas);
        manuaisAbuso.Add(boManualCanvas);
        manuaisEscolar.Add(heManualCanvas);
        manuaisEscolar.Add(cdrManualCanvas);

        instance = this;
    }

    public void Come�ar()
    {
        Gerador.instance.GerarInformacoes();
        botaoDireito.SetActive(true);
        Destroy(comecarPanel);
    }

    public void Voltar()
    {
        confirmarCanvas.SetActive(false);
    }

    public void Aceitar()
    {
        confirmarCanvas.SetActive(true);

        aceitou = true;
    }

    public void Rejeitar()
    {
        confirmarCanvas.SetActive(true);

        rejeitou = true;
    }

    public void Confirmar()
    {
        respostaPanel.SetActive(true);

        if (aceitou == true)
        {
            if (Gerador.instance.invalido == false)
            {
                respostaText.text = "Voc� acertou. O pedido desse cidad�o era valido";
                feedbackText.text = " ";

                Despesas.instance.salario += Orcamento.instance.porcentagem;
            }

            else
            {
                respostaText.text = "Voc� errou. O pedido desse cidad�o era invalido";
                feedbackText.text = "Motivo da invalidez: " + Gerador.instance.informacaoInvalida;
            }
        }

        else if (rejeitou == true)
        {
            if (Gerador.instance.invalido == false)
            {
                respostaText.text = "Voc� errou. O pedido desse cidad�o era valido";
                feedbackText.text = " ";
            }

            else
            {
                respostaText.text = "Voc� acertou. O pedido desse cidad�o era invalido";
                feedbackText.text = "Motivo da invalidez: " + Gerador.instance.informacaoInvalida;

                Despesas.instance.salario += Orcamento.instance.porcentagem;
            }
        }
    }

    public void Proximo()
    {
        Logic.instance.numDeCasos += 1;

        aceitou = false;
        rejeitou = false;

        laudoCanvas.SetActive(false);
        boCanvas.SetActive(false);
        heCanvas.SetActive(false);
        cdrCanvas.SetActive(false);
        confirmarCanvas.SetActive(false);
        respostaPanel.SetActive(false);
        botaoDireito.SetActive(true);
        botaoEsquerdo.SetActive(false);

        if (Gerador.instance.pedidoMedico == true && contador != 0)
            manuaisMedico[contador - 1].SetActive(false);

        if (Gerador.instance.pedidoAbuso == true && contador != 0)
            manuaisAbuso[contador - 1].SetActive(false);

        if (Gerador.instance.pedidoEscolar == true && contador != 0)
            manuaisEscolar[contador - 1].SetActive(false);

        botaoManual.image.sprite = manualFechado;
        manual = false;
        contador = 0;
        Gerador.instance.GerarInformacoes();
    }

    public void BotaoDireito()
    {
        if (Gerador.instance.pedidoMedico == true)
        PassarDocumento(documentosMedico);

        if (Gerador.instance.pedidoAbuso == true)
        PassarDocumento(documentosAbuso);

        if (Gerador.instance.pedidoEscolar == true)
            PassarDocumento(documentosEscolar);
    }

    public void BotaoEsquerdo()
    {
        if (Gerador.instance.pedidoMedico == true)
            VoltarDocumento(documentosMedico);

        if (Gerador.instance.pedidoAbuso == true)
            VoltarDocumento(documentosAbuso);

        if (Gerador.instance.pedidoEscolar == true)
            VoltarDocumento(documentosEscolar);
    }

    private void PassarDocumento(List<GameObject> documentos)
    {
        botaoEsquerdo.SetActive(true);

        if (contador >= 1)
            documentos[contador - 1].SetActive(false);


        documentos[contador].SetActive(true);
        contador += 1;

        if (contador >= documentos.Count)
            botaoDireito.SetActive(false);
    }

    private void VoltarDocumento(List<GameObject> documentos)
    {
        botaoDireito.SetActive(true);

        contador -= 1;
        documentos[contador].SetActive(false);

        if (contador >= 1)
            documentos[contador - 1].SetActive(true);

        if (contador <= 0)
            botaoEsquerdo.SetActive(false);
    }

    public void BotaoManual()
    {
        if (Gerador.instance.pedidoMedico == true)
            AbrirManual(manuaisMedico);

        if (Gerador.instance.pedidoAbuso == true)
            AbrirManual(manuaisAbuso);

        if (Gerador.instance.pedidoEscolar == true)
            AbrirManual(manuaisEscolar);
    }

    private void AbrirManual(List<GameObject> manuais)
    {
        if (manual == false)
        {
            manuais[contador - 1].SetActive(true);
            botaoManual.image.sprite = manualAberto;
            manual = true;
            botaoDireito.SetActive(false);
            botaoEsquerdo.SetActive(false);
        }

        else
        {
            manuais[contador - 1].SetActive(false);
            botaoManual.image.sprite = manualFechado;
            manual = false;

            if (contador >= manuais.Count)
                botaoEsquerdo.SetActive(true);

            else
            {
                botaoDireito.SetActive(true);
                botaoEsquerdo.SetActive(true);
            }
        }
    }

    public void FecharAvisoDespesas()
    {
        Logic.instance.avisoDespesasPanel.SetActive(false);
    }

    public void FecharAviso2Despesas()
    {
        Logic.instance.GameOver();
    }

    public void VoltarParaOMenu()
    {
        SceneManager.LoadScene(0);
    }
}
