using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadInterface : MonoBehaviour
{
    public TMP_Text itemName;
    public Image itemImage;

    Item _item;

    // Start is called before the first frame update
    void Start()
    {
        _item = GetComponent<UpgradeController>()._item;

        itemName.text = _item.itemName;
        itemImage.sprite = _item.icon;

        Destroy(GetComponent<LoadInterface>());
    }
}
