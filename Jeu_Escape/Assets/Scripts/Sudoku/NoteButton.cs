using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NoteButton : Selectable, IPointerClickHandler
{
    public Sprite on_Image;
    public Sprite off_Image;
    private bool active_;
    // Start is called before the first frame update
    void Start()
    {
        active_ = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        active_ = !active_;

        if(active_)
            GetComponent<Image>().sprite = on_Image;
        else
            GetComponent<Image>().sprite = off_Image;

        GameEvents.OnNotesActiveMethod(active_);
    }
}
