using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : InteractableObj
{
    public override void Interact(Player player)
    {
        player.SwitchState(player.fridgeState);
    }
}
