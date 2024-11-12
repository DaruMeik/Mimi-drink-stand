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
        player.SwitchState(player.movementState);
        if(player.currentItem == "")
        {
            return;
        }
        if (player.currentCustomers.Count > 0)
        {
            Customer customer = player.currentCustomers.Dequeue();
            string order = customer.order.itemName;
            if (order == player.currentItem)
            {
                Item i = Array.Find(itemLibrary.itemLibrary, x => x.itemName == player.currentItem);
                Debug.Assert(i != null);
                dayLogic.AdjustMoney(Mathf.FloorToInt(i.price*100f*dayLogic.hypeMultiplier));
                dayLogic.AdjustHypeMeter(0.15f*i.price);
                success.Play();
            }
            else
            {
                dayLogic.AdjustHP(-1);
                dayLogic.AdjustHypeMeter(-0.5f);
                fail.Play();
            }
            customer.LeaveTheShop();
        }
        player.ChangeCurrentItem("");
    }
    private void ChangeVolume()
    {
        success.volume = systemSetting.masterVolume * systemSetting.sfxVolume;
        fail.volume = systemSetting.masterVolume * systemSetting.sfxVolume;
    }
}
