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
            ConsoleController.SendTextConsole("Succesfully upgraded");
        }
        else
        {
            if (_item.boughtUpgrades >= _item.maxUpgrade) ConsoleController.SendTextConsole("Max upgrade reached");
            if (_statsController.coins < _item.price) ConsoleController.SendTextConsole("Not enought coins");
        }
    }

    void UpgradeEnergy()
    {
        PlayerUpgrades.energyPoints++;
        _statsController.maxEnergyReserve += _item.value;
        _statsController.energySlider.maxValue = _statsController.maxEnergyReserve;

        if (PlayerUpgrades.energyPoints > _item.maxUpgrade) PlayerUpgrades.energyPoints = _item.maxUpgrade;
    }

    void UpgradeCharging()
    {
        PlayerUpgrades.fastChargingPoints++;

        if (PlayerUpgrades.fastChargingPoints > _item.maxUpgrade) PlayerUpgrades.fastChargingPoints = _item.maxUpgrade;
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
