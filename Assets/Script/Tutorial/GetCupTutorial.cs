using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCupTutorial : MonoBehaviour
{
    [SerializeField] private FirstDayTutorial firstDayTutorial;
    [SerializeField] private Player player;
    private void Update()
    {
        if (firstDayTutorial.currentPage != 2)
            return;
        if (player.GetState() == player.cupState)
        {
            firstDayTutorial.NextPage();
            gameObject.SetActive(false);
        }
    }
}
