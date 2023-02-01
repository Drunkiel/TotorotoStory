using UnityEngine;

public class UIController : MonoBehaviour
{
    public bool isUIOpen;
    public GameObject UI;

    public bool stopPlayer;
    
    public void OpenCloseUI()
    {
        isUIOpen = !isUIOpen;
        UI.SetActive(isUIOpen);

        if (isUIOpen) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;

        if (stopPlayer) PlayerController.stopPlayer = isUIOpen;
    }
}
