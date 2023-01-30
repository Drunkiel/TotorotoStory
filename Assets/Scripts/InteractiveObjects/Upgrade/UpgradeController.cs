using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public Item _item;
    PlayerStatsController _statsController;

    void Start()
    {
        _statsController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();
        SetValues();
    }

    public void AddPoints()
    {
        if (_item.boughtUpgrades < _item.maxUpgrade && _statsController.coins >= _item.price)
        {
            switch (_item.id)
            {
                case 0:
                    UpgradeEnergy();
                    break;

                case 1:
                    UpgradeCharging();
                    break;

                case 2:
                    UpgradeEnergy();
                    break;
            }

            _statsController.coins -= _item.price;
            _item.boughtUpgrades++;
        }
        else
        {
            if (_item.boughtUpgrades >= _item.maxUpgrade) print("Max Upgraded");
            if (_statsController.coins < _item.price) print("Not enough coins");
        }
    }

    void UpgradeEnergy()
    {
        PlayerUpgrades.energyPoints++;
        _statsController.maxEnergyReserve += _item.value;
        _statsController.energySlider.maxValue = _statsController.maxEnergyReserve;
    }

    void UpgradeCharging()
    {
        PlayerUpgrades.fastChargingPoints++;
    }

    void SetValues()
    {
        int loop = _item.boughtUpgrades;

        switch (_item.id)
        {
            case 0:
                loop = PlayerUpgrades.energyPoints;
                break;

            case 1:
                loop = PlayerUpgrades.fastChargingPoints;
                break;
        }

        for (int i = 0; i < loop; i++)
        {
            AddPoints();
        }
    }
}
