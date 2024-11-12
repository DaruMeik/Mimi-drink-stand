using UnityEngine;
using TMPro;

public class DayInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayInfo;
    [SerializeField] private TextMeshProUGUI HP;
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private DayLogic dayLogic;
    [SerializeField] private SystemSetting systemSetting;
    [SerializeField] private EventBroadcast eventBroadcast;
    private void OnEnable()
    {
        UpdateDay();
        UpdateHP();
        UpdateMoney();
        eventBroadcast.changeToHP += UpdateHP;
        eventBroadcast.changeToMoney += UpdateMoney;
    }
    private void OnDisable()
    {
        eventBroadcast.changeToHP -= UpdateHP;
        eventBroadcast.changeToMoney -= UpdateMoney;
    }
    private void UpdateDay()
    {
        dayInfo.text = "<u>Day " + (systemSetting.currentRound + 1) + "</u>";
    }
    private void UpdateHP()
    {
        HP.text = "\n\nHP:\n";
        for(int i = 0; i < dayLogic.HP; i++)
        {
            HP.text += " <sprite name=ItemSprite_7> ";
        }
    }
    private void UpdateMoney()
    {
        money.text = "\n\n\n\n\nMoney:\n" + dayLogic.currentMoney;
    }
}
