public class IceShave : InteractableObj
{
    public override void Interact(Player player)
    {
        player.SwitchState(player.iceState);
    }
}
