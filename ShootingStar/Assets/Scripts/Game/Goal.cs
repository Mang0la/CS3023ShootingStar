/****
 * Created by: Thomas Nguyen
 * Date Created: March 7, 2022
 * 
 * 
 * Last Edited by: Thomas Nguyen
 * Lasted Edited: March 7, 2022
 * Description: The goal reacts when hit with a projectile
 * 
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{

    GameManager gm;

    static public bool goalMet = false;

    void OnTriggerEnter(Collider other)
    {
        // When the trigger is hit by something check to see if it's a Projectile
        if (other.gameObject.tag == "Projectile")
        {
            // If so, set goalMet to true
            Goal.goalMet = true;

            // Also set the alpha of the color to higher opacity
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 100;
            mat.color = c;

            // Add to the score depending on the amount of shots taken
            gm.Score += 5; //( 1 * (1000 - gm.Lives) );
            Debug.Log("test");


        }
    }


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GM;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
