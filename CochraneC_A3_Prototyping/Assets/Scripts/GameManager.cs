using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject introPanel;
    public FirstPersonController playerController;
    public GameObject menuPopup;
    private KeyCode interactMenu = KeyCode.E;
    public int startingBottleCount;
    public int bottleCounter;
    public int difficultyLevel;
    public TextMeshProUGUI bottleUI;
    public bool triggerSound;
    public GameObject levelTwoEnemies;
    public GameObject levelThreeEnemies;
    public KeyPad keyPad;
    public GameObject keyPadUI;
    public int[] keyPadAnswer = {5, 3, 1, 0};
    public int[] keypadInput;
    public bool checkPassword;
    public GameObject door;
    public int maxlives = 10;
    public float livesCounter;

    void Start()
    {
        difficultyLevel = 1;
        bottleCounter = startingBottleCount;
        livesCounter = maxlives;
    }
    void Update()
    {
        if (introPanel != null && Input.GetKeyUp(KeyCode.X)){
            introPanel.SetActive(false);
        }

        bottleUI.text = "" + bottleCounter;
        if(Input.GetKeyUp(interactMenu) && menuPopup.activeInHierarchy){
            menuPopup.SetActive(false);
        }
        else if(Input.GetKeyUp(interactMenu)){
            menuPopup.SetActive(true);
        }
        if(keyPadUI.activeInHierarchy == true){
            playerController.playerCanMove = false;
            playerController.lockCursor = false;
        }
        if(keyPadUI.activeInHierarchy == false){
            playerController.playerCanMove = true;
            playerController.lockCursor = true;
        }
        if(checkPassword == true){
            keyPad.numInput = 0;
            if(keypadInput.Length == keyPadAnswer.Length){
                int correctNum = 0;
                for(int i = 0; i <= keyPadAnswer.Length; i++){
                    if(keyPadAnswer[i] == keypadInput[i])
                    {
                        correctNum++;
                        if(correctNum >= keyPadAnswer.Length){
                            correctNum = 0;
                            door.transform.Rotate(0,-90,0);
                            break;
                        }
                    }
                    if(keyPadAnswer[i] != keypadInput[i]){
                        keyPad.IncorrectGuess();
                        break;
                    }
                }
            }
            checkPassword = false;
        }
        if(livesCounter<=0){
            SceneManager.LoadScene("Lose");
        }
    }
    public void ActivateLevel2(){
        levelTwoEnemies.SetActive(true);
    }
    public void ActivateLevel3(){
        levelThreeEnemies.SetActive(true);
    }
    public void TakeDamage(){
        livesCounter -= 1;
    }
}
