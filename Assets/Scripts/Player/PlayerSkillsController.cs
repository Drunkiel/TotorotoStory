using UnityEngine;

public class PlayerSkillsController : MonoBehaviour
{
    public bool isLightOn;
    public bool isNightVisionOn;
    public bool isEnoughEnergy;

    public GameObject flashLight;
    public GameObject nightVisionLight;

    PlayerStatsController _statsController;

    void Start()
    {
        _statsController = GetComponent<PlayerStatsController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckIfEnoughEnergy())
        {
            if (Input.GetMouseButtonDown(1)) ChangeLightState();
            if (Input.GetKeyDown(KeyCode.E)) ChangeVisionState();
        }
        else
        {
            if (isLightOn) ChangeLightState();
            if (isNightVisionOn) ChangeVisionState();
        }
    }

    bool CheckIfEnoughEnergy()
    {
        if (_statsController.energyReserve > 0) return true;
        else return false;
    }

    void ChangeLightState()
    {
        isLightOn = !isLightOn;

        flashLight.SetActive(isLightOn);
    }

    void ChangeVisionState()
    {
        isNightVisionOn = !isNightVisionOn;

        nightVisionLight.SetActive(isNightVisionOn);
    }
}
