using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public class BottleCollision : MonoBehaviour
{
    public GameObject soundSpot;
    // Start is called before the first frame update
    void Start()
    {
        soundSpot = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision){
        //play glass breaking sound
        var soundLoc = Instantiate(soundSpot, gameObject.transform.position, gameObject.transform.rotation);
        if(collision.gameObject.tag == "Machine"){
            Debug.Log("Collided with "+ collision.gameObject);
            Destroy(soundLoc, 5f);
        }
        else{
            Destroy(soundLoc, 1f);
        }
        Destroy(gameObject, 0.1f);
    }
}