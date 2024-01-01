using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControll : MonoBehaviour
{
    Rigidbody rb ;
    public float speed = 1.5f;
    private int ballGroundTouch = 0 ;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * speed , ForceMode.Impulse);
        Invoke("Destroy", 7f);
        
    }

    private void Destroy(){
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ground")
        {
            ballGroundTouch++;
        }
    }

      private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Bat")
        {
            float ballForce = Random.Range(1f, 8f);
            float ballHeight = Random.Range(1f, 8f);
            float ballAngle = Random.Range(0f, 360f);
        // This function takes three parameters: radius, angle, and height.
            // radius: The distance from the origin to the point.
            Vector3 ballDir = PolarToCartesian(-ballForce, ballAngle, ballHeight);
            rb.AddForce(ballDir , ForceMode.Impulse);
        }
        // radius * Mathf.Cos(angle * Mathf.Deg2Rad): Calculates the x-coordinate.
        // radius * Mathf.Sin(angle * Mathf.Deg2Rad): Calculates the z-coordinate.
         Vector3 PolarToCartesian(float radius, float angle, float height)
        {
            float x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            float z = radius * Mathf.Sin(angle * Mathf.Deg2Rad);

            return new Vector3(x, height, z);
        }

        if (other.gameObject.tag == "Boundry")
        {
              if(ballGroundTouch <= 1)
            {
                ballScript.instance.updateRuns(6);
            }
            else
            {
                ballScript.instance.updateRuns(4);
            }
            Destroy(this.gameObject);
        }
        
        if (other.gameObject.tag == "Fielders")
        {
            float fielderHeightThreshold = 0.5f;
            float fielderDistanceThreshold = 1f;

            if (other.transform.position.y < fielderHeightThreshold)
            {
                float distance = Vector3.Distance(transform.position, other.transform.position);

                if (distance < fielderDistanceThreshold)
                {
                    Destroy(this.gameObject);
                    ballScript.instance.updateWickets(1);
                }
            }
        }
    }

}
