using UnityEngine;

public abstract class InteractableObj : MonoBehaviour
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite highlightSprite;
    [SerializeField] private SpriteRenderer sr;
    public virtual void TurnOnHighlight()
    {
        sr.sprite = highlightSprite;
    }
    public virtual void TurnOffHighlight()
    {
        sr.sprite = normalSprite;
    }
    public abstract void Interact(Player player);
}
