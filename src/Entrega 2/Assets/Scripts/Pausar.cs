using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pausar : MonoBehaviour
{
    public GameObject pausemenu;
    public Slider volume;
    public AudioSource audioSource;

    private bool isPaused = false;

    void Start()
    {
        pausemenu.SetActive(false); // Inicia o jogo sem o painel de pause aberto.
        volume.onValueChanged.AddListener(Volume);
        volume.value = AudioListener.volume; // Inicializa com o volume atual
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Clica no ESC
        {
            if (isPaused) DespausarJogo(); // Se tiver pausado ele despausa
            else PausarJogo(); // Se n�o ele pausa
        }
    }

    public void PausarJogo() // Fun��o de pausar
    {
        isPaused = true; // Transforma IsPaused em true
        Time.timeScale = 0f; //TimeScale � o tempo do jogo que freeza em 0
        pausemenu.SetActive(true); // Aparece o menu
    }

    public void DespausarJogo() // Fun��o de despausar
    {
        isPaused = false; // Transforma IsPaused em false
        Time.timeScale = 1f; //TimeScale volta o tempo normal do jogo
        pausemenu.SetActive(false); // Desaparece o menu
    }

    public void Volume(float value) // Fun��o de Menu
    {
        AudioListener.volume = value; // Seta o volume no valor do slider
    }
}
