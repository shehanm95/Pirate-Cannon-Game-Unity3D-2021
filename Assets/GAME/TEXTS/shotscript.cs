using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class shotscript: MonoBehaviour
    {
    public GameObject CannonShot , Gun1 , Gun2, Gun3 , ring1 , ring2 , ring3;
    public GameObject CannonShot2,CannonShot3;
    public GameObject GunSprite1, GunSprite2, GunSprite3;
    public Slider changer;
    float Zvalue,YValue, Xvalue , lasetValue1,lasetValue2,lasetValue3 , nextfire;
    public int GunNum , cannonShots;
    public TMP_Text CannonText;
    AudioSource au;
    AudioClip shotSound;
    Sprite deck;
    public SpriteRenderer deckSprite;

    [Header ("===MAN CONTROLS====")]

    public Transform gunPoint1;
    public Transform gunPoint2L;
    public Transform  gunPoint2R, firstSpawnPoint1 ,firstSpawnPoint2 ;
    public Transform gunPoint3;
    public GameObject man;
    public float ManSpeed;
    Transform target;
    public GameObject player;
    Animator ap;
    bool shoot = false;
    public GameObject targetImage;
    AudioClip wchanger;
   

    string curruntState;
    // Start is called before the first frame update
    void Start ( )
        {
        if (gameManager.hullNumber == -1)
            {
            gameManager.hullNumber = PlayerPrefs.GetInt ( "hullNumber",1 );
            }
        wchanger = Resources.Load<AudioClip> ( "changer" );
        if (gameManager.hullNumber == 1)
            {
            deck = Resources.Load<Sprite> ( "deck1");
            }

        else if (gameManager.hullNumber == 2)
            {
            deck = Resources.Load<Sprite> ( "deck2" );
            }
        else if (gameManager.hullNumber == 3)
            {
            deck = Resources.Load<Sprite> ( "deck3" );
            }

        deckSprite.sprite = deck;

        au = GetComponent<AudioSource> ( );
        shotSound = Resources.Load<AudioClip> ( "shot1" );
        if(gameManager.savedGunModleNum ==1)
            {
            CannonShot = CannonShot2;
            shotSound = Resources.Load<AudioClip> ( "shot2" );
            }
        else if (gameManager.savedGunModleNum == 2)
            {
            CannonShot = CannonShot3;
            shotSound = Resources.Load<AudioClip> ( "shot3" );
            }
        ap = player.GetComponent<Animator> ( );
        if (Random.Range ( 0,10 ) > 5) {
            man.transform.position = firstSpawnPoint1.position;

            }
        else
            {
            man.transform.position = firstSpawnPoint2.position;
            }
        ringactiveFalse ( );
        ring2.SetActive ( true );
        CannonText.text = gameManager.cannonBalance.ToString ( "000" );
        GunNum = 2;
        middleTargetSetter ( );
        if (gameManager.savedGunModleNum == 2)
            {
            targetImage.SetActive ( true );
            }
        else
            {
            targetImage.SetActive ( false );
            }

        }

    // Update is called once per frame
    void Update ( )
        {
        
        }
    private void FixedUpdate ( )
        {
        manControl ( );
        if (shoot)
            {

            Invoke ( "shootf",0.5f );
            }
        else if (man.transform.position != target.position)
            {
            playAnim ( "prun" );
            } else if (man.transform.position == target.position)
            {
            playAnim ( "pidle" );
            }

        }



    public void SetCannonShotPosition (){

        Zvalue = changer.value/100*12;
        YValue = changer.value / 100 * 11f;
        if(GunNum == 1)
            {
           
            Xvalue = Gun1.transform.position.x + (changer.value / 100 * (5.7f - 12.7f)) ;
            lasetValue1 = changer.value;
            }
        else if(GunNum == 2)
            {
            Xvalue = Gun2.transform.position.x;
            lasetValue2 = changer.value;
            }
        else if (GunNum == 3)
            {
            Xvalue = Gun3.transform.position.x + (changer.value / 100 * (12.63f - 5.5f));
            lasetValue3 = changer.value;
            }

        if (CannonShot != null)
            {
            CannonShot.transform.position = new Vector3 ( Xvalue,YValue + (-1.4f),Zvalue );
            //print ( CannonShot.transform.position );
            }

        }

    public void SetTargetImagePosition ( )
        {
        Zvalue = changer.value / 100 * 12;
        YValue = changer.value / 100 * 11f;
        if (GunNum == 1)
            {

            Xvalue = Gun1.transform.position.x + (changer.value / 100 * (5.7f - 12.7f));
            lasetValue1 = changer.value;
            }
        else if (GunNum == 2)
            {
            Xvalue = Gun2.transform.position.x;
            lasetValue2 = changer.value;
            }
        else if (GunNum == 3)
            {
            Xvalue = Gun3.transform.position.x + (changer.value / 100 * (12.63f - 5.5f));
            lasetValue3 = changer.value;
            }

        if (targetImage != null)
            {
                targetImage.transform.position = new Vector3 ( Xvalue,YValue + (-1.4f),Zvalue );
           
            //print ( CannonShot.transform.position );
            }

        }
    

    public void SetGunNum (int num )
        {
        au.PlayOneShot ( wchanger );
        GunNum = num;
        if(num == 1)
            {
            man.transform.localEulerAngles = new Vector3 ( 0,0 );
            target = gunPoint1;
            ringactiveFalse ( );
            ring1.SetActive ( true );
            changer.value = lasetValue1;
            }
        if (num == 2)
            {
            ringactiveFalse ( );
            ring2.SetActive ( true );
            changer.value = lasetValue2;
            middleTargetSetter ( );


            }
        if (num == 3)
            {
            man.transform.localEulerAngles = new Vector3 ( 0,180 );
            target = gunPoint3;
            ringactiveFalse ( );
            ring3.SetActive ( true );
            changer.value = lasetValue3;
            }
        }

    public void shot ( )
        {
        shoot = true;
        if (gameManager.cannonBalance > 0)
            {
            au.PlayOneShot ( shotSound );

            gameManager.cannonBalance--;
            CannonText.text = gameManager.cannonBalance.ToString ( "000" );
            CannonShot.SetActive ( true );
            SetCannonShotPosition ( );
            cannonShots++;

            
            if (Time.time > nextfire &&  1 > Mathf.Abs(target.position.x - man.transform.position.x))
                {
                nextfire = Time.time + .5f;
                playAnim ( "pattatck" );
                }
            else
                {
                return;
                }
            }
        else
            {
            // buy cannon animation=================================================================
            au.PlayOneShot ( wchanger );
            }
        }


    void ringactiveFalse ( )
        {
        ring1.SetActive ( false );
        ring2.SetActive ( false );
        ring3.SetActive ( false );
        GetComponent<damageimages> ( ).damageImagesAllfalse ( );

        }


    public void SpriteChange(float slidervalue )
        {

       // print ( slidervalue );
        if (GunNum == 1)
            {
            GunSprite1.GetComponent<GunspriteChanger> ( ).spriteChangethisGun ( slidervalue );
           
            }
        if (GunNum == 2)
            {
            GunSprite2.GetComponent<GunspriteChanger> ( ).spriteChangethisGun ( slidervalue );
            }
        if (GunNum == 3)
            {
            GunSprite3.GetComponent<GunspriteChanger> ( ).spriteChangethisGun ( slidervalue );
            }

        }


    void manControl ( )
        {
       
        man.transform.position = Vector2.MoveTowards ( man.transform.position,target.position, ManSpeed * Time.deltaTime );

        }

    void middleTargetSetter ( )
        {
        if (man.transform.position.x > 0)
            {
            man.transform.localEulerAngles = new Vector3 ( 0,0);
            target = gunPoint2R;
            }
        if (man.transform.position.x < 0)
            {
            target = gunPoint2L;
            man.transform.localEulerAngles =new Vector3(0,180 );
            }
        }


    void playAnim(string newState )
        {
        if (curruntState == newState) return;

        ap.Play ( newState );

        newState = curruntState;
        }

    void shootf ( )
        {
        shoot = false;
        }
  
    }
