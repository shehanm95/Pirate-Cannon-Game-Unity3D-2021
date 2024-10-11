using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class summeryPanel : MonoBehaviour
{
    public TMP_Text summereyState;
    public Text SunkPiretShips , Hits, Wasts, EarenedCoins , TotalCoinYouHaveNow;
    public Color red, blue;
    public damageimages damaged;
    public shotscript shots;
    int displayedCoinBalance;
    AudioClip CoinSound , coincopleate , defeated,winsound;
    AudioSource au;
    public GameObject summerrysSummeryPanel , buttonPanel , DoubleYourEarnedCoinsButton;
    public gameManager gamemanager;
    float waitTime = 0.9f;
    
    // Start is called before the first frame update
    void Start()
    {
        CoinSound = Resources.Load<AudioClip> ( "CoinSound" );
        coincopleate = Resources.Load<AudioClip> ( "coincopleate" );
        defeated = Resources.Load<AudioClip> ( "defeated" );
        winsound = Resources.Load<AudioClip> ( "winsound" );
        au = GetComponent<AudioSource> ( );
       // au.PlayOneShot ( CoinSound );
        }

    // Update is called once per frame
    void Update()
    {

    }

    public void displaySmmeryPanel (bool win )
        {
        gamemanager.GetComponent<damageimages> ( ).stopBackgeoundMusic ( );
        string State;
        if (win)
            {
            State = "You are win";
            summereyState.color = blue;
            }
        else
            {
            State = "You are defeated";
            summereyState.color = red;

            }

        summereyState.text = State;
       
        SunkPiretShips.text =": "+ damaged.AttackedShipsNum.ToString ("00" );
        Hits.text = ": " + damaged.shots.ToString ("00");
        Wasts.text = ": " + shots.cannonShots.ToString ( "00" );
       // print ( displayCoins );
      //  print ( displayCoins );
        StartCoroutine ( myfunc (win ) );
        }


 


     IEnumerator myfunc (bool win )
        {
       // gameManager.coinBalance = 375;
        if (gameManager.coinBalance == 0)
            {
            EarenedCoins.text = displayedCoinBalance.ToString ( "000" );
            }
        else
            {
            while (gameManager.coinBalance != displayedCoinBalance)
                {

            yield return new WaitForSecondsRealtime (waitTime);
            waitTime = 0.06f;
            displayedCoinBalance += 5;
            EarenedCoins.text = displayedCoinBalance.ToString ("000" );
            au.PlayOneShot ( CoinSound );
                }
            }
        yield return new WaitForSecondsRealtime ( 0.5f );
        au.PlayOneShot ( coincopleate );
        int savedCoins =  PlayerPrefs.GetInt("savedCoinBalance" , 0);
        int TottleCoinsYouhavenowa = savedCoins + gameManager.coinBalance;
        TotalCoinYouHaveNow.text = ": "+ TottleCoinsYouhavenowa.ToString ( "000" ); 
        yield return new WaitForSecondsRealtime ( 0.2f );
        DoubleYourEarnedCoinsButton.SetActive ( true );
        if (win)
            {
            au.PlayOneShot ( winsound );
            }
        else
            {

            au.PlayOneShot ( defeated );

            }
        summerrysSummeryPanel.SetActive ( true );
        yield return new WaitForSecondsRealtime ( 4f );
        buttonPanel.SetActive ( true );
        StopCoroutine ( " myfunc" );
        }


    public void DoubleEarnedCoins ( )
        {
        // if ad Finnished;
        gameManager.coinBalance = displayedCoinBalance * 2;
        DoubleYourEarnedCoinsButton.SetActive ( false );
        StartCoroutine ( doubling ( ) );
        int savedCoins =  PlayerPrefs.GetInt("savedCoinBalance" , 0);
        int TottleCoinsYouhavenowa = savedCoins + gameManager.coinBalance;
        TotalCoinYouHaveNow.text = ": " + TottleCoinsYouhavenowa.ToString ( "000" );
       
        }



    IEnumerator doubling ( )
        {
        while (gameManager.coinBalance != displayedCoinBalance)
            {

            yield return new WaitForSecondsRealtime ( waitTime );
            displayedCoinBalance += 5;
            EarenedCoins.text = displayedCoinBalance.ToString ( "000" );
            au.PlayOneShot ( CoinSound );
            }
        yield return new WaitForSecondsRealtime (0.9f);
        au.PlayOneShot ( coincopleate );
        }

}
