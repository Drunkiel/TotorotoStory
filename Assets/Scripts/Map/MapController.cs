using System.Linq;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject[] allMaps;
    public bool[] pickedMaps;
    public int[] restOfTheMaps;

    public DoorsController _doorsController;
    public Transform placeToSpawn;

    void Start()
    {
        pickedMaps = new bool[allMaps.Length];
        Fill();
    }

    public void PickMap()
    {
        if (!_doorsController.isDoorClosed) return;

        //Deleting map
        DestroyActualMap();

        //Check if have been any maps left
        if (restOfTheMaps.Length == 0) Fill();

        int ranNum = (int)Mathf.Round(Random.Range(0, restOfTheMaps.Length));

        Instantiate(allMaps[restOfTheMaps[ranNum]], allMaps[restOfTheMaps[ranNum]].transform.position, allMaps[restOfTheMaps[ranNum]].transform.rotation);

        restOfTheMaps = restOfTheMaps.Except(new int[] { restOfTheMaps[ranNum] }).ToArray();
        ReFillMaps();
    }

    void ReFillMaps()
    {
        for (int i = 0; i < pickedMaps.Length; i++)
        {
            pickedMaps[i] = true;

            for (int j = 0; j < restOfTheMaps.Length; j++)
            {
                if (i == restOfTheMaps[j]) pickedMaps[i] = false;
            }
        }
    }

    void Fill()
    {
        restOfTheMaps = new int[allMaps.Length];

        for (int i = 0; i < restOfTheMaps.Length; i++)
        {
            restOfTheMaps[i] = i;
            pickedMaps[i] = false;
        }
    }

    void DestroyActualMap()
    {
        GameObject[] maps = GameObject.FindGameObjectsWithTag("Map");

        foreach (GameObject map in maps)
        {
            Destroy(map.transform.parent.gameObject);
        }
    }
}
