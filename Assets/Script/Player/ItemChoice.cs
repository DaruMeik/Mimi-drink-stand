using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChoice : ItemDisplay
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite highlightSprite;
    [SerializeField] private SpriteRenderer arrowSR;
    public string dir;
    public void TurnOnHighlight()
    {
        arrowSR.sprite = highlightSprite;
    }
    public void TurnOffHighlight()
    {
        arrowSR.sprite = normalSprite;
    }
}
