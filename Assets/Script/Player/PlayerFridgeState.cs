using UnityEngine;

public class PlayerFridgeState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        player.ResetArrowHighlight();
        player.DisableKeyPrompt();
        //player.EnableArrow("Up", "Egg");
        player.EnableArrow("Down", "Return");
        player.EnableArrow("Left", "Soda");
        player.EnableArrow("Right", "Ice");
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
                    //if (player.currentItem == "")
                    //{
                    //    player.ChangeCurrentItem("Egg");
                    //}
                    //else
                    //{
                    //    player.ChangeCurrentItem("Trash");
                    //}
                    //player.SwitchState(player.movementState);
                    break;
                case "Down":
                    player.SwitchState(player.movementState);
                    break;
                case "Left":
                    if (player.currentItem == "Iced Glass")
                    {
                        player.ChangeCurrentItem("Iced Soda");
                    }
                    player.SwitchState(player.movementState);
                    break;
                case "Right":
                    if (player.currentItem == "")
                    {
                        player.ChangeCurrentItem("Ice");
                    }
                    else if (player.currentItem == "Cold Glass")
                    {
                        player.ChangeCurrentItem("Iced Glass");
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
