using System;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField] private SpriteRenderer itemSR;
    [SerializeField] private ItemLibrary itemLibrary;
    public void ChangeSprite(string item)
    {
        Item i = Array.Find(itemLibrary.itemLibrary, x => x.itemName == item);
        Debug.Assert(i != null);    
        itemSR.sprite = i.sprite;
    }
}
