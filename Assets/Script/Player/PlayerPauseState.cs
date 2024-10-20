using UnityEngine;

public class PlayerPauseState : PlayerBaseState
{
    private Player player;
    public override void EnterState(Player player)
    {
        this.player = player;
        Time.timeScale = 0f;
        player.eventBroadcast.turnOffPauseMenu += Return;
    }
    public override void UpdateState(Player player)
    {
        switch (player.currentInput)
        {
            case "Left":
                player.eventBroadcast.TurnLeftNoti();
                break;
            case "Right":
                player.eventBroadcast.TurnRightNoti();
                break;
        }
        if (player.systemSetting.PressCancel() || player.systemSetting.PressEscape())
        {
            Return();
        }
    }
    public override void ExitState(Player player)
    {
        Time.timeScale = 1f;
        player.eventBroadcast.turnOffPauseMenu -= Return;
    }
    private void Return()
    {
        player.SwitchState(player.movementState);
    }
}
