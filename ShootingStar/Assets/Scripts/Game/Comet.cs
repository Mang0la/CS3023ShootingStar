/***
 * Created by: Thomas Nguyen
 * Date Created: 3/2/2022
 * 
 * Last Edited: 3/2/2022
 * Last Edited by: Thomas Nguyen
 * 
 * Description: Comet despawn logic
***/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour
{
    public static float bottomY = -40f;
    public static float turnSpeed = 100f;
    public KeyCode keySpace;
    public KeyCode keyLeft;
    public KeyCode keyRight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        } //end if (transform.position.y < bottomY)

        if (Input.GetKeyDown(keySpace))
        {
            //launch comet
        }

        if (Input.GetKeyDown(keyLeft))
        {
            transform.Rotate(Vector3.up * turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        }

        if (Input.GetKeyDown(keyRight))
        {
            transform.Rotate(Vector3.up * turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        }

    }
}
