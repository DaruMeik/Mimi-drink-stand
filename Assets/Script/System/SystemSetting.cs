using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class SaveData
{
    public List<int> highestScores;
    public bool firstRecipe = false;
    public bool finishFirstDay = false;
    public bool finishBaseGame = false;
    public float masterVolume = 1f;
    public float bgmVolume = 1f;
    public float sfxVolume = 1f;
}

[CreateAssetMenu(fileName = "SystemSetting", menuName = "ScriptObj/SystemSetting")]
public class SystemSetting : ScriptableObject
{
    public PInput playerInput;
    public int currentRound = 0;
    public List<int> highestScores;
    public EventBroadcast eventBroadcast;

    [Header("Meta stuffs")]
    public bool firstRecipe = false;
    public bool finishFirstDay = false;
    public bool finishBaseGame = false;

    [Header("Setting")]
    public float masterVolume = 1f;
    public float bgmVolume = 1f;
    public float sfxVolume = 1f;
    public inputDisplay display = inputDisplay.MnK;

    [Header("SaveData")]
    public string saveFilePath;
    public SaveData saveData = new SaveData();

    public enum inputDisplay
    {
        MnK,
        Controller
    }

    private void OnEnable()
    {
        saveFilePath = Application.persistentDataPath + "/PlayerData.json";
        playerInput = new PInput();
        playerInput.Player.Enable();

        if (File.Exists(saveFilePath))
        {
            LoadGame();
        }
        else
        {
            ChangeVolume(1f, 1f, 1f);
            display = inputDisplay.MnK;
            finishBaseGame = false;
            highestScores.Clear();
            highestScores.Add(0);
            NewGame();
        }
    }
    public void NewGame()
    {
        currentRound = 0;
        firstRecipe = false;
        finishFirstDay = false;
    }
    public void ChangeVolume(float masterVolume, float bgmVolume, float sfxVolume)
    {
        this.masterVolume = masterVolume;
        this.bgmVolume = bgmVolume;
        this.sfxVolume = sfxVolume;
        eventBroadcast.ChangeVolumeNoti();
    }
    public void ChangeInput()
    {
        if (display == inputDisplay.MnK)
            display = inputDisplay.Controller;
        else
            display = inputDisplay.MnK;
        eventBroadcast.ChangeInputNoti();
    }
    public void SaveGame()
    {
        // Update Save Data
        saveData.highestScores = highestScores;
        saveData.firstRecipe = firstRecipe;
        saveData.finishFirstDay = finishFirstDay;
        saveData.finishBaseGame = finishBaseGame;
        saveData.masterVolume = masterVolume;
        saveData.bgmVolume = bgmVolume;
        saveData.sfxVolume = sfxVolume;

        string savePlayerData = JsonUtility.ToJson(saveData);
        File.WriteAllText(saveFilePath, savePlayerData);

        Debug.LogWarning("Save file created at: " + saveFilePath);
    }
    public void LoadGame()
    {
        string loadPlayerData = File.ReadAllText(saveFilePath);
        saveData = JsonUtility.FromJson<SaveData>(loadPlayerData);

        Debug.LogWarning("Load game complete!");

        // Update Save Data
        highestScores = saveData.highestScores;
        firstRecipe = saveData.firstRecipe;
        finishFirstDay = saveData.finishFirstDay;
        finishBaseGame = saveData.finishBaseGame;
        masterVolume = saveData.masterVolume;
        bgmVolume = saveData.bgmVolume;
        sfxVolume = saveData.sfxVolume;
    }

    public bool PressUp() => playerInput.Player.Up.WasPressedThisFrame();
    public bool PressDown() => playerInput.Player.Down.WasPressedThisFrame();
    public bool PressLeft() => playerInput.Player.Left.WasPressedThisFrame();
    public bool PressRight() => playerInput.Player.Right.WasPressedThisFrame();
    public bool PressConfirm() => playerInput.Player.Confirm.WasPressedThisFrame();
    public bool PressCancel() => playerInput.Player.Cancel.WasPressedThisFrame();
    public bool PressHelp() => playerInput.Player.Help.WasPressedThisFrame();
    public bool PressEscape() => playerInput.Player.Escape.WasPressedThisFrame();
    public bool PressCheat() => playerInput.Player.Cheat.WasPressedThisFrame();

    public Vector2 GetPointerPos() => playerInput.Player.Point.ReadValue<Vector2>();
}
