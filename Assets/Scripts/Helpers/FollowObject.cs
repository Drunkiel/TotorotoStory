using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject objectToFollow;
    public float[] corrections = new float[3];

    void Update()
    {
        Follow();
    }

    void Follow()
    {
        transform.position = new Vector3(objectToFollow.transform.position.x + corrections[0],
                                         objectToFollow.transform.position.y + corrections[1],
                                         objectToFollow.transform.position.z + corrections[2]);
    }
}
