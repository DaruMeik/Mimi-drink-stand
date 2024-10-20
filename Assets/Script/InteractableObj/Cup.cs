using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : InteractableObj
{
    public override void Interact(Player player)
    {
        player.SwitchState(player.cupState);
    }
}
