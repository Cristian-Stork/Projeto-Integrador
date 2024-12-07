using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class Gerador : MonoBehaviour
{
    /*Var do objeto dos nomes*/

    public NamesManager nomesManager;  // Referência ao nome

    [HideInInspector] public string nome, sobrenome;

    public List<string> nomeM, nomeF, sobrenomeL = new List<string>();

    [HideInInspector] public string ndr;
    [HideInInspector] public string rpfL;
    [HideInInspector] public int rpfN;
    private string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    [HideInInspector] public int dia, mes, ano;
    [HideInInspector] public string sexo;

    [HideInInspector] public bool invalido = false;
    [HideInInspector] public string informacaoInvalida;

    [Header("Texto do DU")]
    public TextMeshProUGUI nomeText;
    public TextMeshProUGUI rpfText;
    public TextMeshProUGUI ddnText;
    public TextMeshProUGUI sexoText;
    public TextMeshProUGUI orcamentoText;
    public TextMeshProUGUI porcentagemText;

    [Header("Pedidos Disponiveis")]
    public bool medicoDisponivel = false;
    public bool abusoDisponivel = false;
    public bool escolarDisponivel = false;

    [SerializeField] private List<string> pedidosDisponiveis = new List<string>();

    [Header("Informações invalidas possiveis")]
    public bool nomeInvalido = false;
    public bool ndrInvalido = false;
    public bool rpfInvalido = false;
    public bool ddnInvalido = false;
    public bool sexoInvalido = false;
    public bool cdInvalido = false;
    public bool coInvalido = false;
    public bool notasInvalido = false;
    public bool rendaInvalido = false;

    [SerializeField] public List<string> informacoesInvalidas = new List<string>();
    private List<string> informacoesInvalidasO = new List<string>();

    private bool todasAsInformacoesInvalidas;

    [Header("Documentos que podem estar invalidos")]
    public bool duInvalido = false;
    public bool laudoInvalido = false;
    public bool boInvalido = false;
    public bool heInvalido = false;
    public bool cdrInvalido = false;

    [SerializeField] public List<string> documentosInvalidos = new List<string>();
    private List<string> documentosInvalidosO = new List<string>();

    [HideInInspector] public bool pedidoMedico = false;
    [HideInInspector] public bool pedidoAbuso = false;
    [HideInInspector] public bool pedidoEscolar = false;

    public static Gerador instance;

    // Start is called before the first frame update
    void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("names");

        NamesData jsonObjectName = JsonUtility.FromJson<NamesData>(jsonFile.text);

        if (jsonObjectName.sobrenomes == null || jsonObjectName.sobrenomes.Count == 0)
        {
            Debug.LogError("No jsonObjectName loaded from the JSON file. Please check the file format.");
            return;
        }

        nomeM = jsonObjectName.masculinos;
        nomeF = jsonObjectName.femininos;
        sobrenomeL = jsonObjectName.sobrenomes;


        if (nomeInvalido)
            informacoesInvalidas.Add(nameof(nomeInvalido));

        if (ndrInvalido)
            informacoesInvalidas.Add(nameof(ndrInvalido));

        if (rpfInvalido)
            informacoesInvalidas.Add(nameof(rpfInvalido));

        if (ddnInvalido)
            informacoesInvalidas.Add(nameof(ddnInvalido));

        if (sexoInvalido)
            informacoesInvalidas.Add(nameof(sexoInvalido));

        if (cdInvalido)
            informacoesInvalidas.Add(nameof(cdInvalido));

        if (coInvalido)
            informacoesInvalidas.Add(nameof(coInvalido));

        if (notasInvalido)
            informacoesInvalidas.Add(nameof(notasInvalido));

        if (rendaInvalido)
            informacoesInvalidas.Add(nameof(rendaInvalido));

        if (medicoDisponivel == false)
            informacoesInvalidas.Remove("cdInvalido");

        if (abusoDisponivel == false)
            informacoesInvalidas.Remove("coInvalido");

        if (escolarDisponivel == false)
        {
            informacoesInvalidas.Remove("notasInvalido");
            informacoesInvalidas.Remove("rendaInvalido");
        }

        if (medicoDisponivel)
            pedidosDisponiveis.Add(nameof(medicoDisponivel));

        if (abusoDisponivel)
            pedidosDisponiveis.Add(nameof(abusoDisponivel));

        if (escolarDisponivel)
            pedidosDisponiveis.Add(nameof(escolarDisponivel));

        if (duInvalido)
            documentosInvalidos.Add(nameof(duInvalido));

        if (laudoInvalido)
            documentosInvalidos.Add(nameof(laudoInvalido));

        if (boInvalido)
            documentosInvalidos.Add(nameof(boInvalido));

        if (heInvalido)
            documentosInvalidos.Add(nameof(heInvalido));

        if (cdrInvalido)
            documentosInvalidos.Add(nameof(cdrInvalido));

        for (var i = 0; i < informacoesInvalidas.Count; i++)
        {
            informacoesInvalidasO.Add(informacoesInvalidas[i]);
        }

        for (var i = 0; i < documentosInvalidos.Count; i++)
        {
            documentosInvalidosO.Add(documentosInvalidos[i]);
        }

        instance = this;
    }

    public void GerarInformacoes()
    {
        LimparPedidoAnterior();
        Sexo();
        AvatarGenerator.instance.GerarAvatar();
        Nome();
        NDR();
        RPF();
        DDN();
        Orcamento.instance.GerarOrcamento();
        Orcamento.instance.GerarPorcentagem();
        PassarInformacoes();
        VerificarPedido();
        DU.instance.AtualizarDU();
        VerificarValidez();
    }

    void LimparPedidoAnterior()
    {
        informacoesInvalidas.Clear();

        for (var i = 0; i < informacoesInvalidasO.Count; i++)
        {
            informacoesInvalidas.Add(informacoesInvalidasO[i]);
        }

        documentosInvalidos.Clear();

        for (var i = 0; i < documentosInvalidosO.Count; i++)
        {
            documentosInvalidos.Add(documentosInvalidosO[i]);
        }

        if (nomeInvalido == false && ndrInvalido == false && rpfInvalido == false && ddnInvalido == false && sexoInvalido == false && cdInvalido == false && coInvalido == false && notasInvalido == false && rendaInvalido == false)
        {
            todasAsInformacoesInvalidas = true;
        }

        else
        {
            todasAsInformacoesInvalidas = false;
        }

        pedidoMedico = false;
        pedidoAbuso = false;
        pedidoEscolar = false;

        invalido = false;
    }

    void PassarInformacoes()
    {
        nomeText.text = "Nome: " + nome + " " + sobrenome;

        rpfText.text = "RPF: " + rpfL + " - " + rpfN;

        if (dia < 10)
        {
            ddnText.text = "DDN: " + "0" + dia.ToString();
        }

        else
        {
            ddnText.text = "DDN: " + dia.ToString();
        }

        if (mes < 10)
        {
            ddnText.text = ddnText.text + "/0" + mes.ToString();
        }

        else
        {
            ddnText.text = ddnText.text + "/" + mes.ToString();
        }

        ddnText.text = ddnText.text + "/" + ano.ToString();

        sexoText.text = "Sexo: " + sexo;

        orcamentoText.text = "Orçamento: R$ " + Orcamento.instance.orcamento.ToString();

        porcentagemText.text = "Porcentagem: R$ " + Orcamento.instance.porcentagem.ToString();
    }

    void VerificarPedido()
    {
        switch (pedidosDisponiveis[Random.Range(0, pedidosDisponiveis.Count)])
        {
            case "medicoDisponivel":
                pedidoMedico = true;
                Laudo.instance.GerarInformacoesLaudo();
                informacoesInvalidas.Remove("coInvalido");
                informacoesInvalidas.Remove("notasInvalido");
                informacoesInvalidas.Remove("rendaInvalido");
                documentosInvalidos.Remove("boInvalido");
                documentosInvalidos.Remove("heInvalido");
                documentosInvalidos.Remove("cdrInvalido");
                Debug.Log("Pedido Medico");
                break;

            case "abusoDisponivel":
                pedidoAbuso = true;
                Laudo.instance.GerarInformacoesLaudo();
                BO.instance.GerarInformacoesBO();
                informacoesInvalidas.Remove("cdInvalido");
                informacoesInvalidas.Remove("notasInvalido");
                informacoesInvalidas.Remove("rendaInvalido");
                documentosInvalidos.Remove("heInvalido");
                documentosInvalidos.Remove("cdrInvalido");
                Debug.Log("Pedido Abuso");
                break;

            case "escolarDisponivel":
                pedidoEscolar = true;
                HistoricoEscolar.instance.GerarInformacoesHE();
                ComprovanteDeRenda.instance.GerarInformacoesCDR();
                informacoesInvalidas.Remove("cdInvalido");
                informacoesInvalidas.Remove("coInvalido");
                documentosInvalidos.Remove("laudoInvalido");
                documentosInvalidos.Remove("boInvalido");
                Debug.Log("Pedido Escolar");
                break;
        }
    }

    void Nome()
    {
        if (invalido == false)
        {
            if (sexo == "M")
            {
                nome = nomeM[Random.Range(0, 5)];
            }

            if (sexo == "F")
            {
                nome = nomeF[Random.Range(0, 5)];
            }

            sobrenome = sobrenomeL[Random.Range(0, 5)];
        }

        else
        {
            string sobrenomeO;

            sobrenomeO = sobrenome;

            while (sobrenome == sobrenomeO)
            {
                sobrenome = sobrenomeL[Random.Range(0, 5)];
            }
        }
    }

    void NDR()
    {
        switch (Random.Range(1, 3))
        {
            case 1:
                ndr = nomeM[Random.Range(0, 5)];
                break;

            case 2:
                ndr = nomeF[Random.Range(0, 5)];
                break;
        }

        if (invalido == false)
        {
            ndr += " " + sobrenome;
        }

        else
        {
            string novoSobrenome = sobrenome;

            while (novoSobrenome == sobrenome)
            {
                novoSobrenome = sobrenomeL[Random.Range(0, 5)];
            }

            ndr += " " + novoSobrenome;
        }
    }

    void RPF()
    {
        if (invalido == false)
        {
            rpfL = letras[Random.Range(0, letras.Length)].ToString() + letras[Random.Range(0, letras.Length)].ToString() + letras[Random.Range(0, letras.Length)].ToString();

            rpfN = Random.Range(1, 1000);
        }

        else
        {
            string rpfLO;
            int rpfNO;

            rpfLO = rpfL;
            rpfNO = rpfN;

            while (rpfL == rpfLO && rpfN == rpfNO)
            {
                rpfL = letras[Random.Range(0, letras.Length)].ToString() + letras[Random.Range(0, letras.Length)].ToString() + letras[Random.Range(0, letras.Length)].ToString();

                rpfN = Random.Range(1, 1000);
            }
        }
    }

    void DDN()
    {
        if (invalido == false)
        {
            mes = Random.Range(1, 13);
            if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
            {
                dia = Random.Range(1, 32);
            }
            else if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
            {
                dia = Random.Range(1, 31);
            }
            else if (mes == 2)
            {
                dia = Random.Range(1, 29);
            }

            ano = 2124 - Random.Range(14, 31);
        }
        else
        {
            int diaO, mesO, anoO;

            switch (Random.Range(1, 4))
            {
                case 1:
                    mesO = mes;

                    while (mes == mesO)
                    {
                        mes = Random.Range(1, 13);
                    }
                    break;

                case 2:
                    diaO = dia;

                    while (dia == diaO)
                    {
                        dia = Random.Range(1, 32);
                    }
                    break;

                case 3:
                    anoO = ano;

                    while (ano == anoO)
                    {
                        ano = 2124 - Random.Range(14, 31);
                    }
                    break;
            }
        }
    }

    void Sexo()
    {
        if (invalido == false)
        {
            if (Random.Range(1, 3) == 1)
            {
                sexo = "M";
            }

            else
            {
                sexo = "F";
            }
        }

        else
        {
            string sexoO;

            sexoO = sexo;

            while (sexo == sexoO)
            {
                if (Random.Range(1, 3) == 1)
                {
                    sexo = "M";
                }

                else
                {
                    sexo = "F";
                }
            }
        }
    }

    void VerificarValidez()
    {
        if (Random.Range(1, 3) == 1 && todasAsInformacoesInvalidas == false && Logic2.instance.muitaInvalidez == false)
        {
            Debug.Log("Pedido Invalido");
            invalido = true;
            Logic2.instance.ContadorInvalido();

            if (ano > 2106 && informacoesInvalidas.Contains("ndrInvalido") == false && ndrInvalido == true)
            {
                informacoesInvalidas.Add("ndrInvalido");
            }

            else
            {
                informacoesInvalidas.Remove("ndrInvalido");
            }

            switch (informacoesInvalidas[Random.Range(0, informacoesInvalidas.Count)])
            {
                case "nomeInvalido":
                    Nome();
                    informacaoInvalida = "Nome";
                    documentosInvalidos.Remove("cdrInvalido");
                    Debug.Log("O Nome tá errado");
                    break;

                case "ndrInvalido":
                    NDR();
                    informacaoInvalida = "Nome do responsável";
                    documentosInvalidos.Remove("duInvalido");
                    documentosInvalidos.Remove("heInvalido");
                    documentosInvalidos.Remove("cdrInvalido");
                    Debug.Log("O nome do responsável tá errado");
                    break;

                case "rpfInvalido":
                    RPF();
                    informacaoInvalida = "RPF";
                    documentosInvalidos.Remove("heInvalido");
                    documentosInvalidos.Remove("cdrInvalido");
                    Debug.Log("O RPF tá errado");
                    break;

                case "ddnInvalido":
                    DDN();
                    informacaoInvalida = "Data de nascimento";
                    documentosInvalidos.Remove("cdrInvalido");
                    Debug.Log("O DDN tá errado");
                    break;

                case "sexoInvalido":
                    Sexo();
                    informacaoInvalida = "Sexo";
                    documentosInvalidos.Remove("cdrInvalido");
                    Debug.Log("O sexo tá errado");
                    break;

                case "cdInvalido":
                    Laudo.instance.CD();
                    informacaoInvalida = "CRM";
                    documentosInvalidos.Remove("duInvalido");
                    documentosInvalidos.Remove("boInvalido");
                    documentosInvalidos.Remove("heInvalido");
                    documentosInvalidos.Remove("cdrInvalido");
                    Debug.Log("O CD tá errado");
                    break;

                case "coInvalido":
                    BO.instance.CO();
                    informacaoInvalida = "CO";
                    documentosInvalidos.Remove("duInvalido");
                    documentosInvalidos.Remove("laudoInvalido");
                    documentosInvalidos.Remove("heInvalido");
                    documentosInvalidos.Remove("cdrInvalido");
                    Debug.Log("O CO tá errado");
                    break;

                case "notasInvalido":
                    HistoricoEscolar.instance.Notas();
                    informacaoInvalida = "Notas";
                    documentosInvalidos.Remove("duInvalido");
                    documentosInvalidos.Remove("laudoInvalido");
                    documentosInvalidos.Remove("boInvalido");
                    documentosInvalidos.Remove("cdrInvalido");
                    Debug.Log("As notas estão erradas");
                    break;

                case "rendaInvalido":
                    ComprovanteDeRenda.instance.Renda();
                    informacaoInvalida = "Renda";
                    documentosInvalidos.Remove("duInvalido");
                    documentosInvalidos.Remove("laudoInvalido");
                    documentosInvalidos.Remove("boInvalido");
                    documentosInvalidos.Remove("heInvalido");
                    Debug.Log("A renda tá errado");
                    break;
            }

            string documento = documentosInvalidos[Random.Range(0, documentosInvalidos.Count)];

            switch (documento)
            {
                case "duInvalido":
                    PassarInformacoes();
                    Debug.Log("DU mudou");
                    break;

                case "laudoInvalido":
                    Laudo.instance.AtualizarLaudo();
                    Debug.Log("Laudo mudou");
                    break;

                case "boInvalido":
                    BO.instance.AtualizarBO();
                    Debug.Log("BO mudou");
                    break;

                case "heInvalido":
                    HistoricoEscolar.instance.AtualizarHE();
                    Debug.Log("HE mudou");
                    break;

                case "cdrInvalido":
                    ComprovanteDeRenda.instance.AtualizarCDR();
                    Debug.Log("CDR mudou");
                    break;
            }
        }

        else
        {
            Debug.Log("Pedido Valido");
            Logic2.instance.ContadorValido();
        }
    }
}

[System.Serializable]
public class NamesData
{
    public List<string> femininos;
    public List<string> masculinos;
    public List<string> sobrenomes;
}