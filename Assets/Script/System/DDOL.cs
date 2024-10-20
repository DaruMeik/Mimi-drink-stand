using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    [SerializeField] private GameObject[] gObjs;
    private void OnEnable()
    {
        foreach(GameObject gObj in gObjs)
        {
            DontDestroyOnLoad(gObj);
        }
        SceneManager.LoadScene("Title");
    }
}
