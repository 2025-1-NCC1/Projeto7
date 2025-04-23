using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GerenciadorEnergia : MonoBehaviour
{
    public CasaEnergia[] casas;
    public TextMeshProUGUI[] textosEnergia;
    public TextMeshProUGUI vencedorTexto;

    public int totalDias = 30;
    private int diaAtual = 0;
    public float intervaloDias = 30f; // 1 dia = 30 segundos
    private float tempoPassado = 0f;
    private bool jogoFinalizado = false;

    void Update()
    {
        if (jogoFinalizado) return;

        tempoPassado += Time.deltaTime;

        if (tempoPassado >= intervaloDias)
        {
            tempoPassado = 0f;
            diaAtual++;

            foreach (CasaEnergia casa in casas)
            {
                casa.ConsumirEnergia(); // cada casa consome energia por "dia"
            }

            AtualizarTextos();

            if (diaAtual >= totalDias)
            {
                jogoFinalizado = true;
                VerificarVencedor();
            }
        }
    }

    void AtualizarTextos()
    {
        for (int i = 0; i < casas.Length; i++)
        {
            textosEnergia[i].text = casas[i].nomeCasa + ": " + casas[i].energiaConsumida.ToString("F1") + " kWh";
        }
    }

    void VerificarVencedor()
    {
        if (casas == null || casas.Length == 0)
        {
            Debug.LogWarning("Nenhuma casa registrada no Gerenciador de Energia!");
            vencedorTexto.text = "Nenhuma casa registrada.";
            return;
        }

        CasaEnergia vencedor = casas[0];

        foreach (CasaEnergia casa in casas)
        {
            if (casa.energiaConsumida < vencedor.energiaConsumida)
            {
                vencedor = casa;
            }
        }

        vencedorTexto.text = "Vencedor: " + vencedor.nomeCasa;
    }
}
