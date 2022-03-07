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
    public GameObject cometPrefab;
    public Transform firePoint;

    private Camera cam;
    private bool mousePress = false;

    private Vector3 initialVelocity;


    /***
    static private CannonManager C;

    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMultiplier = 8f;

    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile; //instance of the projectile
    public bool aimingMode; //is player aiming
    public Rigidbody projectileRB; //rigidbody of the projectile
    

    static public Vector3 Launch_Pos
    {
        get
        {
            if (C == null) return Vector3.zero;
            return C.launchPos;
        }
    }

    private void Awake()
    {
        C = this;

        Transform launchPointTrans = transform.Find("LaunchPoint"); //every gameobject has a transform component
        launchPoint = launchPointTrans.gameObject; //looks for another transform component with the same name because its referencing the transformation    

        launchPoint.SetActive(false); //disables the launchpoint 
        launchPos = launchPointTrans.position; //position of launch point
    }
    ***/

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePress = true;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            mousePress = false;
            cometShoot();
        }

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x,
        mousePosition.y - transform.position.y);

        initialVelocity = direction;
        transform.up = direction;
        

        if (mousePress)
        {

            

            /*** Original
            Vector3 mousePos = Input.mousePosition;
            mousePos.y = 0;
            mousePos.z = 0;


            transform.LookAt(mousePos);
            initialVelocity = mousePos - firePoint.position;
            ***/

            /*** Mission Demolition
            //get mouse position from 2D coordinates
            Vector3 mousePos2D = Input.mousePosition;
            mousePos2D.z = -Camera.main.transform.position.z;
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

            Vector3 mouseDelta = mousePos3D - launchPos;

            //limit the mouseDelta to the slingshot collider radius
            float maxMagnitude = this.GetComponent<SphereCollider>().radius;

            if (mouseDelta.magnitude > maxMagnitude)
            {
                mouseDelta.Normalize(); //sets tyhe vector to the same direction but with a length of 1
                mouseDelta *= maxMagnitude;
            } //end if (mouseDelta > maxMagnitude)

            ***/

        }

    }

    private void cometShoot()
    {
        GameObject comet = Instantiate(cometPrefab, firePoint.position, gameObject.transform.rotation);

        Rigidbody rb = comet.GetComponent<Rigidbody>();
        rb.AddForce(initialVelocity, ForceMode.Impulse);
    }

}
