using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIceState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        player.ResetArrowHighlight();
        player.DisableKeyPrompt();
        player.EnableArrow("Left", "Small Cup");
        player.EnableArrow("Right", "Big Cup");
    }
    public override void UpdateState(Player player)
    {
        if (player.systemSetting.PressEscape())
        {
            player.EnablePauseMenu();
            player.SwitchState(player.pauseState);
            return;
        }
        if (player.currentInput != "")
        {
            switch (player.currentInput)
            {
                case "Up":
                    break;
                case "Down":
                    break;
                case "Left":
                    if (player.currentItem == "Ice")
                    {
                        player.ChangeCurrentItem("Shaved Ice Big");
                    }
                    else
                    {
                        player.ChangeCurrentItem("Trash");
                    }
                    player.SwitchState(player.movementState);
                    break;
                case "Right":
                    if (player.currentItem == "Ice")
                    {
                        player.ChangeCurrentItem("Shaved Ice Small");
                    }
                    else
                    {
                        player.ChangeCurrentItem("Trash");
                    }
                    player.SwitchState(player.movementState);
                    break;
            }
        }
        else if (player.systemSetting.PressCancel())
        {
            player.SwitchState(player.movementState);
        }
    }
    public override void ExitState(Player player)
    {
    }
}
