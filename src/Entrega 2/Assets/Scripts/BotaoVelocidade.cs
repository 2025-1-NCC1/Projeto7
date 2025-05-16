using UnityEngine;
using TMPro; // Usado para manipular texto com TextMeshPro

// Classe que controla a velocidade do tempo no jogo.
public class ControladorVelocidade : MonoBehaviour
{
    public TextMeshProUGUI textoBotao; // Refer�ncia ao texto que ser� mostrado no bot�o de velocidade.

    private float[] velocidades = { 1f, 2f, 4f }; // Lista de velocidades poss�veis (1x, 2x, 4x).
    private int indiceAtual = 0; // �ndice atual na lista de velocidades.

    // Fun��o p�blica que � chamada ao clicar no bot�o para alternar a velocidade.
    public void AlternarVelocidade()
    {
        // Avan�a para a pr�xima velocidade no array, voltando ao in�cio se passar do final.
        indiceAtual = (indiceAtual + 1) % velocidades.Length;

        // Altera a escala do tempo no Unity (afeta todos os comportamentos dependentes do tempo).
        Time.timeScale = velocidades[indiceAtual];

        // Atualiza o texto do bot�o para refletir a nova velocidade.
        AtualizarTexto();
    }

    // Fun��o chamada automaticamente ao iniciar o script.
    void Start()
    {
        AtualizarTexto(); // Mostra a velocidade inicial no bot�o.
    }

    // Atualiza o texto do bot�o com a velocidade atual.
    void AtualizarTexto()
    {
        if (textoBotao != null)
        {
            textoBotao.text = velocidades[indiceAtual].ToString() + "x";
        }
    }
}
