using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTeleport : MonoBehaviour
{
    public Transform teleport1;
    public Transform teleport2;
    public Transform teleport3;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            int ranNUm = Random.Range(1, 4);
            if(ranNUm == 1) 
            { 
                gameObject.transform.position = teleport1.position; 
            }
            if(ranNUm == 2)
            {
                gameObject.transform.position = teleport2.position;
            }
            if (ranNUm == 3)
            {
                gameObject.transform.position = teleport3.position;
            }
           
        }    
    }
}
