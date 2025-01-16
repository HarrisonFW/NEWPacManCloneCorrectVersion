using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PillManager : MonoBehaviour
{

    //Collectible code provided by MoreBBlakeyyy on Youtube: https://www.youtube.com/watch?v=5GWRPwuWtsQ

    public int PillCount; // Pill Count is accesable by multiple scripts

    public Text pillText;

    public int liveCount = 3; // the lives are predefined 

    public Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + liveCount.ToString(); // updates the Lives text
        
        
        pillText.text = "Pills Eaten: " + PillCount.ToString(); //updates the UI with the preface "Pills Eaten"
    }
}
