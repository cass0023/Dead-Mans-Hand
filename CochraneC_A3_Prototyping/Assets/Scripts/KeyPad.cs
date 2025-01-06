using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public GameManager gameManager;
    //public int[] keyPadInput;
    public int numInput;
    public GameObject incorrect;
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;
    public GameObject b5;
    public GameObject b6;
    public GameObject b7;
    public GameObject b8;
    public GameObject b9;
    public GameObject b0;
    public GameObject b_Enter;
    void Start(){
        numInput = 0;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.X)){
            gameObject.SetActive(false);
        }
    }
    public void B1(){
        gameManager.keypadInput[numInput] = 1;
        numInput++;
    }
    public void B2(){
        gameManager.keypadInput[numInput] = 2;
        numInput++;
    }
    public void B3(){
        gameManager.keypadInput[numInput] = 3;
        numInput++;
    }
    public void B4(){
        gameManager.keypadInput[numInput] = 4;
        numInput++;
    }
    public void B5(){
        gameManager.keypadInput[numInput] = 5;
        numInput++;
    }
    public void B6(){
        gameManager.keypadInput[numInput] = 6;
        numInput++;
    }
    public void B7(){
        gameManager.keypadInput[numInput] = 7;
        numInput++;
    }
    public void B8(){
        gameManager.keypadInput[numInput] = 8;
        numInput++;
    }
    public void B9(){
        gameManager.keypadInput[numInput] = 9;
        numInput++;
    }
    public void B0(){
        gameManager.keypadInput[numInput] = 0;
        numInput++;
    }
    public void B_Enter(){
        gameManager.checkPassword = true;
    }
    public void IncorrectGuess(){
        incorrect.SetActive(true);
        Invoke("SetFalse", 2f);
    }
    void SetFalse(){
        incorrect.SetActive(false);
    }
}
