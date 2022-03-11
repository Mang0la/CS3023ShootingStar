/***
 * Created by: Thomas Nguyen
 * Date Created: March 2, 2022
 * 
 * Last Edited: March 7, 2022
 * Last Edited by: Thomas Nguyen
 * 
 * Description: Comet despawn logic
***/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour
{

    GameManager gm;

    [Header("Set in Inspector")]
    public float bottomY = -55f;
    static public int shotsTaken;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GM;
    }

    // Update is called once per frame
    void Update()
    {

        // destroys projectiles if they fall below the camera's view
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            gm.Lives += 1;
        } //end if (transform.position.y < bottomY)

    }
}
