using UnityEngine;

public class PlayerPauseState : PlayerBaseState
{
    private Player player;
    private bool returnable = false;
    public override void EnterState(Player player)
    {
        returnable = false;
        this.player = player;
        Time.timeScale = 0f;
        player.eventBroadcast.turnOffPauseMenu += Return;
        player.eventBroadcast.returnable += SetReturnable;
    }
    public override void UpdateState(Player player)
    {
        switch (player.currentMovInput)
        {
            case "Left":
                player.eventBroadcast.TurnLeftNoti();
                break;
            case "Right":
                player.eventBroadcast.TurnRightNoti();
                break;
        }
        if (returnable)
        {
            if (player.systemSetting.PressSouth() || player.systemSetting.PressEast())
            {
                Return();
            }
        }
    }
    public override void ExitState(Player player)
    {
        Time.timeScale = 1f;
        player.eventBroadcast.turnOffPauseMenu -= Return;
        player.eventBroadcast.returnable -= SetReturnable;
    }
    private void Return()
    {
        player.SwitchState(player.movementState);
    }
    private void SetReturnable()
    {
        returnable = true;
    }
}
