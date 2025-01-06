using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject activeSlot;
    void Start(){

    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Bottle"){
            gameManager.triggerSound = true;
            transform.GetChild(0).gameObject.SetActive(true);
            Invoke("SetFalse", 5.0f);
        }
    }
    void SetFalse(){
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
