using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsController : MonoBehaviour
{
    public float health;
    public int maxHealth;
    public float energyReserve;
    public int maxEnergyReserve;

    public int coins;

    public Slider healthSlider;
    public TMP_Text healthPercent;
    public Slider energySlider;
    public TMP_Text energyPercent;

    PlayerSkillsController _skillsController;

    // Start is called before the first frame update
    void Start()
    {
        _skillsController = GetComponent<PlayerSkillsController>();
        healthSlider.maxValue = maxHealth;
        energySlider.maxValue = maxEnergyReserve;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        UpdateEnergy();
    }

    void UpdateHealth()
    {
        healthSlider.value = health;
        healthPercent.text = Mathf.Round(health / maxHealth * 100).ToString() + "%";
    }

    void UpdateEnergy()
    {
        if (_skillsController.isLightOn) energyReserve -= Time.deltaTime * 1;
        if (_skillsController.isNightVisionOn) energyReserve -= Time.deltaTime * 2;

        energySlider.value = energyReserve;
        energyPercent.text = Mathf.Round(energyReserve / maxEnergyReserve * 100).ToString() + "%";
    }

    public void TakeDamage(int value)
    {
        health -= value;

        if (health <= 0) health = maxHealth;
        ConsoleController.SendTextConsole("Damage taken: " + value);
    }
}
