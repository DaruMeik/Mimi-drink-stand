using UnityEngine;


[CreateAssetMenu(fileName = "eventBroadcast", menuName = "ScriptObj/Event")]
public class EventBroadcast : ScriptableObject
{
    public delegate void VoidEvent();
    public event VoidEvent orderComplete;
    public event VoidEvent orderCancel;
    public event VoidEvent changeToMoney;
    public event VoidEvent changeToHP;
    public event VoidEvent turnLeft;
    public event VoidEvent turnRight;
    public event VoidEvent storeOpen;
    public event VoidEvent storeClose;
    public event VoidEvent noMoreCustomer;
    public event VoidEvent gameOver;
    public event VoidEvent turnOffUI;
    public event VoidEvent turnOffPauseMenu;
    public event VoidEvent returnable;

    public event VoidEvent changeName;
    public event VoidEvent changeVolume;
    public event VoidEvent changeInput;

    public delegate void CustomerEvent(Customer c);
    public event CustomerEvent createOrder;

    public delegate void IntEvent(int i);
    public event IntEvent leaveQueue;
    public void OrderCompleteNoti()
    {
        if (orderComplete != null)
            orderComplete.Invoke();
    }
    public void OrderCancelNoti()
    {
        if (orderCancel != null)
            orderCancel.Invoke();
    }
    public void ChangeToMoneyNoti()
    {
        if (changeToMoney != null)
            changeToMoney.Invoke();
    }
    public void ChangeToHPNoti()
    {
        if (changeToHP != null)
            changeToHP.Invoke();
    }
    public void TurnLeftNoti()
    {
        if (turnLeft != null)
            turnLeft.Invoke();
    }
    public void TurnRightNoti()
    {
        if (turnRight != null)
            turnRight.Invoke();
    }
    public void StoreOpenNoti()
    {
        if(storeOpen != null)
            storeOpen.Invoke();
    }
    public void StoreCloseNoti()
    {
        if (storeClose != null)
            storeClose.Invoke();
    }
    public void NoMoreCustomerNoti()
    {
        if(noMoreCustomer != null)
            noMoreCustomer.Invoke();
    }
    public void GameOverNoti()
    {
        if(gameOver != null)
            gameOver.Invoke();
    }
    public void TurnOffUINoti()
    {
        if (turnOffUI != null)
            turnOffUI.Invoke();
    }
    public void TurnOffPauseMenuNoti()
    {
        if (turnOffPauseMenu != null)
            turnOffPauseMenu.Invoke();
    }
    public void ChangeNameNoti()
    {
        if(changeName != null)
            changeName.Invoke();
    }
    public void ChangeVolumeNoti()
    {
        if(changeVolume != null)
            changeVolume.Invoke();
    }
    public void ChangeInputNoti()
    {
        if(changeInput != null)
            changeInput.Invoke();
    }
    public void ReturnableNoti()
    {
        if(returnable != null)
            returnable.Invoke();
    }
    public void CreateOrderNoti(Customer c)
    {
        if (createOrder != null)
            createOrder.Invoke(c);
    }
    public void LeavevQueueNoti(int queuePos)
    {
        if (leaveQueue != null)
            leaveQueue.Invoke(queuePos);
    }
}