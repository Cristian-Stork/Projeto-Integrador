using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Despesas : MonoBehaviour
{
    [Header("Valores das Despesas")]
    [SerializeField] public int valorLuz;
    [SerializeField] public int valorAgua;
    [SerializeField] public int valorComida;
    [SerializeField] public int valorAluguel;
    [SerializeField] public int valorRemedio;
    [SerializeField] private int[] valorArray;

    [SerializeField] private int valorGastos;
    [SerializeField] private int valorResultado;

    [Header("Aumentos")]
    [SerializeField] private int aumentoDoPreco;
    [SerializeField] private int aumentoDoPrecoDevendo;

    [Header("Contadores")]
    public int dividas;
    public int contadorDividas;
    public int contadorDevendoComida;
    public int contadorDevendoRemedio;

    [Header("Booleans de dividas")]
    public bool devendoLuz;
    public bool devendoAgua;
    public bool devendoComida;
    public bool devendoAluguel;
    public bool devendoRemedio;
    [SerializeField] private bool[] devendoArray;

    [Header("Booleans de gastos")]
    [SerializeField] private bool gastosLuz;
    [SerializeField] private bool gastosAgua;
    [SerializeField] private bool gastosComida;
    [SerializeField] private bool gastosAluguel;
    [SerializeField] private bool gastosRemedio;

    [Header("Dinheiro do Jogador")]
    public int economias;
    public int salario;

    [Header("Toggles")]
    [SerializeField] private Toggle toggleLuz;
    [SerializeField] private Toggle toggleAgua;
    [SerializeField] private Toggle toggleComida;
    [SerializeField] private Toggle toggleAluguel;
    [SerializeField] private Toggle toggleRemedio;
    [SerializeField] private Toggle[] toggleArray;

    [Header("Texto")]
    [SerializeField] private TextMeshProUGUI salarioText;
    [SerializeField] private TextMeshProUGUI economiasText;
    [SerializeField] private TextMeshProUGUI gastosText;
    [SerializeField] private TextMeshProUGUI resultadoText;

    [SerializeField] private TextMeshProUGUI valorLuzText;
    [SerializeField] private TextMeshProUGUI valorAguaText;
    [SerializeField] private TextMeshProUGUI valorComidaText;
    [SerializeField] private TextMeshProUGUI valorAluguelText;
    [SerializeField] private TextMeshProUGUI valorRemedioText;
    [SerializeField] private TextMeshProUGUI[] textArray;

    public static Despesas instance;

    // Start is called before the first frame update
    void Start()
    {
        toggleArray[0] = toggleLuz;
        toggleArray[1] = toggleAgua;
        toggleArray[2] = toggleComida;
        toggleArray[3] = toggleAluguel;
        toggleArray[4] = toggleRemedio;

        valorArray[0] = valorLuz;
        valorArray[1] = valorAgua;
        valorArray[2] = valorComida;
        valorArray[3] = valorAluguel;
        valorArray[4] = valorRemedio;

        textArray[0] = valorLuzText;
        textArray[1] = valorAguaText;
        textArray[2] = valorComidaText;
        textArray[3] = valorAluguelText;
        textArray[4] = valorRemedioText;

        devendoArray[0] = devendoLuz;
        devendoArray[1] = devendoAgua;
        devendoArray[2] = devendoComida;
        devendoArray[3] = devendoAluguel;
        devendoArray[4] = devendoRemedio;

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        valorResultado = economias + salario - valorGastos;

        gastosText.text = "Gastos: R$" + valorGastos;
        resultadoText.text = "Resultado: R$" + valorResultado;

        if (valorResultado < 0)
            resultadoText.color = Color.red;

        else
            resultadoText.color = Color.black;

        if (toggleLuz.isOn && gastosLuz == true)
        {
            valorGastos = Gastos(valorGastos, valorLuz, out gastosLuz);
        }
        else if (toggleLuz.isOn == false && gastosLuz == false)
        {
            valorGastos = DesGastos(valorGastos, valorLuz, out gastosLuz);
        }

        if (toggleAgua.isOn && gastosAgua == true)
        {
            valorGastos = Gastos(valorGastos, valorAgua, out gastosAgua);
        }
        else if (toggleAgua.isOn == false && gastosAgua == false)
        {
            valorGastos = DesGastos(valorGastos, valorAgua, out gastosAgua);
        }

        if (toggleComida.isOn && gastosComida == true)
        {
            valorGastos = Gastos(valorGastos, valorComida, out gastosComida);
        }
        else if (toggleComida.isOn == false && gastosComida == false)
        {
            valorGastos = DesGastos(valorGastos, valorComida, out gastosComida);
        }

        if (toggleAluguel.isOn && gastosAluguel == true)
        {
            valorGastos = Gastos(valorGastos, valorAluguel, out gastosAluguel);
        }
        else if (toggleAluguel.isOn == false && gastosAluguel == false)
        {
            valorGastos = DesGastos(valorGastos, valorAluguel, out gastosAluguel);
        }

        if (toggleRemedio.isOn && gastosRemedio == true)
        {
            valorGastos = Gastos(valorGastos, valorRemedio, out gastosRemedio);
        }
        else if (toggleRemedio.isOn == false && gastosRemedio == false)
        {
            valorGastos = DesGastos(valorGastos, valorRemedio, out gastosRemedio);
        }
    }

    public void PassarValores()
    {
        salarioText.text = "Salario: R$ " + salario.ToString();
        economiasText.text = "Economias: R$ " + economias.ToString();

        valorLuzText.text = "Luz: R$ " + valorLuz.ToString();
        valorAguaText.text = "Agua: R$ " + valorAgua.ToString();
        valorComidaText.text = "Comida: R$ " + valorComida.ToString();
        valorAluguelText.text = "Aluguel: R$ " + valorAluguel.ToString();
        valorRemedioText.text = "Remédios: R$ " + valorRemedio.ToString();
    }

    public void Confirmar()
    {
        int pagamento = 0;

        for (int i = 0; i < toggleArray.Length; i++)
        {
            if (toggleArray[i].isOn)
            {
                pagamento += valorArray[i];
            }
        }

        if (pagamento <= economias + salario)
        {
            economias = economias + salario;

            salario = 0;

            if (toggleLuz.isOn)
            {
                Cobranca(economias, out economias, valorLuz, valorLuzText, devendoLuz, out devendoLuz);
            }
            else
            {
                Atraso(devendoLuz, out devendoLuz, valorLuzText);
            }

            if (toggleAgua.isOn)
            {
                Cobranca(economias, out economias, valorAgua, valorAguaText, devendoAgua, out devendoAgua);
            }
            else
            {
                Atraso(devendoAgua, out devendoAgua, valorAguaText);
            }

            if (toggleComida.isOn)
            {
                Cobranca2(economias, out economias, valorComida, valorComidaText, devendoComida, out devendoComida);
            }
            else
            {
                Atraso2(devendoComida, out devendoComida, valorComidaText);
            }

            if (toggleAluguel.isOn)
            {
                Cobranca(economias, out economias, valorAluguel, valorAluguelText, devendoAluguel, out devendoAluguel);
            }
            else
            {
                Atraso(devendoAluguel, out devendoAluguel, valorAluguelText);
            }

            if (toggleRemedio.isOn)
            {
                Cobranca2(economias, out economias, valorRemedio, valorRemedioText, devendoRemedio, out devendoRemedio);
            }
            else
            {
                Atraso2(devendoRemedio, out devendoRemedio, valorRemedioText);
            }

            toggleLuz.isOn = false;
            toggleAgua.isOn = false;
            toggleComida.isOn = false;
            toggleAluguel.isOn = false;
            toggleRemedio.isOn = false;

            Logic.instance.despesasCanvas.SetActive(false);

            if (dividas == 3)
            {
                contadorDividas += 1;

                if (contadorDividas > 1)
                {
                    Logic.instance.GameOver();
                }
            }
            else
                contadorDividas = 0;

            if (devendoComida == true)
            {
                contadorDevendoComida += 1;

                if (contadorDevendoComida > 3)
                    Logic.instance.GameOver();
            }
            else
                contadorDevendoComida = 0;

            if (devendoRemedio == true)
            {
                contadorDevendoRemedio += 1;

                if (contadorDevendoRemedio > 3)
                    Logic.instance.GameOver();
            }
            else
                contadorDevendoRemedio = 0;
        }

        else
        {
            Logic.instance.avisoDespesasPanel.SetActive(true);
        }
    }

    void Cobranca(int economias, out int economiasOut, int valor, TextMeshProUGUI text, bool devendo, out bool devendoOut)
    {
        economiasOut = economias - valor;
        PagouConta(text);

        if (devendo == true)
            dividas -= 1;

        devendoOut = false;
    }

    void Atraso(bool devendo, out bool devendoOut, TextMeshProUGUI text)
    {
        if (devendo == false)
            dividas += 1;

        devendoOut = true;
        DevendoDinheiro(text);
    }

    void Cobranca2(int economias, out int economiasOut, int valor, TextMeshProUGUI text, bool devendo, out bool devendoOut)
    {
        economiasOut = economias - valor;
        PagouConta(text);
        devendoOut = false;
    }

    void Atraso2(bool devendo, out bool devendoOut, TextMeshProUGUI text)
    {
        devendoOut = true;
        DevendoDinheiro(text);
    }

    void PagouConta(TextMeshProUGUI text)
    {
        text.color = Color.black;
    }

    void DevendoDinheiro(TextMeshProUGUI text)
    {
        text.color = Color.red;
    }

    private int Gastos(int gastos, int valor, out bool jaSomouOut)
    {
        gastos += valor;

        jaSomouOut = false;

        return gastos;
    }

    private int DesGastos(int gastos, int valor, out bool jaSubtraiuOut)
    {
        gastos -= valor;

        jaSubtraiuOut = true;

        return gastos;
    }

    public void AumentarPrecos()
    {
        if (devendoLuz == false)
        valorLuz += aumentoDoPreco;

        if (devendoAgua == false)
        valorAgua += aumentoDoPreco;

        if (devendoComida == false)
        valorComida += aumentoDoPreco;

        if (devendoAluguel == false)
        valorAluguel += aumentoDoPreco;

        if (devendoRemedio == false)
        valorRemedio += aumentoDoPreco;

        valorArray[0] = valorLuz;
        valorArray[1] = valorAgua;
        valorArray[2] = valorComida;
        valorArray[3] = valorAluguel;
        valorArray[4] = valorRemedio;
    }

    public int AumentarPrecosDevendo(int valor)
    {
        valor = valor * aumentoDoPrecoDevendo / 100;

        return valor;
    }

    public void Banco()
    {
        economias -= economias / 2;
    }
}
