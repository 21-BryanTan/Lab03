using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMovementScript : MonoBehaviour
{
    public float speed;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      float horizontalInput = Input.GetAxis("Horizontal");

      transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Healthy"))
        {
            print("Healthy food collected!");
        }
        else if(other.gameObject.CompareTag("Unhealthy"))
        {
            print("Unhealthy food collected!");
        }
    }
}
