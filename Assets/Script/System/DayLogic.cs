using UnityEngine;

public class DayLogic : MonoBehaviour
{
    public string[] orderList;
    public int maxTime = 90;
    public float minHype = 0f;
    public float hypeDepleteSpeed = 5f;
    public float hypeMultiplier { get; private set; }
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
        hypeMultiplier = 1;
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
        hypeMeter = Mathf.Max(0, hypeMeter - Time.deltaTime * 0.001f * hypeDepleteSpeed * Mathf.CeilToInt(hypeMeter));
        hypeMultiplier = 1f + Mathf.FloorToInt(hypeMeter) * 0.25f;
    }
    public void AdjustMoney(int amount)
    {
        currentMoney += amount;
        eventBroadcast.ChangeToMoneyNoti();
    }
    public void AdjustHypeMeter(float f)
    {
        hypeMeter = Mathf.Clamp(hypeMeter + f, 0f, 4.999f);
        hypeMultiplier = 1f + Mathf.FloorToInt(hypeMeter) * 0.25f;
    }
    public void AdjustHP(int amount)
    {
        HP += amount;
        eventBroadcast.ChangeToHPNoti();
        if (HP <= 0)
        {
            eventBroadcast.GameOverNoti();
        }
    }
    private void StartTheDay()
    {
        dayHasStart = true;
    }
}
