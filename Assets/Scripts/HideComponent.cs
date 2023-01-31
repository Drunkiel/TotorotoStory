using System.Collections;
using UnityEngine;

public class HideComponent : MonoBehaviour
{
    public GameObject objectToHide;

    void Start()
    {
        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);

        objectToHide.SetActive(false);
        Destroy(GetComponent<HideComponent>());
    }
}
