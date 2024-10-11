using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipSpawnerScript : MonoBehaviour
{
    public Transform[] spawnPosition;
    public GameObject Ship;
    public float firsttime;
    int preSpawn;
    // Start is called before the first frame update
    void Start()
    {   if (gameManager.shipSpawnRate !=0) {
            InvokeRepeating ( "spship",firsttime,gameManager.shipSpawnRate ); }
        else
            {
            InvokeRepeating ( "spship",0,3 );
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spship ( )
        {
        if (gameManager.sammeryPanelActived == false)
            {

            int spawnposnum = Random.Range ( 0,6 );

            if(spawnposnum == preSpawn)
                {
                while(spawnposnum == preSpawn)
                    {
                    spawnposnum = Random.Range ( 0,6 );
                    }
                }

            preSpawn = spawnposnum;
            Instantiate ( Ship,spawnPosition [ spawnposnum ].position,Quaternion.identity );

            if (Random.Range ( 1,11 ) > 6)
                {
                damageimages.LogText.color = damageimages.red;
                switch (spawnposnum)
                    {
                    case 0:
                        damageimages.LogText.text = "a enemy ship is cooming from near right side";
                        break;
                    case 1:
                        damageimages.LogText.text = "a enemy ship is cooming from middel right";
                        break;
                    case 2:
                        damageimages.LogText.text = "a enemy ship is cooming from far right side";
                        break;

                    case 3:
                        damageimages.LogText.text = "a enemy ship is cooming from near left side";
                        break;
                    case 4:
                        damageimages.LogText.text = "a enemy ship is cooming from middle left";
                        break;
                    case 5:
                        damageimages.LogText.text = "a enemy ship is cooming from far left side";
                        break;
                    }
                }
            }
        }
}
