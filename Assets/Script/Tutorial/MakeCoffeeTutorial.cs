using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCoffeeTutorial : MonoBehaviour
{
    [SerializeField] private FirstDayTutorial firstDayTutorial;
    [SerializeField] private Player player;
    private void Update()
    {
        if (firstDayTutorial.currentPage != 3)
            return;
        if (player.currentItem == "Hot Cup")
        {
            firstDayTutorial.NextPage();
            gameObject.SetActive(false);
        }
    }
}
