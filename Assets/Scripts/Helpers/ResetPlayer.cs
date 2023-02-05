using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public Transform newPosition;
    
    public void ResetView()
    {
        PlayerController _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _playerController.playerCamera.localRotation = Quaternion.Euler(0, -80f, -90f);
    }

    public void ResetPosition()
    {
        GameObject.Find("Player").transform.position = newPosition.position;
    }
}
