public class Coffee : InteractableObj
{
    public override void Interact(Player player)
    {
        player.SwitchState(player.coffeeState);
    }
}