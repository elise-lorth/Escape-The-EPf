using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClockHands : MonoBehaviour
{
    [SerializeField]
    private GameObject minuteHand, hourHand;

    public void RotateClockHandsRight() //Bouge les minutes et les heures en mm temps
    {
        minuteHand.transform.Rotate(0f, 0f, -6f);
        hourHand.transform.Rotate(0f, 0f, -0.5f);
    }

    public void RotateClockHandsLeft() //Bouge les minutes et les heures en mm temps
    {
        minuteHand.transform.Rotate(0f, 0f, 6f);
        hourHand.transform.Rotate(0f, 0f, 0.5f);
    }
   
}
