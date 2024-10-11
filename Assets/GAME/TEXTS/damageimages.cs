using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class damageimages : MonoBehaviour
{
    public GameObject[] damages;
    public int damageNumber , AttackedShipsNum , shots;
    public AudioClip damageSound;
    AudioSource a;
    public TMP_Text  HullProtectedText , CoinText , AttackedShips , levelText;
    public GameObject summeryPanel , revivePanel;
    public static Color red , green , blue;
    public Color red1 , green1 , blue1;
    public static TMP_Text  LogText;
    public TMP_Text  LogText1;
    public summeryPanel summery;
    AudioClip bm1, bm2, bm3;
    public static AudioSource au;
    bool win = false;
    int HullUpgradedPersentage;
    
    private void Awake ( )
        {
        red = red1;
        green = green1;
        blue = blue1;
        LogText = LogText1;
      //  gameManager.setAccordingtoLvel ( );
        }
    // Start is called before the first frame update
    void Start()
        {
        gameManager.coinBalance = 0;
        if (gameManager.hullNumber == -1)
            {
            gameManager.hullNumber = PlayerPrefs.GetInt ( "hullNumber",1 );
            }
        switch (gameManager.hullNumber)
            {
            case 1:
                HullUpgradedPersentage = 100;
                break;
            case 2:
                HullUpgradedPersentage = 250;
                break;
            case 3:
                HullUpgradedPersentage = 500;
                break;
            }
       // print ( gameManager.hullNumber );

        levelText.text = "level : " + gameManager.curruntlevelnum.ToString ( );
        DesplayCoins ( );
        a = GetComponent<AudioSource> ( );
        HullProtectedText.text = HullUpgradedPersentage.ToString ( "00" ) + "/100";
        AttackedShips.text = AttackedShipsNum.ToString ( "00" ) + " / " + gameManager.howMuchShouldDieToWin.ToString ( );
        string[] attacked = new string[] {"today whether is celar....." , "today is a butiful day but...." , "I think something gioing to be wronng...." , "please be alart...." , "enemy ships are comming to you....", "hey..... ready your gun...." , "please come to the guns...." , "action...... ready to attack enemies...!!" };
        log ( attacked,blue );
        bm1 = Resources.Load<AudioClip> ( "bm1" );
        bm2 = Resources.Load<AudioClip> ( "bm2" );
        bm3 = Resources.Load<AudioClip> ( "bm3" );
        au = GetComponent<AudioSource> ( );
        InvokeRepeating ( "PlayBackgeoundMusic",0,20f );

       
        if(gameManager.curruntlevelnum == 3)
            {
            Time.timeScale = 0;
            revivePanel.SetActive ( true );
            }
        }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takleDamage (GameObject aobject )
        {
        if (HullUpgradedPersentage > 0 && gameManager.sammeryPanelActived ==false)
            {
            if (aobject != null && !gameManager.sammeryPanelActived)
                {
                if (gameManager.coinBalance > 5)
                    {
                    gameManager.coinBalance -= 5;
                    DesplayCoins ( );
                    }
                    string[] attacked = new string[] {"this guns are not enough for the war.....", "please spend some coins and buy new guns....", "you weare attacked by enemy ship....." , "you hit by enemy cannon...." , "enemies are attacking to you...." , "please......! dont miss them..." };
                    log ( attacked,red );
                shots++;
                HullUpgradedPersentage -= 20;
                HullProtectedText.text = HullUpgradedPersentage.ToString ( "00" ) + "/100";
                a.PlayOneShot ( damageSound );
                damageNumber = Random.Range ( 0,5 );
                Invoke ( "damageTrue",0.3f );
                Invoke ( "damagefalse",0.4f );
                Invoke ( "damageTrue",0.5f );
                Invoke ( "damagefalse",0.6f );
                Invoke ( "damageTrue",0.7f );
                Invoke ( "damagefalse",0.8f );
                Invoke ( "damagefalse",0.9f );
                }
            }
        if(HullUpgradedPersentage <= 20)
            {
            shots++;
            gameManager.sammeryPanelActived = true;
            summeryPanel.SetActive ( true );
            summery.displaySmmeryPanel (false );
            }
        }


    public void damageTrue ( )
        {
        damages[damageNumber].SetActive ( true );
        }

    public void damagefalse ( )
        {
        damages [ damageNumber ].gameObject.SetActive ( false );
        }


    public void DesplayCoins ( )
        {
        CoinText.text = gameManager.coinBalance.ToString("00000");
        }

    public void AttackedShipsnumDisplay ( )
        {

        //for now=============================================================================
            gameManager.howMuchShouldDieToWin = 3;



            if (AttackedShipsNum >= (gameManager.howMuchShouldDieToWin - 1))
            {
            AttackedShipsNum++;
            win = true;
            gameManager.sammeryPanelActived = true;
            summeryPanel.SetActive ( true );
            summery.displaySmmeryPanel ( true );
            }
        else
            {
            AttackedShipsNum++;
            AttackedShips.text = AttackedShipsNum.ToString ( "00" ) +" / " + gameManager.howMuchShouldDieToWin.ToString();
            }
        }


    public static void log(string[] log , Color mycolor )
        {
       // print ( "log called" );
        int i = Random.Range(0, log.Length);
        LogText.text = log[i];
        LogText.color = mycolor;
        }

    public void damageImagesAllfalse ( )
        {

        for (int i = 0 ; i < damages.Length ; i++)
            {
            damages [ i ].gameObject.SetActive ( false );
            }
        }


    public void PlayBackgeoundMusic ( )
        {
        au.PlayOneShot ( bm1 );
        au.PlayOneShot ( bm3 );
        Invoke ( "PlayBackgeoundMusic2",5f );
        }


    public void PlayBackgeoundMusic2 ( )
        {
        au.PlayOneShot ( bm2 );
        }

    public void stopBackgeoundMusic ( )
        {
        CancelInvoke ( "PlayBackgeoundMusic2" );
        CancelInvoke ( "PlayBackgeoundMusic" );
        au.Stop ( );
        }


    public void savelevel ( )
        {
        saveCoinsOnGoShop ( );
        if (win)
            {
            gameManager.savedlevelnum = PlayerPrefs.GetInt ( "savedlevel" );
            if (gameManager.savedlevelnum == 0)
                {
                gameManager.savedlevelnum = 1;
                }
            print ( $"savedlevel num = {gameManager.savedlevelnum}" );
            if (gameManager.savedlevelnum == gameManager.curruntlevelnum)
                {
                gameManager.savedlevelnum++;
                gameManager.curruntlevelnum++;
                PlayerPrefs.SetInt ( "savedlevel",gameManager.savedlevelnum );
                print ( $"saveed level = {gameManager.savedlevelnum} and currunt lvelenum = {gameManager.curruntlevelnum}" );
                SceneManager.LoadScene ( "shop" );
                
                }
            else
                {
                gameManager.curruntlevelnum++;
                SceneManager.LoadScene ( "shop" );
                }
            }
        else
            {
            SceneManager.LoadScene ( "shop" );
            }
        PlayerPrefs.SetInt ( "savedCannonBalance" , gameManager.coinBalance );
        PlayerPrefs.SetInt ( "savedCannonBalance",gameManager.cannonBalance );
        }

    public static void saveCoinsOnGoShop ( )
        {
        gameManager.savedCoinbalence = PlayerPrefs.GetInt ( "savedCoinBalance",0 );
        PlayerPrefs.SetInt ( "savedCoinBalance",gameManager.coinBalance + gameManager.savedCoinbalence );
        }


    public void shop ( )
        {
        Time.timeScale = 1;
        SceneManager.LoadScene ( "shop" );
        }

    }
