using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Enemy : MonoBehaviour
{
    //player variables
    private GameObject playerLocation;
    private FirstPersonController playerController;
    //sound and animation var
    private GameObject soundSpot;
    private Animator anim;
    //enemy move speed var
    private int speed = 6;
    //gm var
    private GameObject gm;
    private GameManager gameManager;
    void Start()
    {
        soundSpot = null;
        playerLocation = GameObject.Find("FirstPersonController");
        playerController = playerLocation.GetComponentInParent<FirstPersonController>();
        anim = GetComponent<Animator>();
        gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManager>();
    }
    void Update()
    {
        if (soundSpot == null){
            //looks for sound if no object
            soundSpot = GameObject.Find("soundSpot(Clone)");
            //stops enemy from moving when no sound
            StopMoving();
            if(playerController.isWalking == true && playerController.isCrouched == false){
                //if player is walking, follow player at 1/2 speed
                transform.LookAt(playerLocation.transform);
                var step = speed / 2 * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, playerLocation.transform.position, step);
            }
        }
        if(soundSpot != null){
            //moves enemy towards sound
            transform.LookAt(soundSpot.transform);
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,soundSpot.transform.position, step);
        }
        if(playerController.isSprinting == true && playerController.isWalking){
            //if player is sprinting, enemies follow player
            transform.LookAt(playerLocation.transform);
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, playerLocation.transform.position, step);            
        }
        if(playerController.isCrouched == true){
            StopMoving();
        }
    }
    private void StopMoving(){
        Vector3 currentPos = transform.position;
        transform.position = currentPos;
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
            anim.SetBool("Attack", true);
            anim.Play("Attack");
            gameManager.TakeDamage();
        }
    }
    public void LookAtPlayer(){
        transform.LookAt(playerLocation.transform);
    }
}
