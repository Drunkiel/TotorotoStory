using UnityEngine;
using UnityEngine.Events;

public class ButtonObject : MonoBehaviour
{
    public GameObject cursorToDisplay;
    public bool onClick;
    public bool onDrag;
    public UnityEvent unityEvent;

    void OnMouseEnter()
    {
        cursorToDisplay.SetActive(true);
    }

    void OnMouseExit()
    {
        cursorToDisplay.SetActive(false);
    }

    void OnMouseDrag()
    {
        if (onDrag) unityEvent.Invoke();
    }

    void OnMouseDown()
    {
        if (onClick) unityEvent.Invoke();
    }
}
