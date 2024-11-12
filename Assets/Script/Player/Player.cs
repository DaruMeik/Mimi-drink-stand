using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerBaseState currentState { private set; get; }
    public PlayerPauseState pauseState = new PlayerPauseState();
    public PlayerEndState endState = new PlayerEndState();
    public PlayerMovementState movementState = new PlayerMovementState();
    public PlayerFridgeState fridgeState = new PlayerFridgeState();
    public PlayerIceState iceState = new PlayerIceState();
    public PlayerSyrupState syrupState = new PlayerSyrupState();
    public PlayerCupState cupState = new PlayerCupState();
    public PlayerCoffeeState coffeeState = new PlayerCoffeeState();

    public string currentDirInput { get; private set; }
    public string currentMovInput { get; private set; }
    public string currentItem { get; private set; }
    //public Customer currentCustomer { get; private set; }
    public Queue<Customer> currentCustomers = new Queue<Customer> { };

    [Header("Additional UI")]
    [SerializeField] private ItemDisplay thoughtItem;
    [SerializeField] private GameObject recipes;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private DayEndResult resultPage;

    [Header("Arrow")]
    public SpriteRenderer playerSprite;
    [SerializeField] private Transform everyPrompt;
    [SerializeField] private GameObject upArrow;
    [SerializeField] private GameObject upKeyPrompt;
    public ItemChoice upItem;
    [SerializeField] private GameObject downArrow;
    [SerializeField] private GameObject downKeyPrompt;
    public ItemChoice downItem;
    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject leftKeyPrompt;
    public ItemChoice leftItem;
    [SerializeField] private GameObject rightArrow;
    [SerializeField] private GameObject rightKeyPrompt;
    public ItemChoice rightItem;

    [Header("Scriptable Obj")]
    public SystemSetting systemSetting;
    public EventBroadcast eventBroadcast;

    private void OnEnable()
    {
        eventBroadcast.createOrder += ReceiveOrder;
        eventBroadcast.turnOffUI += DisableArrow;
        eventBroadcast.turnOffUI += DisableKeyPrompt;
        eventBroadcast.turnOffUI += DisableRecipes;
        eventBroadcast.turnOffUI += DisablePauseMenu;
        eventBroadcast.noMoreCustomer += ResultScreen;
        eventBroadcast.gameOver += GameOverScreen;
    }
    private void OnDisable()
    {
        eventBroadcast.createOrder -= ReceiveOrder;
        eventBroadcast.turnOffUI -= DisableArrow;
        eventBroadcast.turnOffUI -= DisableKeyPrompt;
        eventBroadcast.turnOffUI -= DisableRecipes;
        eventBroadcast.turnOffUI -= DisablePauseMenu;
        eventBroadcast.noMoreCustomer -= ResultScreen;
        eventBroadcast.gameOver -= GameOverScreen;
    }
    private void Awake()
    {
        currentDirInput = "";
        currentCustomers.Clear();
        DisableRecipes();
        ChangeCurrentItem("");
        SwitchState(pauseState);
    }

    private void Update()
    {
        currentMovInput = "";
        if (systemSetting.PressUp())
            currentMovInput = "Up";
        if (systemSetting.PressDown())
            currentMovInput = "Down";
        if (systemSetting.PressLeft())
            currentMovInput = "Left";
        if (systemSetting.PressRight())
            currentMovInput = "Right";

        currentDirInput = "";
        if (systemSetting.PressNorth())
            currentDirInput = "Up";
        if (systemSetting.PressSouth())
            currentDirInput = "Down";
        if (systemSetting.PressWest())
            currentDirInput = "Left";
        if (systemSetting.PressEast())
            currentDirInput = "Right";

        if (systemSetting.PressCheat())
            systemSetting.finishBaseGame = true;
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        if (currentState != null)
            currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);
    }
    public PlayerBaseState GetState() => currentState;
    public void ChangeCurrentItem(string item)
    {
        currentItem = item;
        if(currentItem != "")
        {
            thoughtItem.ChangeSprite(currentItem);
            thoughtItem.gameObject.SetActive(true);
        }
        else
        {
            thoughtItem.gameObject.SetActive(false);
        }
    }

    // Additional UI
    public void EnableRecipes()
    {
        recipes.SetActive(true);
    }
    public void DisableRecipes()
    {
        recipes.SetActive(false);
    }
    public void EnablePauseMenu()
    {
        pauseMenu.SetActive(true);
    }
    public void DisablePauseMenu()
    {
        pauseMenu.SetActive(false);
    }
    public void DisableArrow()
    {
        upArrow.SetActive(false);
        downArrow.SetActive(false);
        leftArrow.SetActive(false);
        rightArrow.SetActive(false);
    }
    public void DisableKeyPrompt()
    {
        upKeyPrompt.SetActive(false);
        downKeyPrompt.SetActive(false);
        leftKeyPrompt.SetActive(false);
        rightKeyPrompt.SetActive(false);
    }
    public void ResetArrowHighlight()
    {
        upItem.TurnOffHighlight();
        downItem.TurnOffHighlight();
        leftItem.TurnOffHighlight();
        rightItem.TurnOffHighlight();
    }
    private void ResultScreen()
    {
        resultPage.daySuccess = true;
        resultPage.gameObject.SetActive(true);
        SwitchState(endState);
    }
    private void GameOverScreen()
    {
        resultPage.daySuccess = false;
        resultPage.gameObject.SetActive(true);
        SwitchState(endState);
    }
    public void ChangeArrowPos(string dir)
    {
        switch (dir)
        {
            case "Up":
                everyPrompt.localPosition = new Vector3(0f, 1f, 0f);
                break;
            case "Down":
                everyPrompt.localPosition = new Vector3(0f, -1f, 0f);
                break;
            case "Normal":
                everyPrompt.localPosition = Vector3.zero;
                break;
        }
    }
    public void EnableArrow(string dir, string item)
    {
        EnableKeyPrompt(dir);
        switch (dir)
        {
            case "Up":
                upItem.ChangeSprite(item);
                upArrow.SetActive(true);
                break;
            case "Down":
                downItem.ChangeSprite(item);
                downArrow.SetActive(true);
                break;
            case "Left":
                leftItem.ChangeSprite(item);
                leftArrow.SetActive(true);
                break;
            case "Right":
                rightItem.ChangeSprite(item);
                rightArrow.SetActive(true);
                break;
        }
    }
    public void EnableKeyPrompt(string dir)
    {
        switch (dir)
        {
            case "Up":
                upKeyPrompt.SetActive(true);
                break;
            case "Down":
                downKeyPrompt.SetActive(true);
                break;
            case "Left":
                leftKeyPrompt.SetActive(true);
                break;
            case "Right":
                rightKeyPrompt.SetActive(true);
                break;
        }
    }
    private void ReceiveOrder(Customer c)
    {
        currentCustomers.Enqueue(c);
    }
}
