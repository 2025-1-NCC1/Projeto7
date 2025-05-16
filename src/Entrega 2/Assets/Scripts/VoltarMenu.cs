using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarMENU : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene(0); // Carrega a cena 0 do menu
    }
}
