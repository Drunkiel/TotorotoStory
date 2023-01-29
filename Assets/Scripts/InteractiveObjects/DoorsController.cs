using UnityEngine;

public class DoorsController : MonoBehaviour
{
    public bool isDoorClosed;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangeDoorState()
    {
        isDoorClosed = !isDoorClosed;

        if (isDoorClosed) anim.Play("Doors_Close");
        else anim.Play("Doors_Open");
    }
}
