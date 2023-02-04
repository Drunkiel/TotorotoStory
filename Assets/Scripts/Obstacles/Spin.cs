using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinSpeed;
    public GameObject objectToSpin;

    // Update is called once per frame
    void Update()
    {
        objectToSpin.transform.Rotate(0, spinSpeed, 0);        
    }
}
