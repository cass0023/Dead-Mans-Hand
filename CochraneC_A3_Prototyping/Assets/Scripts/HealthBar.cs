using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameManager gameManager;
    public Image fillbar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fillbar.fillAmount = gameManager.livesCounter / 10;
    }
}
