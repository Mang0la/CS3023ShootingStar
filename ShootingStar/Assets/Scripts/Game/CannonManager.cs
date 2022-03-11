/****
 * Created by: Thomas Nguyen
 * Date Created: February 28, 2022
 * 
 * 
 * Last Edited by: Thomas Nguyen
 * Lasted Edited: March 7, 2022
 * Description: Controls the cannon and the projectiles shot
 * 
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour
{

    [Header("Set in Inspector")]
    public GameObject cometPrefab;
    public Transform firePoint;
    private Vector3 initialVelocity;

    [Header("Set Dynamically")]
    private bool mousePress = false;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; //set the camera to the current scene's camera
    }

    // Update is called once per frame
    void Update()
    {
        // detects whether the mouse is clicking
        if (Input.GetMouseButtonDown(0))
        {
            mousePress = true;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            mousePress = false;
            cometShoot();
        }

        // translates the mouse position to 2D and makes the cannon follow the x and y direction
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = cam.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x,
        mousePosition.y - transform.position.y);

        initialVelocity = direction;
        transform.up = direction;

    }

    private void cometShoot()
    {
        // Fires projectile, with additional force depending on the
        // distance of the mouse from the cannon
        GameObject comet = Instantiate(cometPrefab, firePoint.position, gameObject.transform.rotation);

        Rigidbody rb = comet.GetComponent<Rigidbody>();
        rb.AddForce(initialVelocity, ForceMode.Impulse);
    }

}
