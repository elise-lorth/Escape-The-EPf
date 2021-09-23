using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleCoulissantPeluches : MonoBehaviour
{
    
    public NumberBoxPCP boxPrefab;

    public NumberBoxPCP[,] boxes = new NumberBoxPCP[3,3];

    public Sprite[] sprites;

    private Vector2 lastMove;

    [SerializeField]
    private GameObject pannelVictoireJeu;

    [SerializeField]
    private GameObject pannelVictoireEscape;

    public static bool victoire;

    public float lieuDeLancement;

    void Start()
    {
       lieuDeLancement = PlayerPrefs.GetFloat("LieuDeLancement", 1);

       victoire=false;

        Init();

        for(int i=0;i<999;i++)
        {
           Shuffle();
        }

    }

    void Update()
    {
        int winCount=0;
        int index=1;

        for (int y=2;y>=0;y--)
        {
            for (int x=0;x<3;x++)
            {
               if(boxes[x,y].index == index)
               {
                  winCount++;
               }
               index++;
            }
        }
        
        if(winCount == 9)
        {
           victoire=true;
           
           if (lieuDeLancement == 1){
               pannelVictoireJeu.SetActive(true);
            }

            else {
               pannelVictoireEscape.SetActive(true);
            }
            
        }
    }

    private void Init()
    {
        int n=0;

        for (int y=2;y>=0;y--)
        {
            for (int x=0;x<3;x++)
            {
               NumberBoxPCP box = Instantiate(boxPrefab, new Vector2(x,y), Quaternion.identity);
               box.Init(x,y,n+1,sprites[n], ClickToSwap);
               boxes[x,y] = box;
               n++;
            }
        }
    } 

    private void ClickToSwap(int x, int y)
    {
       int dx = getDx(x,y);
       int dy = getDy(x,y);
       Swap(x,y,dx,dy);

    }

    private void Swap(int x, int y, int dx, int dy)
    {

       var from = boxes[x,y];
       var target = boxes[x+dx,y+dy];

       // swap this 2 boxes
       boxes[x,y]=target;
       boxes[x+dx,y+dy]=from;

       // update pos 2 boxes
       from.UpdatePos(x+dx,y+dy);
       target.UpdatePos(x,y);

    }

    private int getDx(int x, int y) 
    {
       // is right empty
       if (x < 2 && boxes[x+1,y].IsEmpty())
       {
          return 1;
       }

       // is left empty
       if (x > 0 && boxes[x-1,y].IsEmpty())
       {
          return -1;
       }

       return 0;
    }

    private int getDy(int x, int y)
    {
        // is top empty
        if (y < 2 && boxes[x,y+1].IsEmpty())
       {
          return 1;
       }

       // is bottom empty
       if (y > 0 && boxes[x,y-1].IsEmpty())
       {
          return -1;
       }

       return 0;
    }

    private void Shuffle()
    {
       for (int i=0;i<3;i++)
       {
          for (int j=0;j<3;j++)
          {
             if (boxes[i,j].IsEmpty())
             {
                Vector2 pos = getValidMove(i,j);
                Swap(i,j,(int)pos.x,(int)pos.y);
             }
          }
       }
    }

    private Vector2 getValidMove(int x, int y)
    {
       Vector2 pos = new Vector2();

       do
       {
          int n = Random.Range(0,4);
          if (n==0)
          {
             pos = Vector2.left;
          }
          else if (n==1)
          {
             pos = Vector2.right;
          }
          else if (n==2)
          {
             pos = Vector2.up;
          }
          else
          {
             pos = Vector2.down;
          }
       } while (!(isValidRange(x+(int)pos.x) && isValidRange(y+(int)pos.y)) || isRepeatMove(pos));

       lastMove = pos;
       return pos;

    }

    private bool isValidRange(int n)
    {
       return n>= 0 && n<= 2;
    }

    private bool isRepeatMove(Vector2 pos)
    {
       return pos * -1 == lastMove;
    }

    public void ParametresOuvert()
    {
        for(int i=0;i<3;i++)
        {
           for (int j=0;j<3;j++) {
               boxes[i,j].GetComponent<SpriteRenderer>().sortingOrder = -1; 
           }
        }

        victoire = true;
    }

    public void ParametresFerme()
    {
        for(int i=0;i<3;i++)
        {
           for (int j=0;j<3;j++) {
               boxes[i,j].GetComponent<SpriteRenderer>().sortingOrder = 0; 
           }
        }

        victoire = false;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("puzzleCoulissantPeluches");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("MenuConnecte");
    }
    
}
