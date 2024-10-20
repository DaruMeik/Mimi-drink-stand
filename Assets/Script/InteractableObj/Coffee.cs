public class Coffee : InteractableObj
{
    public override void Interact(Player player)
    {
        switch (player.currentItem)
        {
            case "Hot Cup":
                player.ChangeCurrentItem("Hot Coffee");
                break;
            case "Cold Cup":
                player.ChangeCurrentItem("Cold Coffee");
                break;
            default:
                player.ChangeCurrentItem("Trash");
                break;
        }
    }
}