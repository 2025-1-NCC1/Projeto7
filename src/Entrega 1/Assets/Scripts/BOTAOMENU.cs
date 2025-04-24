using UnityEngine;
using UnityEngine.SceneManagement;

public class BOTAOMENU : MonoBehaviour
{
    // Método chamado uma vez antes do primeiro frame (atualmente vazio)
    void Start()
    {
    }

    // Método chamado a cada frame (atualmente vazio)
    void Update()
    {
    }

    // Método chamado ao clicar no botão que inicia o jogo
    public void IniciaJogo()
    {
        SceneManager.LoadScene(1); // Carrega a cena com índice 1
    }
}
