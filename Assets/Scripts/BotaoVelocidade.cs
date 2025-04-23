using UnityEngine;
using TMPro;

public class ControladorVelocidade : MonoBehaviour
{
    public TextMeshProUGUI textoBotao;

    private float[] velocidades = { 1f, 2f, 4f };
    private int indiceAtual = 0;

    public void AlternarVelocidade()
    {
        indiceAtual = (indiceAtual + 1) % velocidades.Length;
        Time.timeScale = velocidades[indiceAtual];
        AtualizarTexto();
    }

    void Start()
    {
        AtualizarTexto();
    }

    void AtualizarTexto()
    {
        if (textoBotao != null)
        {
            textoBotao.text = velocidades[indiceAtual].ToString() + "x";
        }
    }
}
