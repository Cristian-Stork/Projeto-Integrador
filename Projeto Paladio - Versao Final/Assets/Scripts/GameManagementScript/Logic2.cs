using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic2 : MonoBehaviour
{
    [HideInInspector] public int vezesInvalido;
    [SerializeField] private int vezesInvalidoMax;

    [HideInInspector] public int vezesValido;
    [SerializeField] private int vezesValidoMax;

    [HideInInspector] public bool muitaInvalidez;

    [HideInInspector] public string informacaoInvalidaAtual;
    [HideInInspector] public string informacaoInvalidaAntiga;

    [HideInInspector] public int informacaoRepetiu;
    [SerializeField] public int informacaoRepetiuMax;

    [HideInInspector] public int vezesMedico;
    [HideInInspector] public int vezesMedicoMax;

    [HideInInspector] public bool muitoMedico;

    [HideInInspector] public int vezesAbuso;
    [HideInInspector] public int vezesAbusoMax;

    [HideInInspector] public bool muitoAbuso;

    [HideInInspector] public int vezesEscolar;
    [HideInInspector] public int vezesEscolarMax;

    [HideInInspector] public bool muitoEscolar;

    public static Logic2 instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContadorInvalido()
    {
        if (vezesInvalido > vezesInvalidoMax)
        {
            muitaInvalidez = true;
            vezesInvalido = 0;
        }

        else
        {
            vezesInvalido += 1;
            Debug.Log("vezesInvalido = " + vezesInvalido);
        }
    }

    public void ContadorValido()
    {
        if (vezesValido > vezesValidoMax)
        {
            muitaInvalidez = false;
            vezesValido = 0;
        }

        else
        {
            vezesValido += 1;
            Debug.Log("vezesValido = " + vezesValido);
        }
    }

    public void ContadorDeInformacoesInvalidas()
    {
        informacaoInvalidaAtual = Gerador.instance.informacaoInvalida;

        if (informacaoInvalidaAtual == informacaoInvalidaAntiga)
        {
            informacaoRepetiu += 1;
        }

        informacaoInvalidaAntiga = informacaoInvalidaAtual;
    }

    public void ContadorDeInformacoesInvalidas2()
    {
        if (informacaoRepetiu == informacaoRepetiuMax)
        {
            Gerador.instance.informacoesInvalidas.Remove(informacaoInvalidaAtual);
            informacaoRepetiu = 0;
        }
    }

    public void ContadorMedico()
    {
        if (vezesMedico > vezesMedicoMax)
        {
            muitoMedico = true;
            vezesMedico = 0;
        }

        else
        {
            vezesMedico += 1;
            muitoMedico = false;
        }
    }

    public void ContadorAbuso()
    {
        if (vezesAbuso > vezesAbusoMax)
        {
            muitoAbuso = true;
            vezesAbuso = 0;
        }

        else
        {
            vezesAbuso += 1;
            muitoAbuso = false;
        }
    }

    public void ContadorEscolar()
    {
        if (vezesEscolar > vezesEscolarMax)
        {
            muitoEscolar = true;
            vezesEscolar = 0;
        }

        else
        {
            vezesEscolar += 1;
            muitoEscolar = false;
        }
    }
}
