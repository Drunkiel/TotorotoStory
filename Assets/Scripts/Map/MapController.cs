using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject[] allMaps;
    public int lastMapEnded = -1;
    public int nextMap;

    public DoorsController _doorsController;

    void Start()
    {
        lastMapEnded = GameObject.Find("SaveLoad").GetComponent<SaveLoadController>()._playerData.lastMapEnded;
    }

    public void PickMap()
    {
        if (!_doorsController.isDoorClosed) return;

        //Deleting map
        DestroyActualMap();

        nextMap = lastMapEnded + 1;

        Instantiate(allMaps[nextMap], allMaps[nextMap].transform.position, allMaps[nextMap].transform.rotation);
    }

    public void EndMap()
    {
        if (lastMapEnded < nextMap) lastMapEnded += 1;
        else ConsoleController.SendTextConsole("The map has been completed!");
    }

    void DestroyActualMap()
    {
        GameObject[] maps = GameObject.FindGameObjectsWithTag("Map");

        foreach (GameObject map in maps)
        {
            Destroy(map);
        }
    }
}
