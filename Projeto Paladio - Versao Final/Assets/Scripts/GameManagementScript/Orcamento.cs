using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orcamento : MonoBehaviour
{
    public int valorMin;
    public int valorMax;

    [HideInInspector] public int orcamento;
    [HideInInspector] public int porcentagem;

    public static Orcamento instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GerarOrcamento()
    {
        orcamento = Random.Range(valorMin, valorMax + 1) * 100;
    }

    public void GerarPorcentagem()
    {
        porcentagem = 10 * orcamento / 100;
    }
}
