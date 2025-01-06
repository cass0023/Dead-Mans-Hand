using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBottle : MonoBehaviour
{
    public GameManager gameManager;
    public Transform bottleSpawnPoint;
    public GameObject bottlePrefab;
    private float throwSpeed = 20;
    private KeyCode throwKey = KeyCode.Mouse0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(throwKey)){
            ThrowCondition();
        }
    }
    private void ThrowCondition(){
        if(gameManager.bottleCounter > 0){
            var bottle = Instantiate(bottlePrefab, bottleSpawnPoint.position, bottleSpawnPoint.rotation);
            bottle.GetComponent<Rigidbody>().velocity = bottleSpawnPoint.forward * throwSpeed;
            gameManager.bottleCounter--;
        }
    }
}
