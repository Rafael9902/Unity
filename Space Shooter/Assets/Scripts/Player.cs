using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3 (0, 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        playerBounds();
    }

    void playerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    void playerBounds()
    {
        float positionX = transform.position.x;
        float positionY = transform.position.y;
        float positionZ = transform.position.z;

        // Vertical Bound
        transform.position = new Vector3(positionX, Mathf.Clamp(positionY, -3.5f, 0), positionZ);


        // Horizontal Bound
        if (positionX > 11.3f)
        {
            transform.position = new Vector3(-positionX, positionY, positionZ);
        }
        else if (positionX < -11.3f)
        {
            transform.position = new Vector3(-positionX, positionY, positionZ);
        }


    }

}
