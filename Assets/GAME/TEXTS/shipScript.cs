using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipScript : MonoBehaviour
{
    public float DestroyTime;
    int move , randnum;
    bool canfire = false;
   // public SpriteRenderer ship;
    SpriteRenderer render;
    public GameObject shipobj;
    public GameObject fireLight;
   
    
    // Start is called before the first frame update
    void Start()
    {

        render = shipobj.GetComponent<SpriteRenderer> ( );
        int num = Random.Range(1,4);
        render.sprite = Resources.Load<Sprite> ( $"ps ({num})" );
        Destroy ( gameObject,DestroyTime );
        if(transform.position.x > 0)
            {
            move = -1;
            }
        else
            {
            move = 1;
            transform.localRotation = Quaternion.Euler ( 0,180,0 );
            }
         randnum = Random.Range ( 1,100 );
       // print ( randnum );
    }

    // Update is called once per frame

    private void FixedUpdate ( )
        {
        if (!gameManager.sammeryPanelActived)
            {
            GetComponent<Rigidbody2D> ( ).velocity = new Vector2 ( gameManager.shipSpeed * Time.deltaTime * move,0 );
            }
        else
            {
            Destroy ( gameObject );
            }
        }
    void Update()
    {
        if (!canfire && randnum >(100 - gameManager.attackpersentage))
            {
                if(move == -1)
                {
                    if(transform.position.x < 0)
                    {
                    
                    canfire = true;
                    attack ( );

                    }
                }
            if (move == 1)
                {
                if (transform.position.x > 0)
                    {
                    canfire = true;
                    attack ( );
                    }
                }
            }
        }

    private void OnCollisionEnter2D ( Collision2D collision )
        {
        
        if(collision.gameObject.tag == "shot")
            {
            GetComponent<Animator> ( ).Play("ESsunk");
            GetComponent<PolygonCollider2D> ( ).enabled =  false;
            gameManager.coinBalance += 15;
            GameObject.Find ( "Main Camera" ).GetComponent<damageimages> ( ).DesplayCoins ( ); 
            Destroy ( gameObject,.5f );
            GameObject.Find ( "Main Camera" ).GetComponent<damageimages> ( ).AttackedShipsnumDisplay ( );
            string[] logs = new string[] { "good work...." , "good shot.... nice.....", "you are very good" , "enemy is sinking" , "keep it up........", "good.... we are almost there...." ,"grate work......." };
            damageimages.log ( logs,damageimages.green );
            }
        }


    public void attack ( )
        {
        int damageafter = Random.Range(2,15);
        Invoke ( "doDamage",damageafter );
       // print ( "attacked" + damageafter);
        }


    void doDamage ( )
        {
          
            GameObject.Find ( "Main Camera" ).GetComponent<damageimages> ( ).takleDamage (this.gameObject );
        StartCoroutine ( fire ( ) );
        }


    IEnumerator fire ( )
        {
        fireLight.SetActive ( true );
        yield return new WaitForSeconds ( 1f );
        fireLight.SetActive ( false);
        }
    


    }
