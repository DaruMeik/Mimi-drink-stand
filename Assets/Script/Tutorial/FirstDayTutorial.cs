using UnityEngine;

public class FirstDayTutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorial;
    [SerializeField] private GameObject CustomerQueue;
    public int currentPage;
    private float startTime = 0;
    private bool gameStart = false;
    private void OnEnable()
    {
        currentPage = 0;
        foreach(GameObject go in tutorial)
            go.SetActive(false);
        startTime = Time.time;
        gameStart = false;
    }
    private void Update()
    {
        if(!gameStart && Time.time - startTime > 0.01)
        {
            gameStart = true;
            tutorial[currentPage].SetActive(true);
        }
    }
    public void NextPage()
    {
        tutorial[currentPage].SetActive(false);
        currentPage++;
        tutorial[currentPage].SetActive(true);
    }
    public void EndTutorial()
    {
        tutorial[currentPage].SetActive(false);
        CustomerQueue.SetActive(true);
        gameObject.SetActive(false);
    }
}
