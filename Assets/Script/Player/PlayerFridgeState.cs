using UnityEngine;

public class PlayerFridgeState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        player.ResetArrowHighlight();
        player.DisableKeyPrompt();
        player.EnableArrow("Up", "Soda");
        player.EnableArrow("Down", "Ice");
        player.EnableArrow("Left", "Milk");
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
                    if (player.currentItem == "Iced Cup")
                    {
                        player.ChangeCurrentItem("Iced Soda");
                    }
                    else
                    {
                        player.ChangeCurrentItem("Trash");
                    }
                    player.SwitchState(player.movementState);
                    break;
                case "Down":
                    if (player.currentItem == "")
                    {
                        player.ChangeCurrentItem("Ice");
                    }
                    else if (player.currentItem == "Cold Coffee")
                    {
                        player.ChangeCurrentItem("Iced Coffee");
                    }
                    else if (player.currentItem == "Cold Latte")
                    {
                        player.ChangeCurrentItem("Iced Latte");
                    }
                    else if (player.currentItem == "Cold Cup")
                    {
                        player.ChangeCurrentItem("Iced Cup");
                    }
                    else
                    {
                        player.ChangeCurrentItem("Trash");
                    }
                    player.SwitchState(player.movementState);
                    break;
                case "Left":
                    if (player.currentItem == "Hot Coffee")
                    {
                        player.ChangeCurrentItem("Hot Latte");
                    }
                    else if (player.currentItem == "Cold Coffee")
                    {
                        player.ChangeCurrentItem("Cold Latte");
                    }
                    else
                    {
                        player.ChangeCurrentItem("Trash");
                    }
                    player.SwitchState(player.movementState);
                    break;
                case "Right":
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
