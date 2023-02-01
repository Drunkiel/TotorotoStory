using UnityEngine;

public class ConsoleController : MonoBehaviour
{
    public GameObject prefab;
    public Transform objectParent;

    private static GameObject textPrefab;
    public static string textToDisplay;
    private static Transform parent;

    void Awake()
    {
        textPrefab = prefab;
        parent = objectParent;
    }

    public static void SendTextConsole(string consoleText)
    {
        textToDisplay = consoleText;
        Instantiate(textPrefab, parent);
    }
}
