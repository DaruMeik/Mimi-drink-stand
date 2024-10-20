using UnityEngine;


[CreateAssetMenu(fileName = "SystemSetting", menuName = "ScriptObj/SystemSetting")]
public class SystemSetting : ScriptableObject
{
    public PInput playerInput;
    public int currentRound = 0;
    public int totalMoney = 0;
    public int highestScore = 0;
    public EventBroadcast eventBroadcast;

    [Header("Meta stuffs")]
    public bool finishBaseGame = false;

    [Header("Setting")]
    public float volume = 1f;

    private void OnEnable()
    {
        playerInput = new PInput();
        playerInput.Player.Enable();
        playerInput.UI.Enable();
        ChangeVolume(1f);

        finishBaseGame = false;
        highestScore = 0;
        NewGame();
    }
    public void NewGame()
    {
        currentRound = 0;
        totalMoney = 0;
    }
    public void AdjustMoney(int amount)
    {
        totalMoney += amount;
    }
    public void ChangeVolume(float volume)
    {
        this.volume = volume;
        eventBroadcast.ChangeVolumeNoti();
    }

    public bool PressUp() => playerInput.Player.Up.WasPressedThisFrame();
    public bool PressDown() => playerInput.Player.Down.WasPressedThisFrame();
    public bool PressLeft() => playerInput.Player.Left.WasPressedThisFrame();
    public bool PressRight() => playerInput.Player.Right.WasPressedThisFrame();
    public bool PressInteract() => playerInput.Player.Interact.WasPressedThisFrame();
    public bool PressCancel() => playerInput.Player.Cancel.WasPressedThisFrame();
    public bool PressHelp() => playerInput.Player.Help.WasPressedThisFrame();
    public bool PressEscape() => playerInput.Player.Escape.WasPressedThisFrame();
    public bool PressCheat() => playerInput.Player.Cheat.WasPressedThisFrame();

    public Vector2 GetPointerPos() => playerInput.UI.Point.ReadValue<Vector2>();
}
