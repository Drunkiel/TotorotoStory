using TMPro;
using UnityEngine;

public class ConsoleText : MonoBehaviour
{
    public TMP_Text consoleText;

    void Start()
    {
        consoleText.text = ConsoleController.textToDisplay;
    }
}
