using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoffeeState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        player.ResetArrowHighlight();
        player.DisableKeyPrompt();
        player.EnableArrow("Up", "Return");
        player.EnableArrow("Left", "Milk");
        player.EnableArrow("Right", "Coffee");
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
                    player.SwitchState(player.movementState);
                    break;
                case "Down":
                    break;
                case "Left":
                    //if (player.currentItem == "Hot Cup")
                    //{
                    //    player.ChangeCurrentItem("Hot Milk");
                    //}
                    if (player.currentItem == "Hot Coffee")
                    {
                        player.ChangeCurrentItem("Hot Latte");
                    }
                    //else if (player.currentItem == "Iced Glass")
                    //{
                    //    player.ChangeCurrentItem("Iced Milk");
                    //}
                    else if (player.currentItem == "Iced Coffee")
                    {
                        player.ChangeCurrentItem("Iced Latte");
                    }
                    player.SwitchState(player.movementState);
                    break;
                case "Right":
                    if (player.currentItem == "Hot Cup")
                    {
                        player.ChangeCurrentItem("Hot Coffee");
                    }
                    //else if (player.currentItem == "Hot Milk")
                    //{
                    //    player.ChangeCurrentItem("Hot Latte");
                    //}
                    else if (player.currentItem == "Iced Glass")
                    {
                        player.ChangeCurrentItem("Iced Coffee");
                    }
                    //else if (player.currentItem == "Iced Milk")
                    //{
                    //    player.ChangeCurrentItem("Iced Latte");
                    //}
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
