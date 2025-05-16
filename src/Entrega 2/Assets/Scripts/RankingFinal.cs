using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankingFinal : MonoBehaviour
{
    public TMP_Text rankingCompletoTexto;

    void Start()
    {
        ExibirRanking();
    }

    void ExibirRanking()
    {
        List<string> nomes = DadosDoJogo.nomesRanking; // Coleta os dados salvos nos assets.
        List<float> consumos = DadosDoJogo.energiaRanking; // Coleta os dados salvos nos assets.

        if (nomes == null || consumos == null || nomes.Count == 0 || consumos.Count == 0)
        {
            rankingCompletoTexto.text = "Ranking indisponível.";
            return;
        }

        string texto = "<b></b>\n\n";

        int total = Mathf.Min(3, nomes.Count); // Garante que só mostra até 3

        for (int i = total - 1; i >= 0; i--)
        {
            int posicao = total - i; // Mostra 1º, 2º, 3º
            texto += $"{posicao}º - {nomes[i]}: {consumos[i]:F1} kWh\n";
        }

        rankingCompletoTexto.text = texto;
    }
}
