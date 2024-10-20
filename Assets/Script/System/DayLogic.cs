using UnityEngine;

public class DayLogic : MonoBehaviour
{
    public string[] orderList;
    public int maxTime = 90;
    public float minHype = 0f;
    public int currentMoney { get; private set; }
    public float startTime { get; private set; }
    public float hypeMeter { get; private set; }
    public int HP { get; private set; }
    private bool dayHasStart = false;
    [SerializeField] private GameObject dayTutorial;
    [SerializeField] private SystemSetting systemSetting;
    [SerializeField] private ItemLibrary itemLibrary;
    [SerializeField] private EventBroadcast eventBroadcast;

    private void OnEnable()
    {
        Debug.Assert(orderList.Length > 0);
        hypeMeter = 0;
        AdjustHypeMeter(0.2f + 0.075f * systemSetting.currentRound);
        HP = 3;
        AdjustHP(0);
        dayHasStart = false;
        dayTutorial.SetActive(true);

        eventBroadcast.storeOpen += StartTheDay;
    }
    private void OnDisable()
    {
        eventBroadcast.storeOpen -= StartTheDay;
    }
    private void Update()
    {
        if (!dayHasStart)
        {
            startTime = Time.time;
        }
        if (Time.time - startTime >= maxTime)
        {
            eventBroadcast.StoreCloseNoti();
        }
    }
    public void AdjustMoney(int amount)
    {
        currentMoney += amount;
        eventBroadcast.ChangeToMoneyNoti();
    }
    public void AdjustHypeMeter(float f)
    {
        hypeMeter = Mathf.Clamp(hypeMeter + f, minHype, 1);
    }
    public void AdjustHP(int amount)
    {
        HP+= amount;
        eventBroadcast.ChangeToHPNoti();
        if (HP < 0)
        {
            eventBroadcast.GameOverNoti();
        }
    }
    private void StartTheDay()
    {
        dayHasStart = true;
    }
}
