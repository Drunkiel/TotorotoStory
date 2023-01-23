using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsController : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public float energyReserve;
    public int maxEnergyReserve;

    public Slider healthSlider;
    public Slider energySlider;

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
    }

    void UpdateEnergy()
    {
        if (_skillsController.isLightOn) energyReserve -= Time.deltaTime;
        if (_skillsController.isNightVisionOn) energyReserve -= Time.deltaTime * 2;

        energySlider.value = energyReserve;
    }
}
