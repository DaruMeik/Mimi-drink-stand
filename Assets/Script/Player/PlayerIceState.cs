using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIceState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        player.ResetArrowHighlight();
        player.DisableKeyPrompt();
        player.EnableArrow("Down", "Return");
        player.EnableArrow("Left", "Small Cup");
        player.EnableArrow("Right", "Big Cup");
    }
    public override void UpdateState(Player player)
    {
        if (player.systemSetting.PressBack())
        {
            player.EnablePauseMenu();
            player.SwitchState(player.pauseState);
            return;
        }
        if (player.currentDirInput != "")
        {
            switch (player.currentDirInput)
            {
                case "Up":
                    break;
                case "Down":
                    player.SwitchState(player.movementState);
                    break;
                case "Left":
                    if (player.currentItem == "Ice")
                    {
                        player.ChangeCurrentItem("Shaved Ice Big");
                    }
                    player.SwitchState(player.movementState);
                    break;
                case "Right":
                    if (player.currentItem == "Ice")
                    {
                        player.ChangeCurrentItem("Shaved Ice Small");
                    }
                    player.SwitchState(player.movementState);
                    break;
            }
        }
    }
    public override void ExitState(Player player)
    {
    }
}
