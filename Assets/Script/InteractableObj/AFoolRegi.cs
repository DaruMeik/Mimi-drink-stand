using System;
using UnityEngine;

public class AFoolRegi : Regi
{
    public override void Interact(Player player)
    {
        player.SwitchState(player.movementState);
        if (player.currentItem == "")
        {
            return;
        }
        if (player.currentCustomers.Count > 0)
        {
            Customer customer = player.currentCustomers.Dequeue();
            string order = customer.order.itemName;
            if (order != player.currentItem && CheckIfExistsOrder(dayLogic.orderList, order))
            {
                Item i = Array.Find(itemLibrary.itemLibrary, x => x.itemName == player.currentItem);
                Debug.Assert(i != null);
                dayLogic.AdjustMoney(Mathf.FloorToInt(i.price * 100f * dayLogic.hypeMultiplier));
                dayLogic.AdjustHypeMeter(0.15f * i.price);
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

    private bool CheckIfExistsOrder(OrderList[] ols, string order)
    {
        foreach(OrderList ol in ols)
        {
            foreach(string s in ol.order)
                if(s == order)
                    return true;
        }
        return false;
    }
}
