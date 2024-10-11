using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shopPanelScriot : MonoBehaviour
{
    public int coinBalenceShop, cannonBalance , gunNumber, hullnumber;
    public Text coinBaalanceTxt , cannonBalanceTxt , logText  , gunLog , HullLog;
    AudioSource au;
    AudioClip coincopleate;
    // Start is called before the first frame update
    void Start()
    {
        au = GetComponent<AudioSource> ( );
        coincopleate = Resources.Load<AudioClip> ( "coincopleate" );
        getCoinBalace ( );
        displayCoinBalanceAndCannonBalance ( );
        clearLog ( );
       // coinBalenceShop = 5000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void getCoinBalace ( )
        {
        coinBalenceShop =  PlayerPrefs.GetInt ( "savedCoinBalance",0 );
        cannonBalance = gameManager.cannonBalance;
       gunNumber =PlayerPrefs.GetInt ( "savedGunNumber",1 );
        hullnumber = PlayerPrefs.GetInt ( "savedHullNumber",1 );
        }

    public void displayCoinBalanceAndCannonBalance ( )
        {
        coinBaalanceTxt.text = "Total Coin Balance is : " + coinBalenceShop.ToString ( "000" );
        if(cannonBalanceTxt != null)
            {
            cannonBalanceTxt.text = ": " + gameManager.cannonBalance.ToString ( "000" );
            }
        }

    public void buyCannonsandSetValues (int requestingCannonValue )
        {
        if (coinBalenceShop >= requestingCannonValue *10)
            {
            gameManager.cannonBalance += requestingCannonValue;
            coinBalenceShop -= requestingCannonValue * 10;
            displayCoinBalanceAndCannonBalance ( );
            PlayerPrefs.SetInt ( "savedCoinBalance",coinBalenceShop );
            PlayerPrefs.SetInt ( "savedCannonBalance",gameManager.cannonBalance );
            logText.text = $"you have sucssesfully bought {requestingCannonValue.ToString("00")} Cannon Balls;";
            playCoinSound ( );
            }
        else
            {
            logText.text = "you dont have enough Coin Balance to do this action";
            }


        }

    public void clearLog ( )
        {
        logText.text = "";
        }


    public void changeGunModelNum ( int gunNum )
        {
        gameManager.savedGunModleNum = PlayerPrefs.GetInt ( "savedGunNumber",0 );
        if (gameManager.savedGunModleNum < gunNum) { 
        int consideringCoinAmount;
        switch (gunNum)
            {
                case 1:
                consideringCoinAmount = 1000;
                break;
            case 2:
                consideringCoinAmount = 2000;
                break;

            case 3:
                consideringCoinAmount = 4000;
                break;

            default:
                consideringCoinAmount = 0;
                break;
            }

        if (coinBalenceShop > consideringCoinAmount && gunNum != 0)
            {
                coinBalenceShop -= consideringCoinAmount;
                displayCoinBalanceAndCannonBalance ( );
                PlayerPrefs.SetInt ( "savedCoinBalance",coinBalenceShop );
                PlayerPrefs.SetInt ( "savedGunNumber",gunNum);
                logText.text = "you sucssesfully bought the gun. \nNow you are using this";
                playCoinSound ( );
                }
            else
                {
                logText.text = "you dont have enough Coin Balance to do this action";
                }

            }
        else
            {
            if (gunNum == 0) { logText.text = "Now you are using this gun; \nthis gun is free for you..."; }
            else
                {
                logText.text = "you have Already sucssesfully bought the gun \nNow you are using this";
                }
            gameManager.savedGunModleNum = gunNum;
            }

        if(gunLog != null)
            {
            if(gunNum == 0)
            gunLog.text = Orgin( "basic Pirate Cannon Gun", "France" , 1867 , "Gun", 3000 );
            if (gunNum == 1)
                gunLog.text = Orgin ( "Standard Pirate Cannon Gun","German",1890,"Gun",4200 );
            if (gunNum == 2)
                gunLog.text = Orgin ( "Premium Pirate Cannon Gun","United Kingdom",1900,"Gun",6500 );
            }
        }

    public void changeHullModelNum ( int HullNum )
        {
        gameManager.hullNumber = PlayerPrefs.GetInt ( "hullNumber",1 );
        if (gameManager.hullNumber < HullNum)
            {
            int consideringCoinAmount;
            switch (HullNum)
                {
                case 1:
                    consideringCoinAmount = 1000;
                    break;
                case 2:
                    consideringCoinAmount = 2000;
                    break;

                case 3:
                    consideringCoinAmount = 4000;
                    break;

                default:
                    consideringCoinAmount = 0;
                    break;
                }

            if (coinBalenceShop > consideringCoinAmount && HullNum != 0)
                {
                coinBalenceShop -= consideringCoinAmount;
                displayCoinBalanceAndCannonBalance ( );
                PlayerPrefs.SetInt ( "hullNumber",coinBalenceShop );
                PlayerPrefs.SetInt ( "hullNumber",HullNum );
                gameManager.hullNumber = HullNum;
                logText.text = "you sucssesfully bought the Hull. \nNow you are using this";
                playCoinSound ( );
                }
            else
                {
                logText.text = "you dont have enough Coin Balance to do this action";
                }

            }
        else
            {
            if (HullNum == 1) { logText.text = "Now you are using this Hull; \nthis hull is free for you..."; }
            else
                {
                logText.text = "you have Already sucssesfully bought the Hull \nNow you are using this";
                }
            gameManager.hullNumber = HullNum;
            }

        if (HullLog != null)
            {
            if (HullNum == 1)
                HullLog.text = Orgin ( "Old Wooden Ship","France",1820,"Hull",35000 );
            if (HullNum == 2)
                HullLog.text = Orgin ( "Metal Protected Hull","German",1850,"Hull",48000 );
            if (HullNum == 3)
                HullLog.text = Orgin ( "Premium Black Hull","United Kingdom",1880,"Hull",72000 );
            }
        }


    public string Orgin ( string name,string country,int year,string hullOrGun,int power )
        {
        return $" This {hullOrGun} Is {name}; \n\n Made in {country}; \n In {year}; \n\n This {hullOrGun} Has {power} j Power.";
     
        }



    public void addCoins ( )
        {
        coinBalenceShop += 500;
        displayCoinBalanceAndCannonBalance ( );
        playCoinSound ( );
        }


    void playCoinSound ( )
        {
        au.PlayOneShot ( coincopleate );
        }

    }

