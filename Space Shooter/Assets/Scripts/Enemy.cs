using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    private float _bottomBound = -8f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float randomX = Random.Range(-10f, 10f);

        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y < _bottomBound)
        {
            transform.position = new Vector3(randomX, -_bottomBound, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogWarning("Hit: " + other.tag);

        if(other.tag == Tags.Player.ToString())
        {
            // Damage player
            Player player = other.transform.GetComponent<Player>();

            if(player != null)
            {
                player.Damage(1);  
            }
        }

        if(other.tag == Tags.Laser.ToString()) 
        { 
            Destroy(other.gameObject); 
        }


        Destroy(gameObject);
    }

 
}
