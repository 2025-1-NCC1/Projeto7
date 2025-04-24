using UnityEngine;

public class CasaEnergia : MonoBehaviour
{
    [SerializeField]
    public string nomeCasa; // Nome da casa, pode ser definido no Inspector

    public float energiaConsumida = 0f; // Energia acumulada consumida pela casa

    void Awake()
    {
        // Se não for definido no Inspector, usa o nome do GameObject
        if (string.IsNullOrWhiteSpace(nomeCasa))
        {
            nomeCasa = gameObject.name;
        }
    }

    // Método que simula o consumo de energia pela casa
    public void ConsumirEnergia()
    {
        float consumo = Random.Range(1f, 5f); // Gera um consumo aleatório
        energiaConsumida += consumo;
    }
}
