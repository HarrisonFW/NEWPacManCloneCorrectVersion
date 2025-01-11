using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{

    //Collectible code provided by MoreBBlakeyyy on Youtube: https://www.youtube.com/watch?v=5GWRPwuWtsQ

    public int PillCount; // Pill Count is accesable by multiple scripts

    public Text pillText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pillText.text = "Pills Eaten: " + PillCount.ToString(); //updates the UI with the preface "Pills Eaten"
    }
}
