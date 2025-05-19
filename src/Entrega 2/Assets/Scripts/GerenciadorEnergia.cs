using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Script responsável por controlar a tabela de energia e o ranking das casas
public class TabelaEnergia : MonoBehaviour
{
    [Header("Referências")]
    public CasaEnergia[] casas; // Referência para todas as casas do jogo
    public TMP_Text[] camposEnergia; // Campos de texto na UI que mostram o consumo de cada casa
    public TMP_Text rankingTexto; // Texto opcional para exibir o ranking (pode ser ocultado)

    [Header("Configuração do tempo")]
    public int totalDias = 30; // Total de dias da simulação
    public float tempoPorDia = 30f; // Tempo (em segundos) que representa um dia no jogo

    private int diaAtual = 0; // Dia atual da simulação
    private float tempoAcumulado = 0f; // Acumula o tempo decorrido
    private bool jogoFinalizado = false; // Flag para saber se o jogo terminou

    void Start()
    {
        // Se o rankingTexto estiver atribuído, esconde ele no início
        if (rankingTexto != null)
        {
            rankingTexto.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Se o jogo terminou, não faz mais nada
        if (jogoFinalizado) return;

        // Soma o tempo decorrido desde o último frame
        tempoAcumulado += Time.deltaTime;

        // Quando o tempo acumulado atingir o tempo de um "dia", avança
        if (tempoAcumulado >= tempoPorDia)
        {
            tempoAcumulado = 0f;
            diaAtual++;

            // Simula o consumo de energia aleatório para cada casa
            foreach (CasaEnergia casa in casas)
            {
                float energia = Random.Range(1f, 5f); // Consumo aleatório entre 1 e 5
                casa.energiaConsumida += energia;
            }

            // Atualiza a tabela de energia na interface
            AtualizarTabela();

            // Se chegou ao número total de dias, finaliza o jogo
            if (diaAtual >= totalDias)
            {
                jogoFinalizado = true;
                MostrarRanking(); // Prepara o ranking para ser mostrado em outra cena
                StartCoroutine(CarregarCenaRanking(5f)); // Espera 5 segundos e muda de cena
            }
        }
    }

    // Atualiza os campos de texto da interface com o consumo atual de cada casa
    public void AtualizarTabela()
    {
        for (int i = 0; i < casas.Length && i < camposEnergia.Length; i++)
        {
            camposEnergia[i].text = $"{casas[i].nomeCasa}: {casas[i].energiaConsumida:F1} kWh";
        }
    }

    // Gera o ranking das casas com base no consumo de energia (do menor para o maior)
    void MostrarRanking()
    {
        List<CasaEnergia> ranking = new List<CasaEnergia>(casas); // Cria uma lista baseada no array
        ranking.Sort((a, b) => a.energiaConsumida.CompareTo(b.energiaConsumida)); // Ordena por consumo

        // Limpa os dados anteriores armazenados
        DadosDoJogo.nomesRanking.Clear();
        DadosDoJogo.energiaRanking.Clear();

        // Armazena os dados do 10º (maior consumo) até o 1º (menor consumo)
        for (int i = ranking.Count - 1; i >= 0; i--)
        {
            DadosDoJogo.nomesRanking.Add(ranking[i].nomeCasa);
            DadosDoJogo.energiaRanking.Add(ranking[i].energiaConsumida);
        }
    }

    // Corrotina que espera um tempo antes de trocar para a cena de fim do jogo
    System.Collections.IEnumerator CarregarCenaRanking(float delay)
    {
        yield return new WaitForSeconds(delay); // Espera o tempo definido
        SceneManager.LoadScene("FimDoJogo"); // Carrega a cena chamada "FimDoJogo"
    }
}
