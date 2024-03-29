/****
 * Created by: Thomas Nguyen
 * Date Created: March 6, 2022
 * 
 * 
 * Last Edited by: Thomas Nguyen
 * Lasted Edited: March 7, 2022
 * Description: Causes the ball to bounce on collision
 * 
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{

    [Header("Hide in Inspector")]
    private Rigidbody rb;
    Vector3 lastVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // obtains the speed of the ball before impact
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        // velocity of the ball is applied after it collides, allowing it to bounce
        rb.velocity = direction * Mathf.Max(speed, 0f);

    }
}
