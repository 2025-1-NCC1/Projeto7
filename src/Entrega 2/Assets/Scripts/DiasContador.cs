using UnityEngine;
using TMPro; // Biblioteca para usar TextMeshPro (melhor que o texto padrão do Unity)
using UnityEngine.SceneManagement; // Necessário para trocar de cena
using System.Collections; // Necessário para usar corrotinas (IEnumerator)

public class ContadorDias : MonoBehaviour
{
    public TMP_Text textoDias; // Referência ao texto que mostra o número de dias na interface
    public int totalDias = 30; // Quantidade total de dias até o fim do jogo
    public float intervaloPorDia = 30f; // Tempo (em segundos) que representa 1 dia no jogo

    private int diaAtual = 0; // Contador interno do dia atual
    private float tempoAcumulado = 0f; // Acumula o tempo passado desde o último avanço de dia
    private bool jogoFinalizado = false; // Flag para evitar continuar contando após o fim do jogo

    void Start()
    {
        AtualizarTexto(); // Mostra o dia inicial (0) ao iniciar o jogo
    }

    void Update()
    {
        if (jogoFinalizado) return; // Se o jogo já terminou, não faz mais nada

        // Adiciona o tempo passado desde o último frame ao acumulador
        tempoAcumulado += Time.deltaTime;

        // Verifica se passou tempo suficiente para avançar um dia
        if (tempoAcumulado >= intervaloPorDia)
        {
            tempoAcumulado = 0f; // Reseta o tempo acumulado
            diaAtual++; // Avança um dia

            AtualizarTexto(); // Atualiza o texto na tela

            // Verifica se o número de dias chegou ao limite
            if (diaAtual >= totalDias)
            {
                jogoFinalizado = true; // Marca o jogo como finalizado
                textoDias.text = $"Fim do jogo - Dia {diaAtual}"; // Mostra mensagem final
                StartCoroutine(CarregarCenaFim()); // Inicia corrotina para trocar de cena após delay
            }
        }
    }

    // Atualiza o texto da interface com o número atual do dia
    void AtualizarTexto()
    {
        textoDias.text = $"Dia: {diaAtual}";
    }

    // Corrotina que espera 3 segundos e troca para a cena de fim de jogo
    IEnumerator CarregarCenaFim()
    {
        yield return new WaitForSeconds(3f); // Espera 3 segundos
        SceneManager.LoadScene("FimDoJogo"); // Carrega a cena chamada "FimDoJogo"
    }
}
