using UnityEngine;

public class CasaEnergia : MonoBehaviour
{
    [SerializeField]
    public string nomeCasa;

    public float energiaConsumida = 0f;

    void Awake()
    {
        // Se estiver vazio mesmo depois do Inspector, usa o nome do GameObject
        if (string.IsNullOrWhiteSpace(nomeCasa))
        {
            nomeCasa = gameObject.name;
        }
    }

    public void ConsumirEnergia()
    {
        float consumo = Random.Range(1f, 5f); // valor aleatório de consumo
        energiaConsumida += consumo;
    }
}


