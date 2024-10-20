using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemLibrary", menuName = "ScriptObj/ItemLibrary")]
public class ItemLibrary : ScriptableObject
{
    public Item[] itemLibrary;
}