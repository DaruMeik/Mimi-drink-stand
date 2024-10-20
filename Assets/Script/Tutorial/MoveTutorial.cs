using UnityEngine;

public class MoveTutorial : MonoBehaviour
{
    [SerializeField] private FirstDayTutorial firstDayTutorial;
    private void Update()
    {
        if (firstDayTutorial.currentPage != 1)
            return;
        Collider2D hit;
        hit = Physics2D.OverlapPoint(transform.position, LayerMask.GetMask("Player"));
        if(hit)
        {
            firstDayTutorial.NextPage();
            gameObject.SetActive(false);
        }
    }
}
