using UnityEngine;

public class CasaEnergia : MonoBehaviour
{
    [SerializeField]
    public string nomeCasa;

    public float energiaConsumida = 0f;
    public float aguaConsumida = 0f;

    void Awake()
    {
        // Se o nome não for preenchido manualmente, usa o nome do GameObject
        if (string.IsNullOrWhiteSpace(nomeCasa))
        {
            nomeCasa = gameObject.name;
        }
    }

    // Método chamado uma vez por dia no jogo
    public void ConsumirRecursos()
    {
        // Gera valores aleatórios de consumo diário
        float consumoEnergia = Random.Range(1f, 5f);  // energia em kWh
        float consumoAgua = Random.Range(2f, 6f);      // água em litros

        // Soma ao total acumulado
        energiaConsumida += consumoEnergia;
        aguaConsumida += consumoAgua;
    }
}
