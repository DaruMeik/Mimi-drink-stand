using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : InteractableObj
{
    public override void Interact(Player player)
    {
        player.ChangeCurrentItem("");
        player.SwitchState(player.movementState);
    }
}
