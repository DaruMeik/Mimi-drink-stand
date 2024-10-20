using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private SystemSetting systemSetting;
    private void OnEnable()
    {
        systemSetting.finishBaseGame = true;
    }
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
