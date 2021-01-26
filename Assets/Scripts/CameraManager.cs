using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private GameObject MainCamera;
    [SerializeField]
    private GameObject Camera2;

    [SerializeField] private GameObject Trigger;

   

    void OnTriggerEnter2D(Collider2D collision) // makes the projectiles deal damage
    {
        
            if (collision.tag == "Player")
            {
                MainCamera.SetActive(false);
                Camera2.SetActive(true);
                Trigger.SetActive(true);
                
            }
    
        
    }

}
