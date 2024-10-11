using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class gameManager: MonoBehaviour
    {
    public static int coinBalance,cannonBalance , weponUpgradedNum , level , cannonballprice = 10 , savedlevelnum , curruntlevelnum  , attackpersentage , howMuchShouldDieToWin ;
    public static float shipSpawnRate, shipSpeed;
    public static int savedCoinbalence, savedGunModleNum  = -1, savedcannonbalance , hullNumber = -1 ;//savedupgradedhullPersentage
    public static AudioClip bm1, bm2, bm3;
   
    public static bool sammeryPanelActived = false;


    private void Awake ( )
        {
       
       // hullNumber = 20;
        setAccordingtoLvel ( );
        }
    // Start is called before the first frame update
    void Start ( )
        {
        //PlayerPrefs.DeleteAll ( );
        cannonBalance = PlayerPrefs.GetInt ( "savedCannonBalance",300 );

        }

    // Update is called once per frame
    void Update ( )
        {

        }

    public static void pausegame ( )
        {
        sammeryPanelActived = true;
        Time.timeScale = 0;
        }

    public void Resumegame ( )
        {
        sammeryPanelActived = false;
        Time.timeScale = 1;
        }

    public void ExitGame ( )
        {
        Application.Quit ( );
        }

    public void Restart ( )
        {
        
        coinBalance = 0;
        sammeryPanelActived = false;
        Resumegame ( );
        SceneManager.LoadScene ( "level" );
        }

    public void goToMap ( )
        {
        SceneManager.LoadScene ( "levels" );
        }
    public void goLevels ( )
        {
        print ( "presed" );
        Resumegame ( );
        sammeryPanelActived = false;
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        int lnumber = int.Parse(buttonName);
        curruntlevelnum = lnumber;
        print ( gameManager.curruntlevelnum );
        SceneManager.LoadScene ( "level" );
        }



    public void tournemnets ( )
        {
        Resumegame ( );
        SceneManager.LoadScene ( "tournemnets" );
        }

    

   



    public static void setAccordingtoLvel ( )
        {
        switch (curruntlevelnum)
            {
            case 0:
                curruntlevelnum = savedlevelnum;
                break;
            case 1:
                
                shipSpawnRate =8;
                attackpersentage = 40;
                howMuchShouldDieToWin = 20;
                shipSpeed = 80;
                print ( shipSpeed );
                break;

            case 2:
               
                shipSpawnRate = 6;
                attackpersentage = 60;
                howMuchShouldDieToWin = 25;
                shipSpeed = 105;
                print ( shipSpeed );
                break;

            case 3:
               
                shipSpawnRate = 7;
                attackpersentage = 65;
                howMuchShouldDieToWin = 25;
                shipSpeed = 110;
                print ( shipSpeed );
                break;

            case 4:
               
                shipSpawnRate = 7;
                attackpersentage = 70;
                howMuchShouldDieToWin = 25;
                shipSpeed = 115;
                print ( shipSpeed );
                break;

            case 5:
              
                shipSpawnRate = 6f;
                attackpersentage = 75;
                howMuchShouldDieToWin = 30;
                shipSpeed = 115;
                print ( shipSpeed );
                break;

            case 6:
               
                shipSpawnRate = 6;
                attackpersentage = 85;
                howMuchShouldDieToWin = 30;
                shipSpeed = 120;
                break;

            case 7:

                shipSpawnRate = 6;
                attackpersentage = 90;
                howMuchShouldDieToWin = 30;
                shipSpeed = 130;
                break;

            case 8:

                shipSpawnRate = 6;
                attackpersentage = 95;
                howMuchShouldDieToWin = 40;
                shipSpeed = 130;
                break;
            case 9:

                shipSpawnRate = 5;
                attackpersentage = 95;
                howMuchShouldDieToWin = 40;
                shipSpeed = 130;
                break;

            case 10:

                shipSpawnRate = 5;
                attackpersentage = 100;
                howMuchShouldDieToWin = 50;
                shipSpeed = 130;
                break;

            case 11:

                shipSpawnRate = 4;
                attackpersentage = 100;
                howMuchShouldDieToWin = 50;
                shipSpeed = 130;
                break;
            case 12:

                shipSpawnRate = 4;
                attackpersentage = 100;
                howMuchShouldDieToWin = 50;
                shipSpeed = 135;
                break;

            case 13:

                shipSpawnRate = 4;
                attackpersentage = 100;
                howMuchShouldDieToWin = 50;
                shipSpeed = 140;
                break;
            case 14:

                shipSpawnRate = 4;
                attackpersentage = 100;
                howMuchShouldDieToWin = 50;
                shipSpeed = 145;
                break;

            case 15:

                shipSpawnRate = 4;
                attackpersentage = 100;
                howMuchShouldDieToWin = 50;
                shipSpeed = 150;
                break;

            case 16:

                shipSpawnRate = 4;
                attackpersentage = 100;
                howMuchShouldDieToWin = 50;
                shipSpeed = 150;
                break;

            case 17:

                shipSpawnRate = 4;
                attackpersentage = 100;
                howMuchShouldDieToWin = 50;
                shipSpeed = 155;
                break;

            case 18:

                shipSpawnRate = 3;
                attackpersentage = 100;
                howMuchShouldDieToWin = 50;
                shipSpeed = 130;
                break;

            case 19:

                shipSpawnRate = 3;
                attackpersentage = 100;
                howMuchShouldDieToWin = 50;
                shipSpeed = 135;
                break;

            case 20:

                shipSpawnRate = 3;
                attackpersentage = 100;
                howMuchShouldDieToWin = 50;
                shipSpeed = 140;
                break;
            case 21:

                shipSpawnRate = 3;
                attackpersentage = 100;
                howMuchShouldDieToWin = 50;
                shipSpeed = 145;
                break;

            case 22:

                shipSpawnRate = 3;
                attackpersentage = 100;
                howMuchShouldDieToWin = 50;
                shipSpeed = 150;
                break;

            case 23:

                shipSpawnRate = 4;
                attackpersentage = 100;
                howMuchShouldDieToWin = 50;
                shipSpeed = 155;
                break;

            case 24:

                shipSpawnRate = 4;
                attackpersentage = 100;
                howMuchShouldDieToWin =70;
                shipSpeed = 165;
                break;

            case 25:

                shipSpawnRate = 3;
                attackpersentage = 100;
                howMuchShouldDieToWin = 100;
                shipSpeed = 170;
                break;

            }
        }

   
    }
