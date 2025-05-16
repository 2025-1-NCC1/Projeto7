using UnityEngine;

public class CasaEnergia : MonoBehaviour
{
    [SerializeField]
    public string nomeCasa;

    public float energiaConsumida = 0f;
    public float aguaConsumida = 0f;

    void Awake()
    {
        // Se o nome n�o for preenchido manualmente, usa o nome do GameObject
        if (string.IsNullOrWhiteSpace(nomeCasa))
        {
            nomeCasa = gameObject.name;
        }
    }

    // M�todo chamado uma vez por dia no jogo
    public void ConsumirRecursos()
    {
        // Gera valores aleat�rios de consumo di�rio
        float consumoEnergia = Random.Range(1f, 5f);  // energia em kWh
        float consumoAgua = Random.Range(2f, 6f);      // �gua em litros

        // Soma ao total acumulado
        energiaConsumida += consumoEnergia;
        aguaConsumida += consumoAgua;
    }
}
