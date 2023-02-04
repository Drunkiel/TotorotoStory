using UnityEngine;

public class Spikes : MonoBehaviour
{
    public GameObject spikes;

    TriggerController _triggerController;

    // Start is called before the first frame update
    void Start()
    {
        _triggerController = GetComponent<TriggerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_triggerController.isTriggered)
        {
            spikes.transform.localPosition = Vector3.zero;
            GameObject.Find("Player").GetComponent<PlayerStatsController>().TakeDamage(1);
        }
    }
}
