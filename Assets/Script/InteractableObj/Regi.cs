using System;
using UnityEngine;

public class Regi : InteractableObj
{
    public ItemLibrary itemLibrary;
    public SystemSetting systemSetting;
    public DayLogic dayLogic;
    public AudioSource success;
    public AudioSource fail;
    public EventBroadcast eventBroadcast;
    private void OnEnable()
    {
        ChangeVolume();
        eventBroadcast.changeVolume += ChangeVolume;
    }
    private void OnDisable()
    {
        eventBroadcast.changeVolume -= ChangeVolume;
    }
    public override void Interact(Player player)
    {
        if (player.currentCustomer == null || player.currentItem == "")
        {
            player.ChangeCurrentItem("");
            return;
        }
        if (player.currentItem == player.currentCustomer.order.itemName)
        {
            int bonus = 0;
            if (player.currentCustomer.satisfaction > 0.9f)
            {
                bonus = 40;
                player.currentCustomer.SpawnReview("Extreme");
                dayLogic.AdjustHypeMeter(0.3f);
            }
            else if (player.currentCustomer.satisfaction > 0.8f)
            {
                bonus = 20;
                player.currentCustomer.SpawnReview("Extreme");
                dayLogic.AdjustHypeMeter(0.2f);
            }
            else if (player.currentCustomer.satisfaction > 0.6f)
            {
                player.currentCustomer.SpawnReview("Good");
                dayLogic.AdjustHypeMeter(0.1f);
            }
            else if (player.currentCustomer.satisfaction > 0.4)
            {
                player.currentCustomer.SpawnReview("Good");
                dayLogic.AdjustHypeMeter(-0.25f);
            }
            else if (player.currentCustomer.satisfaction > 0.2f)
            {
                player.currentCustomer.SpawnReview("Good");
                dayLogic.AdjustHypeMeter(-0.4f);
            }
            else
            {
                player.currentCustomer.SpawnReview("Good");
                dayLogic.AdjustHypeMeter(-0.5f);
            }
            Item i = Array.Find(itemLibrary.itemLibrary, x => x.itemName == player.currentItem);
            Debug.Assert(i != null);
            dayLogic.AdjustMoney(i.price * (100+bonus));
            success.Play();
        }
        else
        {
            player.currentCustomer.SpawnReview("Bad");
            dayLogic.AdjustHP(-1);
            dayLogic.AdjustHypeMeter(-0.5f);
            fail.Play();
        }
        player.ChangeCurrentItem("");
        player.RemoveOrder();
        player.eventBroadcast.OrderCompleteNoti();
    }
    private void ChangeVolume()
    {
        success.volume = systemSetting.volume;
        fail.volume = systemSetting.volume;
    }
}
