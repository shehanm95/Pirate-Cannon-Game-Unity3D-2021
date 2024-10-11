using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainScript : MonoBehaviour {

    public int currentSavedNumber;
    public GameObject selector;
    string buttonName;
    // public AudioSource ClickSound;
    public GameObject GoLevelButton;
    public static string levelName;
    public string[] names;
    string description;
    public Text missionName , missionDescription;

    // Start is called before the first frame update
    void Start () {
        loadData ();
        savelevel ();
        setSilector ( currentSavedNumber );

    }

    // Update is called once per frame
    void Update () {

    }

    public void loadnextscene () {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
    }

    public void play () {
        SceneManager.LoadScene ("play");
    }

    public void exitscene () {
        SceneManager.LoadScene ("exit");
    }

    public void levels () {
        SceneManager.LoadScene ("levels");
    }

    public void loadButtonsLevel () {
        buttonName = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene ("level" + buttonName);
    }

  //  public void playClickSound () {
  //    //  ClickSound.Play ();
  //  }

    public void savelevel () {
        int y = SceneManager.GetActiveScene ().buildIndex;
        int curruntLevelNumber = y - 2;

        if (curruntLevelNumber > currentSavedNumber) {
            currentSavedNumber = curruntLevelNumber;
            print (currentSavedNumber);
            PlayerPrefs.SetInt ("savedlevel", currentSavedNumber);
        }
    }

   
    public void deleteData () {
        PlayerPrefs.DeleteAll ( );
        PlayerPrefs.SetInt ( "savedlevel" , 1 );
        }
    public void loadData () {
        currentSavedNumber = PlayerPrefs.GetInt ("savedlevel");
        print ( currentSavedNumber );

    }

    void setSilector ( int savedledvelnum)
        {
        if(savedledvelnum == 0)
            {
            savedledvelnum = 1;
            }
        GameObject button =GameObject.Find ( savedledvelnum.ToString ( ) );
        selector.transform.position = button.transform.position;
        }



    public void levelButton ( )
        {
           
            
            string buttonName = EventSystem.current.currentSelectedGameObject.name;
            int lnumber = int.Parse(buttonName);
            gameManager.curruntlevelnum = lnumber;
        GoLevelButton.SetActive ( true );
        setMissionNameandDescription ( lnumber );
        }


    public void goLevelButton ( )
        {
        Time.timeScale = 1;
        gameManager.sammeryPanelActived = false;
        SceneManager.LoadScene ( "level" );
        }


    void setMissionNameandDescription ( int lnum)
        
        {lnum = lnum - 1;
            missionName.text = names [ lnum ];
        switch (lnum +1)
            {
                case 1:
                description = "you jave to fight against navy pirate of the noth sea \n\n you can win this battle easily";
                break;

                case 2:
                    description = "face to the facr near to the coconut plantation";
                    break;

                case 3:
                    description = "Face to the brave Battles on the Brave islands, \n\nI think this is the time to upgrade your weppons, ";
                    break;

                case 4:
                    description = "Be Care Full..... \n\n Clever pirates are there.. they are yousing speed ships,";
                    break;

                case 5:
                    description = "you can earn more coins by hitting to them, \n\n use your wepons well, and try safe our ship....";
                    break;

                case 6:
                    description = "Now the local pirates are against to you.... , \n\n Fight well and kill them all....";
                    break;

                case 7:
                    description = "in this evening you have to sale though the mountains sea area.... , \n\n they have very speed ships....";
                    break;

                case 8:
                    description = "some diomends are there....\n\n fight with them and get the all dioments from them , \n\n they have very speed ships....";
                    break;

                case 9:
                    description = "there are more pirate ships in the pasific Ocean...., \n\nImmediately you have to go fight with them....";
                    break;

                case 10:
                    description = "this small island is situated in near to the Sri Lanka go there and defeat all the pirates...., \n\nGodbleess you, \n\n fight with them....";
                    break;

                case 11:
                    description = "there is zombie pirate ships in the zombie sea, you have to defeate them and get their all the coins";
                    break;
                case 12:
                    description = "after the attaking to the Kites Island now we are nearing to the sothern sea of the main islans, 200 nortcal miles far from the sothern Beach ";
                    break;

                case 13:
                    description = "after the attaking to the Kites Island now we are nearing to the sothern sea of the main islans, 200 nortcal miles far from the sothern Beach ";
                    break;

                case 14:
                    description = "after the attaking to the Kites Island now we are nearing to the sothern sea of the main islans, 200 nortcal miles far from the sothern Beach ";
                    break;

                case 15:
                    description = "after the attaking to the Kites Island now we are nearing to the sothern sea of the main islans, 200 nortcal miles far from the sothern Beach ";
                    break;

                case 16:
                    description = "after the attaking to the Kites Island now we are nearing to the sothern sea of the main islans, 200 nortcal miles far from the sothern Beach ";
                    break;

                case 17:
                    description = "after the attaking to the Kites Island now we are nearing to the sothern sea of the main islans, 200 nortcal miles far from the sothern Beach ";
                    break;

                case 18:
                    description = "after the attaking to the Kites Island now we are nearing to the sothern sea of the main islans, 200 nortcal miles far from the sothern Beach ";
                    break;

                case 19:
                    description = "after the attaking to the Kites Island now we are nearing to the sothern sea of the main islans, 200 nortcal miles far from the sothern Beach ";
                    break;

                case 20:
                    description = "after the attaking to the Kites Island now we are nearing to the sothern sea of the main islans, 200 nortcal miles far from the sothern Beach ";
                    break;

                case 21:
                    description = "after the attaking to the Kites Island now we are nearing to the sothern sea of the main islans, 200 nortcal miles far from the sothern Beach ";
                    break;
                case 22:
                    description = "after the attaking to the Kites Island now we are nearing to the sothern sea of the main islans, 200 nortcal miles far from the sothern Beach ";
                    break;
                case 23:
                    description = "after the attaking to the Kites Island now we are nearing to the sothern sea of the main islans, 200 nortcal miles far from the sothern Beach ";
                    break;
                case 24:
                    description = "after the attaking to the Kites Island now we are nearing to the sothern sea of the main islans, 200 nortcal miles far from the sothern Beach ";
                    break;
                case 25:
                    description = "after the attaking to the Kites Island now we are nearing to the sothern sea of the main islans, 200 nortcal miles far from the sothern Beach ";
                    break;


                }
            gameManager.setAccordingtoLvel ( );
            string mydescription = description + $"\n \nthere are {gameManager.howMuchShouldDieToWin} enemy pirate ships against you.........";
            missionDescription.text = mydescription;


        }


}