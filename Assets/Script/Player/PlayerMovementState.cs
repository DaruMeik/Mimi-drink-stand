using UnityEngine;

public class PlayerMovementState : PlayerBaseState
{
    private InteractableObj highlightObjL;
    private InteractableObj highlightObjR;
    public override void EnterState(Player player)
    {
        player.eventBroadcast.TurnOffUINoti();
        CheckForObj(player.transform.position, player);
    }
    public override void UpdateState(Player player)
    {
        if (player.systemSetting.PressHelp())
        {
            player.EnableRecipes();
            player.SwitchState(player.pauseState);
            return;
        }
        if (player.systemSetting.PressEscape())
        {
            player.EnablePauseMenu();
            player.SwitchState(player.pauseState);
            return;
        }
        switch (player.currentInput)
        {
            case "Up":
                if (Physics2D.OverlapPoint(player.transform.position + Vector3.up, LayerMask.GetMask("Ground")))
                    player.transform.position += Vector3.up;
                CheckForObj(player.transform.position, player);
                break;
            case "Down":
                if (Physics2D.OverlapPoint(player.transform.position + Vector3.down, LayerMask.GetMask("Ground")))
                    player.transform.position += Vector3.down;
                CheckForObj(player.transform.position, player);
                break;
            case "Left":
                if (highlightObjL != null)
                    highlightObjL.Interact(player);
                break;
            case "Right":
                if (highlightObjR != null)
                    highlightObjR.Interact(player);
                break;
        }
    }
    public override void ExitState(Player player)
    {
    }
    private void CheckForObj(Vector3 pos, Player player)
    {
        if (highlightObjL != null)
        {
            highlightObjL.TurnOffHighlight();
            highlightObjL = null;
        }
        if (highlightObjR != null)
        {
            highlightObjR.TurnOffHighlight();
            highlightObjR = null;
        }
        player.DisableKeyPrompt();

        Collider2D hit;
        hit = Physics2D.OverlapPoint(pos + Vector3.left, LayerMask.GetMask("Interactable"));
        if (hit)
        {
            InteractableObj obj = hit.gameObject.GetComponent<InteractableObj>();
            highlightObjL = obj;
            highlightObjL.TurnOnHighlight();
            player.EnableKeyPrompt("Left");
        }
        hit = Physics2D.OverlapPoint(pos + Vector3.right, LayerMask.GetMask("Interactable"));
        if (hit)
        {
            InteractableObj obj = hit.gameObject.GetComponent<InteractableObj>();
            highlightObjR = obj;
            highlightObjR.TurnOnHighlight();
            player.EnableKeyPrompt("Right");
        }
    }
}
