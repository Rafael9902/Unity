using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private float _fireRate = 0.15f;

    private float _canFire = -1f;

    [SerializeField]
    private int _lifes = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3 (0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        playerBounds();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            Shoot();
        }
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

    void Shoot()
    {
       _canFire = Time.time + _fireRate;

        Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity );
    }

    public void Damage(int damage)
    {
        _lifes -= damage;

        if(_lifes < 1)
        {
            Destroy(gameObject);
        }
    }

}
