using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GerenciadorEnergia : MonoBehaviour
{
    public CasaEnergia[] casas; // Lista de casas na simulação
    public TextMeshProUGUI[] textosEnergia; // Textos que mostram energia consumida
    public TextMeshProUGUI vencedorTexto; // Texto que exibe o vencedor

    public int totalDias = 30; // Número total de dias na simulação
    private int diaAtual = 0; // Contador de dias
    public float intervaloDias = 30f; // Duração de cada "dia" (em segundos)
    private float tempoPassado = 0f;
    private bool jogoFinalizado = false; // Flag para impedir atualizações após o fim

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
                casa.ConsumirEnergia(); // Cada casa consome energia no fim de um dia
            }

            AtualizarTextos(); // Atualiza a UI com os novos valores

            if (diaAtual >= totalDias)
            {
                jogoFinalizado = true;
                VerificarVencedor(); // Verifica quem venceu após o último dia
            }
        }
    }

    // Atualiza os textos na interface com os valores de energia consumida
    void AtualizarTextos()
    {
        for (int i = 0; i < casas.Length; i++)
        {
            textosEnergia[i].text = casas[i].nomeCasa + ": " + casas[i].energiaConsumida.ToString("F1") + " kWh";
        }
    }

    // Determina a casa que consumiu menos energia
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
