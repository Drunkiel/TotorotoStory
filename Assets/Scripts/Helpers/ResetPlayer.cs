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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = newPosition.position;
        player.transform.rotation = newPosition.rotation;
    }
}
