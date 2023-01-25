using UnityEngine;

public class ToxicFluid : MonoBehaviour
{
    public float cooldown;
    public float resCooldown;

    PlayerStatsController _playerStatsController;
    TriggerController _triggerController; 

    // Start is called before the first frame update
    void Start()
    {
        _triggerController = GetComponent<TriggerController>();
        _playerStatsController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_triggerController.isTriggered) Timer();
    }

    void Timer()
    {
        if (cooldown <= 0)
        {
            _playerStatsController.TakeDamage(2);
            cooldown = resCooldown;
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }
}
