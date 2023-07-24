using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField]
    private Vector2 movementDirection;

    [SerializeField]
    private float speed;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        handleControls();
        handleMovements();
        handleFlip();
    }

    void handleControls()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void handleMovements()
    {
        rigidBody.velocity = new Vector2(movementDirection.x * speed, movementDirection.y);
    }

    void handleFlip()
    {
        if (rigidBody.velocity.magnitude > 0)
        {
            if (rigidBody.velocity.x >= 0)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}
