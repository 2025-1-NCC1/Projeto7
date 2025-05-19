using UnityEngine;
using TMPro; // Usado para manipular texto com TextMeshPro

// Classe que controla a velocidade do tempo no jogo.
public class ControladorVelocidade : MonoBehaviour
{
    public TextMeshProUGUI textoBotao; // Referência ao texto que será mostrado no botão de velocidade.

    private float[] velocidades = { 1f, 2f, 4f }; // Lista de velocidades possíveis (1x, 2x, 4x).
    private int indiceAtual = 0; // Índice atual na lista de velocidades.

    // Função pública que é chamada ao clicar no botão para alternar a velocidade.
    public void AlternarVelocidade()
    {
        // Avança para a próxima velocidade no array, voltando ao início se passar do final.
        indiceAtual = (indiceAtual + 1) % velocidades.Length;

        // Altera a escala do tempo no Unity (afeta todos os comportamentos dependentes do tempo).
        Time.timeScale = velocidades[indiceAtual];

        // Atualiza o texto do botão para refletir a nova velocidade.
        AtualizarTexto();
    }

    // Função chamada automaticamente ao iniciar o script.
    void Start()
    {
        AtualizarTexto(); // Mostra a velocidade inicial no botão.
    }

    // Atualiza o texto do botão com a velocidade atual.
    void AtualizarTexto()
    {
        if (textoBotao != null)
        {
            textoBotao.text = velocidades[indiceAtual].ToString() + "x";
        }
    }
}
