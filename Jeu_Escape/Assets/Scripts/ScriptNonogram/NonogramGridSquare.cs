using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class NonogramGridSquare : Selectable, IPointerClickHandler, IPointerExitHandler
{
    public GameObject colorSquare;
    public GameObject numberTextUp;
    public GameObject numberTextLeft;
    private int thisSquareIndex = -1;
    private int thisSquareIsNumber = 0;
    private int colorNumber = 0;
    public void SetSquareIndex(int index)
    {
        thisSquareIndex = index;
    }
    public void SetSquareIsNumber(int value){
        thisSquareIsNumber = value;
    }
    void Update()
    {
    }

    public void ChangeColor()
    {
        if (colorSquare.GetComponent<Image>().color == Color.black){
            colorSquare.GetComponent<Image>().color = Color.white;
            this.colorNumber = 0;
        }
        else {
            colorSquare.GetComponent<Image>().color = Color.black;
            this.colorNumber = 1;
        }
    }

    public void SetColor(Color color, int setColorNumber)
    {
        colorSquare.GetComponent<Image>().color = color;
        this.colorNumber = setColorNumber;
    }

    public void SetNumberUp(string numbre)
    {
        numberTextUp.GetComponent<Text>().text = numbre;
    }
    public void SetNumberLeft(string numbre)
    {
        numberTextLeft.GetComponent<Text>().text = numbre;
    }
    public int GetColorNumber(){
        return this.colorNumber;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (thisSquareIsNumber == 0)
            ChangeColor();
    }

    public void OnSubmit(BaseEventData eventData)
    {
    }
}
