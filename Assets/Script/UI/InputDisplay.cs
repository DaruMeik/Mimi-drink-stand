using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputDisplay : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    [SerializeField] private TMP_SpriteAsset spriteAsset_MnK;
    [SerializeField] private TMP_SpriteAsset spriteAsset_Controller;
    [SerializeField] private SystemSetting systemSetting;
    [SerializeField] private EventBroadcast eventBroadcast;

    private void OnEnable()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        Debug.Assert(textMesh != null);
        ChangeInput();
        eventBroadcast.changeInput += ChangeInput;
    }
    private void OnDisable()
    {
        eventBroadcast.changeInput -= ChangeInput;
    }
    private void ChangeInput()
    {
        switch (systemSetting.display)
        {
            case SystemSetting.inputDisplay.MnK:
                textMesh.spriteAsset = spriteAsset_MnK;
                break;
            case SystemSetting.inputDisplay.Controller:
                textMesh.spriteAsset = spriteAsset_Controller;
                break;
        }
    }
}
