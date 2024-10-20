using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        Time.timeScale = 0f;
    }
    public override void UpdateState(Player player)
    {
    }
    public override void ExitState(Player player)
    {
    }
}