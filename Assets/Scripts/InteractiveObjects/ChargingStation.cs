using UnityEngine;

public class ChargingStation : MonoBehaviour
{
    private float fastCharging = 10;

    PlayerStatsController _playerStatsController;

    void Start()
    {
        _playerStatsController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();
    }

    public void Charge(int percentValue)
    {
        if (_playerStatsController.energyReserve < _playerStatsController.maxEnergyReserve) _playerStatsController.energyReserve += Time.deltaTime * (percentValue + fastCharging * PlayerUpgrades.fastChargingPoints) / 100;
    }
}
