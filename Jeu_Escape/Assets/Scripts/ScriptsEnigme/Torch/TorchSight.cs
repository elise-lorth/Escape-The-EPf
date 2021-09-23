using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSight : MonoBehaviour
{
    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; //pour ne pas avoir le curseur de la souris, a enlever pour le tactile
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(mousePos.x, mousePos.y, 0f);
    }
}
