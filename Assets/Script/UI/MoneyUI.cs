using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private DayLogic dayLogic;
    [SerializeField] private EventBroadcast eventBroadcast;
    private void OnEnable()
    {
        UpdateMoney();
        eventBroadcast.changeToMoney += UpdateMoney;
    }
    private void OnDisable()
    {
        eventBroadcast.changeToMoney -= UpdateMoney;
    }
    private void UpdateMoney()
    {
        textMesh.text = "Earning: " + dayLogic.currentMoney;
    }
}
