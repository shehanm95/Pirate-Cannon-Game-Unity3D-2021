using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotlight : MonoBehaviour
{
    public int wastedShots;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void callShot ( )
        {
        Invoke ( "shotfalse",0.2f );
        }

   void shotfalse ( )
        {
        gameObject.SetActive ( false );
        }
    }
