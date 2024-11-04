using UnityEngine;

public class PlayerMovementState : PlayerBaseState
{
    private InteractableObj highlightObjU;
    private InteractableObj highlightObjD;
    public override void EnterState(Player player)
    {
        player.eventBroadcast.TurnOffUINoti();
        player.ChangeArrowPos("Normal");
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
                if (highlightObjU != null)
                {
                    player.ChangeArrowPos("Up");
                    highlightObjU.Interact(player);
                }
                break;
            case "Down":
                if (highlightObjD != null)
                {
                    player.ChangeArrowPos("Down");
                    highlightObjD.Interact(player);
                }
                break;
            case "Left":
                if (Physics2D.OverlapPoint(player.transform.position + Vector3.left, LayerMask.GetMask("Ground")))
                    player.transform.position += Vector3.left * 1.25f;
                CheckForObj(player.transform.position, player);
                break;
            case "Right":
                if (Physics2D.OverlapPoint(player.transform.position + Vector3.right, LayerMask.GetMask("Ground")))
                    player.transform.position += Vector3.right * 1.25f;
                CheckForObj(player.transform.position, player);
                break;
        }
    }
    public override void ExitState(Player player)
    {
    }
    private void CheckForObj(Vector3 pos, Player player)
    {
        if (highlightObjU != null)
        {
            highlightObjU.TurnOffHighlight();
            highlightObjU = null;
        }
        if (highlightObjD != null)
        {
            highlightObjD.TurnOffHighlight();
            highlightObjD = null;
        }
        player.DisableKeyPrompt();

        Collider2D hit;
        hit = Physics2D.OverlapPoint(pos + Vector3.up, LayerMask.GetMask("Interactable"));
        if (hit)
        {
            InteractableObj obj = hit.gameObject.GetComponent<InteractableObj>();
            highlightObjU = obj;
            highlightObjU.TurnOnHighlight();
            player.EnableKeyPrompt("Up");
        }
        hit = Physics2D.OverlapPoint(pos + Vector3.down, LayerMask.GetMask("Interactable"));
        if (hit)
        {
            InteractableObj obj = hit.gameObject.GetComponent<InteractableObj>();
            highlightObjD = obj;
            highlightObjD.TurnOnHighlight();
            player.EnableKeyPrompt("Down");
        }
    }
}
