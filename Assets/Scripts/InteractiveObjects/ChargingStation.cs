using UnityEngine;

public class ChargingStation : MonoBehaviour
{
    PlayerStatsController _playerStatsController;

    void Start()
    {
        _playerStatsController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();
    }

    public void Charge(int percentValue)
    {
        if (_playerStatsController.energyReserve < _playerStatsController.maxEnergyReserve) _playerStatsController.energyReserve += Time.deltaTime * percentValue / 100;
    }
}
