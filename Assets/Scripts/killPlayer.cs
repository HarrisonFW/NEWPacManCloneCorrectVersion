﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killPlayer : MonoBehaviour
{
    // initial code for this script is from MoreBBlakeyyy on Youtube:  https://www.youtube.com/watch?v=H69PfxOr6bk

    //Cashed References

    public int Respawn;

    public GameObject Pac; //lets this script know what the player is to specifically teleport him 

    public GameObject Yellow; // given names for each of the Boomen, shortened to their colour
    public GameObject Orange;
    public GameObject Blue;
    public GameObject Green;
    public GameObject Purple;


    public PillManager pm; // communicates and defines the PillManager script as "pm"

    public BluePath pathingScript;

    public AudioSource obnoxiousHurtSound;
    public AudioSource gameOverNoise;


    // Start is called before the first frame update
    void Start() //This gets the Audio Sources because they must be initialised for them to be used
    {
        obnoxiousHurtSound = GetComponent<AudioSource>(); //audio from Pixabay

        gameOverNoise = GetComponent<AudioSource>(); // this audio from Pixabay
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) // when a ghost touches Pac, it teleports him to his spawnpoint, plays a hurt sound and teleports the other Boomen
    {
        if (other.CompareTag("Player")) //This code below is from Me, instead of destroying Pac,
        {                               // it teleports him to this "spawnpoint" and subtracts a life
                                        // manage3d in the PlayerMovement Script
            obnoxiousHurtSound.Play();  // the benifit of "teleporting" Pac and the Boomen instead of destroying them, is that noises can still play and the amount of
                                        // pills eaten/  lives remaining isn't reset, as it would be if Pac was destroyed and the scene reset every time.




            Pac.transform.position = new Vector3(0, (float)-3.98, 0);

           /* Yellow.transform.position = new Vector3((float)-25.14419, (float)-1.105154, 0);
            Orange.transform.position = new Vector3((float)3.545809, (float)3.494846, 0);
            Blue.transform.position = new Vector3((float)0.9958093, (float)3.48486, 0);
            Green.transform.position = new Vector3((float)29.65581, (float)7.564846, 0);

            pathingScript.targetPoint = 0;*/

            // Reset positions for all enemies

            // IMPORTANT for some reason when uncommented, the code for resetting the Purple Booman's position has an unintended glitch
            //when Pac gets hit, teleports him to a spot on the upper left side of the maze, acting as an
            //immovable obstacle. I have no idea why this happens as no code tells him to go to this spot
            //nor are the coordinates that he teleports to mentioned anywhere in any of my scripts???
            //For now, Purple Booman ignores the code that resets his position when Pac touches an enemy,
            //even after his activation
            // this makes him an even more dangerous enemy since he can take away multiple lives if traveling down the middle path when Pac looses a life

            Yellow.transform.position = new Vector3((float)-25.14419, (float)-1.105154, 0); //Thank you ChatGPT for helping me with this code
            Orange.transform.position = new Vector3((float)3.545809, (float)3.494846, 0);   // what I was trying to do is have ALL the ghosts' positions reset when ANY of them collide with pacman, apparently a Vector3 cannont be comined with boolean operand
            Blue.transform.position = new Vector3((float)0.9950893, (float)3.48486, 0);     // and so after trying to figure out how to splice the two for too long, I asked ChatGPT for help and it provided me a solution that works resonably well
            Green.transform.position = new Vector3((float)29.65581, (float)7.564846, 0);    // all these points are roughly where I've decided each ghosts spawn point is, and they return to them when any of the ghosts touch the player,
           // Purple.transform.position = new Vector3((float)-27.9, (float)-0.42, 0);       // this is to prevent them from immidietly taking another life away from pacman when he has his position reset.
            // Reset target points for all enemies
            BluePath bluePathScript = Blue.GetComponent<BluePath>();
            if (bluePathScript != null)
            {
                bluePathScript.targetPoint = 0;
            }

            BluePath yellowPathScript = Yellow.GetComponent<BluePath>();
            if (yellowPathScript != null)
            {
                yellowPathScript.targetPoint = 0;
            }

            BluePath orangePathScript = Orange.GetComponent<BluePath>();
            if (orangePathScript != null)
            {
                orangePathScript.targetPoint = 0;
            }

            BluePath greenPathScript = Green.GetComponent<BluePath>();
            if (greenPathScript != null)
            {
                greenPathScript.targetPoint = 0;


                //SceneManager.LoadScene(Respawn); <-- remnants of MoreBBlakeyyy's code which normally just
                // reset the scene after the player collided with the Boomen.
            }

            /*BluePath purplePathScript = Purple.GetComponent<BluePath>();
            if (purplePathScript != null)
            {
                purplePathScript.targetPoint = 0;
            }*/

        } // the reason I opted for teleporting the player and ghosts is so that I can add noises that aren't cut short if the scene is reset or if the player is destroyed

        else if (pm.liveCount < 0) //Only when life count reaches -1, then the scene resets
        {
            gameOverNoise.Play();
            SceneManager.LoadScene(Respawn); // I knew this wasn't going to work, so for now the sound just plays on awake, sorry it's so loud
            gameOverNoise.PlayDelayed(1f);
        }
    }

    //IMPORTANT NOTE, if I ever make more levesl, be sure to drag all the stuff into the 
    // boxes in the editor as Pacman isn't a prefab, nor is game manager

}
