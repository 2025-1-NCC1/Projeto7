using UnityEngine;
using UnityEngine.SceneManagement;

public class BOTAOMENU : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciaJogo() 
    {
        SceneManager.LoadScene(1); // Troca a cena
    }
}
