using UnityEngine;
using UnityEngine.Events;

public class ButtonObject : MonoBehaviour
{
    public GameObject cursorToDisplay;
    public bool onClick;
    public bool onDrag;
    public UnityEvent unityEvent;

    TriggerController _triggerController;

    void Start()
    {
        if (cursorToDisplay == null) cursorToDisplay = GameObject.Find("Cursors").transform.GetChild(0).gameObject;

        _triggerController = GetComponent<TriggerController>();
    }

    void OnMouseOver()
    {
        if (_triggerController.isTriggered) cursorToDisplay.SetActive(true);
        else cursorToDisplay.SetActive(false);
    }

    void OnMouseExit()
    {
        cursorToDisplay.SetActive(false);
    }

    void OnMouseDrag()
    {
        if (onDrag && _triggerController.isTriggered) unityEvent.Invoke();
    }

    void OnMouseDown()
    {
        if (onClick && _triggerController.isTriggered) unityEvent.Invoke();
    }
}
