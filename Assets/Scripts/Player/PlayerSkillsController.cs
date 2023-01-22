using UnityEngine;

public class PlayerSkillsController : MonoBehaviour
{
    public bool isLightOn;
    public bool isNightVisionOn;

    public GameObject flashLight;
    public GameObject nightVisionLight;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) ChangeLightState();
        if (Input.GetKeyDown(KeyCode.E)) ChangeVisionState();
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
