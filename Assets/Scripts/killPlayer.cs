using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killPlayer : MonoBehaviour
{
    // initial code for this script is from MoreBBlakeyyy on Youtube:  https://www.youtube.com/watch?v=H69PfxOr6bk

    public int Respawn;

    public GameObject Pac; //lets this script know what the player is to specifically teleport him 

    public GameObject Yellow;
    public GameObject Orange;
    public GameObject Blue;
    public GameObject Green;

    public PillManager pm; // communicates and defines the PillManager script as "pm"

    public BluePath pathingScript;

    public AudioSource obnoxiousHurtSound;


    // Start is called before the first frame update
    void Start()
    {
        obnoxiousHurtSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //This code below is from Me, instead of destroying Pac,
        {                               // it teleports him to this "spawnpoint" and subtracts a life
                                        // manage3d in the PlayerMovement Script
            obnoxiousHurtSound.Play();




            Pac.transform.position = new Vector3(0, (float)-3.98, 0);

           /* Yellow.transform.position = new Vector3((float)-25.14419, (float)-1.105154, 0);
            Orange.transform.position = new Vector3((float)3.545809, (float)3.494846, 0);
            Blue.transform.position = new Vector3((float)0.9958093, (float)3.48486, 0);
            Green.transform.position = new Vector3((float)29.65581, (float)7.564846, 0);

            pathingScript.targetPoint = 0;*/

            // Reset positions for all enemies
            Yellow.transform.position = new Vector3((float)-25.14419, (float)-1.105154, 0);  //Thank you ChatGPT for helping me with this code
            Orange.transform.position = new Vector3((float)3.545809, (float)3.494846, 0);   // what I was trying to do is have ALL the ghosts' positions reset when ANY of them collide with pacman, apparently a Vector3 cannont be comined with boolean operanda
            Blue.transform.position = new Vector3((float)0.9950893, (float)3.48486, 0);     // and so after trying to figure out how to splice the two for too long, I asked ChatGPT for help and it provided me a solution that works resonably well
            Green.transform.position = new Vector3((float)29.65581, (float)7.564846, 0);    // all these points are roughly where I've decided each ghosts spawn point is, and they return to them when any of the ghosts touch the player,
                                                                                            // this is to prevent them from immidietly taking another life away from pacman when he has his position reset.
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

        } // the reason I opted for teleporting the player and ghosts is so that I can add noises that aren't cut short if the scene is reset or if the player is destroyed

        else if (pm.liveCount < 0) //Only when life count reaches -1, then the scene resets
        {
            SceneManager.LoadScene(Respawn);
        }
    }

    //IMPORTANT NOTE, if I ever make more levesl, be sure to drag all the stuff into the 
    // boxes in the editor as Pacman isn't a prefab, nor is game manager

}
