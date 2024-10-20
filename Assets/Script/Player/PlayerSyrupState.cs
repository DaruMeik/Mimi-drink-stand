using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSyrupState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        player.ResetArrowHighlight();
        player.DisableKeyPrompt();
        player.EnableArrow("Up", "Blueberry");
        player.EnableArrow("Down", "Kiwi");
        player.EnableArrow("Left", "Strawberry");
        player.EnableArrow("Right", "Orange");
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
                    if (player.currentItem == "Shaved Ice Small")
                    {
                        player.ChangeCurrentItem("Shaved Ice Small Blueberry");
                    }
                    else if (player.currentItem == "Shaved Ice Big")
                    {
                        player.ChangeCurrentItem("Shaved Ice Big Blueberry");
                    }
                    else if (player.currentItem == "Iced Soda")
                    {
                        player.ChangeCurrentItem("Blueberry Soda");
                    }
                    else
                    {
                        player.ChangeCurrentItem("Trash");
                    }
                    player.SwitchState(player.movementState);
                    break;
                case "Down":
                    if (player.currentItem == "Shaved Ice Small")
                    {
                        player.ChangeCurrentItem("Shaved Ice Small Kiwi");
                    }
                    else if (player.currentItem == "Shaved Ice Big")
                    {
                        player.ChangeCurrentItem("Shaved Ice Big Kiwi");
                    }
                    else if (player.currentItem == "Iced Soda")
                    {
                        player.ChangeCurrentItem("Kiwi Soda");
                    }
                    else
                    {
                        player.ChangeCurrentItem("Trash");
                    }
                    player.SwitchState(player.movementState);
                    break;
                case "Left":
                    if (player.currentItem == "Shaved Ice Small")
                    {
                        player.ChangeCurrentItem("Shaved Ice Small Strawberry");
                    }
                    else if (player.currentItem == "Shaved Ice Big")
                    {
                        player.ChangeCurrentItem("Shaved Ice Big Strawberry");
                    }
                    else if (player.currentItem == "Iced Soda")
                    {
                        player.ChangeCurrentItem("Strawberry Soda");
                    }
                    else
                    {
                        player.ChangeCurrentItem("Trash");
                    }
                    player.SwitchState(player.movementState);
                    break;
                case "Right":
                    if (player.currentItem == "Shaved Ice Small")
                    {
                        player.ChangeCurrentItem("Shaved Ice Small Orange");
                    }
                    else if (player.currentItem == "Shaved Ice Big")
                    {
                        player.ChangeCurrentItem("Shaved Ice Big Orange");
                    }
                    else if (player.currentItem == "Iced Soda")
                    {
                        player.ChangeCurrentItem("Orange Soda");
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
