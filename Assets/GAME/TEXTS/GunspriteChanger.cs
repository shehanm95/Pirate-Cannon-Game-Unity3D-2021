using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunspriteChanger : MonoBehaviour
{

    SpriteRenderer render;
    
    
        string model;
    // Start is called before the first frame update
    void Start()
    {
      
        render = GetComponent<SpriteRenderer> ( );
        spriteChangethisGun ( 35 );

        if (gameManager.savedGunModleNum == -1)
            {
            gameManager.savedGunModleNum = PlayerPrefs.GetInt ( "savedGunNumber",0 );
            }
       
        switch (gameManager.savedGunModleNum)
            {
            case 0:
                model = "0";
                break;
            case 1:
                model = "1";
                break;
            case 2:
                model = "2";
                break;
          
            }
       // model = "0";
        render.sprite = Resources.Load<Sprite> ( model + "5" );
        }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spriteChangethisGun ( float changerValue)
        {
        GameObject.Find ( "Main Camera" ).GetComponent<shotscript> ( ).SetTargetImagePosition ( );
        if(changerValue >65)
            {
            render.sprite = Resources.Load<Sprite> ( model + "1" );
          //  print ( "11" );
            }
        else if (changerValue > 60)
            {
            render.sprite = Resources.Load<Sprite> ( model + "2" );
          //  print ( "12" );
            }
        else if (changerValue > 50)
            {
            render.sprite = Resources.Load<Sprite> ( model + "3" );
          //  print ( "13" );
            }
        else if (changerValue > 40)
            {
            render.sprite = Resources.Load<Sprite> ( model + "4" );
          //  print ( "14" );
            }
        else if (changerValue > 50)
            {
            render.sprite = Resources.Load<Sprite> ( model + "5" );
          //  print ( "15" );
            }
        else if (changerValue > 30)
            {
            render.sprite = Resources.Load<Sprite> ( model + "6" );
          //  print ( "16" );
            }
        else if (changerValue > 20)
            {
            render.sprite = Resources.Load<Sprite> ( model + "7" );
         //   print ( "17" );
            }
        else if (changerValue > 10)
            {
            render.sprite = Resources.Load<Sprite> ( model + "8" );
         //   print ( "18" );
            }

        }
}
