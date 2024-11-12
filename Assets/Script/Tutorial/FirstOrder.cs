using System;
using UnityEngine;

public class FirstOrder : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject customerObj;
    [SerializeField] private GameObject queueObj;
    [SerializeField] private DayLogic dayLogic;
    [SerializeField] private ItemLibrary itemLibrary;
    [SerializeField] private EventBroadcast eventBroadcast;
    [SerializeField] private SystemSetting systemSetting;
    [SerializeField] private GameObject spawnPos;
    [SerializeField] private GameObject targetPos;
    [SerializeField] private GameObject orderUI;
    [SerializeField] private GameObject cuptrayUI;
    [SerializeField] private GameObject cupUI;
    [SerializeField] private GameObject coffeeMachineUI;
    [SerializeField] private GameObject coffeeUI;
    [SerializeField] private GameObject regiUI;
    [SerializeField] private GameObject hypeUI0;
    [SerializeField] private GameObject hypeUI1;
    [SerializeField] private GameObject hypeUI2;
    [SerializeField] private GameObject finalUI;
    [SerializeField] private GameObject wrongUI;
    [SerializeField] private GameObject wrongUI1;
    [SerializeField] private GameObject sinkUI;
    private Customer customer;
    private int currentTut = 0;
    private bool wrongTut = false;
    private bool sinkTut = false;
    private string lastItem = "";
    private void OnEnable()
    {
        currentTut = 0;
        wrongTut = false;
        sinkTut = false;
        if (systemSetting.finishFirstDay)
        {
            queueObj.SetActive(true);
            gameObject.SetActive(false);
            return;
        }
        SpawnCustomer();
    }
    private void Update()
    {
        if (wrongTut && !sinkTut && !wrongUI.activeSelf)
        {
            sinkTut = true;
            lastItem = player.currentItem;
            player.ChangeCurrentItem("");
            player.SwitchState(player.pauseState);
            sinkUI.SetActive(true);
        }
        if(sinkTut && !sinkUI.activeSelf && lastItem != "")
        {
            player.ChangeCurrentItem(lastItem);
            lastItem = "";
        }
        if(currentTut == 0 && Vector3.Distance(customer.transform.position, targetPos.transform.position) <= 0.01f)
        {
            systemSetting.firstRecipe = true;
            currentTut++;
            player.SwitchState(player.pauseState);
            orderUI.SetActive(true);
        }
        if(currentTut == 1 && !orderUI.activeSelf)
        {
            currentTut++;
            player.SwitchState(player.pauseState);
            cuptrayUI.SetActive(true);
        }
        if (currentTut == 2 && player.currentState == player.cupState)
        {
            currentTut++;
            cupUI.SetActive(true);
        }
        if (currentTut == 3)
        {
            if(player.currentItem != "")
            {
                cupUI.SetActive(false);
                if (player.currentItem == "Hot Cup")
                {
                    currentTut++;
                    player.SwitchState(player.pauseState);
                    coffeeMachineUI.SetActive(true);
                }
                else if (!wrongTut)
                {
                    wrongTut = true;
                    player.SwitchState(player.pauseState);
                    wrongUI.SetActive(true);
                }
            }
        }
        if (currentTut == 4 && player.currentState == player.coffeeState)
        {
            currentTut++;
            coffeeUI.SetActive(true);
        }
        if (currentTut == 5)
        {
            if (player.currentItem != "Hot Cup")
            {
                coffeeUI.SetActive(false);
                if (player.currentItem == "Hot Coffee")
                {
                    currentTut++;
                    player.SwitchState(player.pauseState);
                    regiUI.SetActive(true);
                }
                else if (!wrongTut)
                {
                    wrongTut = true;
                    player.SwitchState(player.pauseState);
                    wrongUI1.SetActive(true);
                }
            }
        }
        if(currentTut == 6 && !regiUI.activeSelf)
        {
            if (!sinkTut)
            {
                sinkTut = true;
                lastItem = player.currentItem;
                player.ChangeCurrentItem("");
                player.SwitchState(player.pauseState);
                sinkUI.SetActive(true);
            }
            else if (!sinkUI.activeSelf && (dayLogic.currentMoney > 0 || dayLogic.HP < 3))
            {
                dayLogic.AdjustMoney(-dayLogic.currentMoney);
                currentTut++;
                player.SwitchState(player.pauseState);
                hypeUI0.SetActive(true);
            }
        }
        if(currentTut == 7 && !hypeUI0.activeSelf)
        {
            currentTut++;
            player.SwitchState(player.pauseState);
            hypeUI1.SetActive(true);
        }
        if (currentTut == 8 && !hypeUI1.activeSelf)
        {
            currentTut++;
            player.SwitchState(player.pauseState);
            hypeUI2.SetActive(true);
        }
        if (currentTut == 9 && !hypeUI2.activeSelf)
        {
            currentTut++;
            player.SwitchState(player.pauseState);
            finalUI.SetActive(true);
        }
        if (currentTut == 10 && !finalUI.activeSelf)
        {
            queueObj.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void SpawnCustomer()
    {
        customer = Instantiate(customerObj, transform).GetComponent<Customer>();
        customer.gameObject.SetActive(false);
        customer.transform.position = spawnPos.transform.position;
        customer.SetDayLogic(dayLogic);
        customer.SetFirstPos(new GameObject[1] { targetPos }, spawnPos.transform);
        customer.gameObject.transform.position = spawnPos.transform.position;
        customer.gameObject.SetActive(true);
        customer.DecideOrder(Array.Find(itemLibrary.itemLibrary, x => x.itemName == "Hot Coffee"));
        customer.ChangeTarget(0);
    }
}
