using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector2 mousePosition;
    private float offsetX, offsetY;

    public static bool mouseButtonReleased; //Peut etre à modifider pour le jeu
    private void OnMouseDown()
    {
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        string thisGameobjectName;
        string collisionGameobjectName;

        thisGameobjectName = gameObject.name.Substring(0, name.IndexOf("_"));
        collisionGameobjectName = collision.gameObject.name.Substring(0, name.IndexOf("_"));

        if (mouseButtonReleased && thisGameobjectName == "NAME" && thisGameobjectName== collisionGameobjectName)
        {
            Instantiate(Resources.Load("NAME_NewObj"), transform.position, Quaternion.identity); //ressources.load, car images se trouve dans le dossier ressouces dans asset pas besoin de les mettre dans la scene
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (mouseButtonReleased && thisGameobjectName == "NAME" && thisGameobjectName == collisionGameobjectName)
        {
            Instantiate(Resources.Load("NAME_NewObj"), transform.position, Quaternion.identity);
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
 
}
