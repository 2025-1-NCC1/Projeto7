using UnityEngine;
using TMPro;

public class ControladorVelocidade : MonoBehaviour
{
    public TextMeshProUGUI textoBotao; // Referência ao texto do botão de velocidade

    private float[] velocidades = { 1f, 2f, 4f }; // Possíveis velocidades
    private int indiceAtual = 0; // Índice da velocidade atual

    // Método chamado ao clicar no botão para alternar a velocidade
    public void AlternarVelocidade()
    {
        indiceAtual = (indiceAtual + 1) % velocidades.Length; // Muda para a próxima velocidade
        Time.timeScale = velocidades[indiceAtual]; // Aplica a nova velocidade
        AtualizarTexto(); // Atualiza o texto no botão
    }

    void Start()
    {
        AtualizarTexto(); // Garante que o botão comece com o texto certo
    }

    // Atualiza o texto do botão com a velocidade atual
    void AtualizarTexto()
    {
        if (textoBotao != null)
        {
            textoBotao.text = velocidades[indiceAtual].ToString() + "x";
        }
    }
}
