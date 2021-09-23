using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using UnityEngine.SceneManagement;


public class GameControl : MonoBehaviour
{
    [SerializeField]
    private GameObject selection, door, Panel, frame, Button, BUttonSafe, palier;
   // private Animator doorAnim;
  


    public static Color fingerColor;
    public static Color[] properColors;


    public static bool redIsRed, orangeIsOrange, yellowIsYellow, greenIsGreen, blueIsBlue, indigoIsIndigo, purpleIsPurple;


    private void Awake()
    {
        properColors = new Color[7];
    }


    void Start()
    {
        PaletteColor.ColorPicked += SetFingerColor;
        Glass.GlassColorIsSet += CheckResults;


        //victory.SetActive(false);
        BUttonSafe.SetActive(false);


        //doorAnim = door.GetComponent<Animator>();


        fingerColor = new Color(1f, 1f, 1f, 1f);
    }
    private void SetFingerColor(Color colorPicked, Vector3 colorPosition)
    {
        fingerColor = colorPicked;
        selection.transform.position = new Vector3(colorPosition.x, colorPosition.y, colorPosition.z);
    }
    private void CheckResults()
    {
        if (redIsRed && orangeIsOrange && yellowIsYellow && greenIsGreen && blueIsBlue && indigoIsIndigo && purpleIsPurple)
        {
            //doorAnim.Play("DoorDesappears");
            Panel.SetActive(false);
            frame.SetActive(false);
            Button.SetActive(false);
            BUttonSafe.SetActive(true);
            palier.SetActive(true);
        }
    }
    private void onDestroy()
    {
        PaletteColor.ColorPicked -= SetFingerColor;
        Glass.GlassColorIsSet -= CheckResults;
    }
}
