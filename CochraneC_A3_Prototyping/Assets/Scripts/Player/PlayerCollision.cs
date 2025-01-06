using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerCollision : MonoBehaviour
{
    public GameManager gameManager;
    public FirstPersonController playerController;
    public KeyCode interact;
    public GameObject[] enemyInScene;
    public GameObject interactText;
    public GameObject keyPadUI;
    public Enemy enemy;
    public GameObject elevatorLevelTwo;
    public GameObject elevatorLevelOne;
    private bool canInteract;
    private bool elevatorInteract;
    private bool elevator1Interact;
    private float walkSpeed;
    void Start()
    {
        walkSpeed = playerController.walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        enemyInScene = GameObject.FindGameObjectsWithTag("Enemy");
        enemy = enemyInScene[0].GetComponent<Enemy>();
        if(Input.GetKeyDown(interact) && canInteract){
            ActivateKeyPad();
            canInteract = false;
        }
        else if(Input.GetKeyDown(interact)&&!canInteract){
            keyPadUI.SetActive(false);
        }
        if(Input.GetKeyDown(interact) && elevatorInteract){
            transform.position = elevatorLevelTwo.transform.position;
            transform.Rotate(0,180,0);
            gameManager.ActivateLevel3();
        }
        if(Input.GetKeyDown(interact) && elevator1Interact){
            transform.position = elevatorLevelOne.transform.position;
            transform.Rotate(0,180,0);
        }
    }
    private void OnTriggerEnter(Collider collider){
        //collectible bottle collision
        if(collider.gameObject.tag == "Collectible"){
            Destroy(collider.gameObject);
            gameManager.bottleCounter++;
        }
        //interactable keypad collision
        if(collider.gameObject.tag == "Interactable"){
            interactText.SetActive(true);
            canInteract = true;
        }
        //activates level 2 enemy
        if(collider.gameObject.name == "LVL1"){
            gameManager.ActivateLevel2();
        }
        //debris collision
        if(collider.gameObject.tag == "Debris"){
            enemy.LookAtPlayer();
            float tempWalk = playerController.walkSpeed / 2;
            playerController.walkSpeed = tempWalk;
        }
        //elevator
        if(collider.gameObject.tag == "Elevator"){
            interactText.SetActive(true);
            elevatorInteract = true;
        }
        if(collider.gameObject.tag == "Elevator1"){
            interactText.SetActive(true);
            elevator1Interact = true;
        }
        if(collider.gameObject.name == "WinCondition"){
            SceneManager.LoadScene("Win");
        }
    }
    private void OnTriggerExit(Collider collider){
        interactText.SetActive(false);
        elevatorInteract = false;
        elevator1Interact = false;
        playerController.walkSpeed = walkSpeed;
    }
    public void ActivateKeyPad(){
        keyPadUI.SetActive(true);
    }
}