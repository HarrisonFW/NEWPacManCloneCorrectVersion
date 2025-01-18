using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PillManager : MonoBehaviour
{
    //IMPORTANT Code here is provided by Chat GPT sinceI niavely thought that just trying to increase the
    //speed when pacman eats over a certain number of pills would be easy, So I had to ask chatGPT
    //a few times before it gave me some working code, but in doing so it seems to also have rewritten
    // some of the other code handeling the UI
    //My original code and attributions can still be found at the bottom of this script commented out
    // I know this is unprofessional but I think it is important for me to explain myself especially when
    //I've used an AIs code when My many attempts faild. I tried to create a new method that would update
    //the enemy speed once the pillCount > 32, and my code for this method being able to communicate with the
    //BluePath.cs script was working, the speed just woudn't increase. I find it upsetting that I have had to
    //rely on other sources to be able to get the majority of this program working, because I am just not 
    // that affluent at coding at this stage, I feel as though my logic, or pseudo code should work, but when
    //I try to impliment it, it seldom if ever does. Simple things have so many steps to them and it's
    // frustrating when I want to add or test out features when so many of them require basically a rewriting
    // of the whole program

    public int PillCount; // Pill Count is accessible by multiple scripts
    public Text pillText;

    public int liveCount = 3; // The lives are predefined
    public Text livesText;

    public int speedIncrease = 5; // Amount to increase the speed of enemies
    private bool speedIncreased = false; // Ensure speed is increased only once

    public Text SpeedUpText;
    public AudioSource speedUpWOOSHNoise;

    public GameObject purpleEnemy;
    private BluePath purpleEnemyScript;
    private bool purpleActivated = false;
    public AudioSource ghostWakeUp;
    public Text purpleBoomanAwokenText;
    void Start()
    {
        // Get the BluePath script from the Purple Booman
        purpleEnemyScript = purpleEnemy.GetComponent<BluePath>();

        // Ensure Purple starts inactive
        if(purpleEnemyScript != null)
        {
            purpleEnemyScript.isActive = false; // Freeze enemy at start
            Debug.Log("Purple Booman starts inactive");
        }




        // Initial UI updates
        UpdateUI();
    }

    void Update()
    {
        // Update UI for lives and pills eaten
        UpdateUI();

        // Check if PillCount exceeds 5 and ensure speed increases only once
        if (PillCount >= 32 && !speedIncreased)
        {
            IncreaseEnemySpeeds();
            speedIncreased = true; // Prevent further speed increases

            SpeedUpText.text = "Boomen Speed Increase";

            speedUpWOOSHNoise.Play();
        }

        if (PillCount >= 48 && !purpleActivated)
        {
            ActivatePurpleEnemy();
        }

    }

    private void ActivatePurpleEnemy()
    {
        if (purpleEnemyScript != null)
        {
            purpleEnemyScript.isActive = true;
            Debug.Log("Purple Booman activated");

            ghostWakeUp.Play();

            purpleBoomanAwokenText.text = ("Purple Booman Awoken");
        }

        purpleActivated = true;
    }


    private void UpdateUI()
    {
        livesText.text = "Lives: " + liveCount.ToString();
        pillText.text = "Pills Eaten: " + PillCount.ToString();
    }

    private void IncreaseEnemySpeeds()
    {
        // Find all objects with the BluePath component
        BluePath[] allEnemies = FindObjectsOfType<BluePath>();

        // Iterate over all enemies and increase their speed
        foreach (BluePath enemy in allEnemies)
        {
            enemy.speed += speedIncrease;
        }

        Debug.Log("Increased speed of all enemies by " + speedIncrease);
    }

    /* //Collectible code provided by MoreBBlakeyyy on Youtube: https://www.youtube.com/watch?v=5GWRPwuWtsQ

     public int PillCount; // Pill Count is accesable by multiple scripts
     public Text pillText;

     public int liveCount = 3; // the lives are predefined 
     public Text livesText;                                 


     public BluePath[] enemyPaths;
     public int speedIncrease = 5;
     private bool SPEEDINCREASED = false;


     // Start is called before the first frame update
     void Start()
     {

         //enemyPaths = FindObjectOfType<BluePath>();
     }

     // Update is called once per frame
     void Update()
     {
         livesText.text = "Lives: " + liveCount.ToString(); // updates the Lives text


         pillText.text = "Pills Eaten: " + PillCount.ToString(); //updates the UI with the preface "Pills Eaten"

         if (PillCount > 5 && !SPEEDINCREASED)
         {
             IncreaseEnemySpeed();

             SPEEDINCREASED = true;

             //newSpeed = (int)pathingScript.speed +5;
         }


     }

     private void IncreaseEnemySpeed()
     {
         foreach (BluePath enemy in enemyPaths)
         {
             enemy.speed += speedIncrease;
         }
     }
 */



}
