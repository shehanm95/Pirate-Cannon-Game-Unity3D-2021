using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class revivewPanel: MonoBehaviour
    {
    public Text thankyou;
    public GameObject revivePanel;
    public GameObject DeactiveRevivePanalButton;
    // Start is called before the first frame update
    void Start ( )
        {
        StartCoroutine ( "buttonActivator");
        }

    // Update is called once per frame
    void Update ( )
        {

        }


    public void GoWebSite ( bool gowebsite )
        {

        StartCoroutine ( saythankyou ( gowebsite ) );


        }

    IEnumerator saythankyou ( bool gowebsite )
        {
        yield return new WaitForSecondsRealtime ( 1f );
        thankyou.text = "thank you for the revivew....";
        yield return new WaitForSecondsRealtime ( 2f );
        if (gowebsite)
            {

            //link to the playStore;
            Application.OpenURL ( "market://details?id=com.easternpearl.piratecannon" );

            Time.timeScale = 1;
            }
        else
            {
            Time.timeScale = 1;
            }

        yield return new WaitForSecondsRealtime ( 0.5f );
        revivePanel.SetActive ( false );

        }


    public void deActiverevivepanalButton (){
        Time.timeScale = 1;
        revivePanel.SetActive ( false );
        }

    IEnumerator buttonActivator ( )
        {
        yield return new WaitForSecondsRealtime ( 14f );
        if (DeactiveRevivePanalButton != null)
            {
            
            DeactiveRevivePanalButton.SetActive ( true );
            }
        }



    
}
