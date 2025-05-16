using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuickEventManager : MonoBehaviour
{
    public List<QuickEvent> eventList;
    public GameObject quickEventUI;
    public TMP_Text questionText;
    public Button[] optionButtons;
    public CasaEnergia casaEnergia;
    public TabelaEnergia tabelaEnergia;
    public float penalidadeEnergia = 3f;
    public float reducaoEnergia = 2f;
    public float timeBetweenEvents = 60f;

    private void Start()
    {
        // Desativa a interface do evento rápido no início do jogo.
        quickEventUI.SetActive(false);

        // Inicia a rotina que dispara eventos de tempos em tempos.
        StartCoroutine(EventRoutine());
    }

    IEnumerator EventRoutine()
    {
        while (true) // Loop infinito que fica rodando durante o jogo.
        {
            // Espera por um tempo determinado antes de ativar um novo evento.
            yield return new WaitForSeconds(timeBetweenEvents);

            // Dispara um evento aleatório.
            TriggerRandomEvent();
        }
    }

    void TriggerRandomEvent()
    {
        // Se não houver eventos na lista, não faz nada.
        if (eventList.Count == 0) return;

        // Seleciona um evento aleatório da lista.
        QuickEvent evt = eventList[Random.Range(0, eventList.Count)];

        // Mostra o evento na interface.
        ShowEvent(evt);
    }

    void ShowEvent(QuickEvent evt)
    {
        // Pausa o jogo enquanto o evento está ativo.
        Time.timeScale = 0f;

        // Ativa a interface do evento.
        quickEventUI.SetActive(true);

        // Define o texto da pergunta do evento.
        questionText.SetText(evt.question);
        questionText.ForceMeshUpdate();

        // Configura os botões com as opções do evento.
        for (int i = 0; i < optionButtons.Length; i++)
        {
            int index = i; // Captura o índice atual para uso no lambda.

            // Atualiza o texto do botão com a opção correspondente.
            TMP_Text btnText = optionButtons[i].GetComponentInChildren<TMP_Text>();
            btnText.SetText(evt.options[i]);
            btnText.ForceMeshUpdate();

            // Reativa a interação do botão.
            optionButtons[i].interactable = true;

            // Reseta a cor do botão para branco.
            Image btnImage = optionButtons[i].GetComponent<Image>();
            btnImage.color = Color.white;

            // Remove qualquer listener anterior do botão.
            optionButtons[i].onClick.RemoveAllListeners();

            // Adiciona um novo listener que será chamado ao clicar no botão.
            optionButtons[i].onClick.AddListener(() =>
            {
                // Verifica se a opção clicada está correta.
                bool acertou = (index == evt.respostaCorretaIndex);

                // Pinta o botão de verde se estiver certo, vermelho se errado.
                Image clickedImage = optionButtons[index].GetComponent<Image>();
                if (acertou)
                {
                    clickedImage.color = Color.green;
                }
                else
                {
                    clickedImage.color = Color.red;
                }

                // Desativa todos os botões após a escolha.
                foreach (var btn in optionButtons)
                    btn.interactable = false;

                // Ajusta a energia da casa com base na resposta.
                if (casaEnergia != null)
                {
                    if (acertou)
                    {
                        // Reduz o consumo de energia se acertou.
                        casaEnergia.energiaConsumida = Mathf.Max(0f, casaEnergia.energiaConsumida - reducaoEnergia);
                        Debug.Log($"Resposta correta! -{reducaoEnergia} kWh. Total: {casaEnergia.energiaConsumida} kWh");
                    }
                    else
                    {
                        // Aumenta o consumo de energia se errou.
                        casaEnergia.energiaConsumida += penalidadeEnergia;
                        Debug.Log($"Resposta errada! +{penalidadeEnergia} kWh. Total: {casaEnergia.energiaConsumida} kWh");
                    }

                    // Atualiza a tabela de ranking de energia se estiver presente.
                    if (tabelaEnergia != null)
                    {
                        tabelaEnergia.AtualizarTabela();
                    }
                }

                // Executa a ação associada à opção escolhida, se existir.
                if (evt.onOptionSelected[index] != null)
                {
                    evt.onOptionSelected[index].Invoke();
                }

                // Inicia a rotina que fecha o evento após um pequeno atraso.
                StartCoroutine(FecharEventoDepoisDeDelay(1f));
            });
        }
    }


    IEnumerator FecharEventoDepoisDeDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); // usa tempo real pois o jogo está pausado

        quickEventUI.SetActive(false);
        Time.timeScale = 1f;

        // Reseta os botões para o próximo evento
        foreach (var btn in optionButtons)
        {
            btn.interactable = true;

            // Reseta a cor da imagem
            Image img = btn.GetComponent<Image>();
            img.color = Color.white;
        }
    }
}
