using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWorldEnemy : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(
            this.transform.position.x + _direction.x,
            this.transform.position.y + _direction.y,
            0.0f
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "AdrianTestZone1")
        {
            _direction = Vector2.right;
        }
        else if (collision.tag == "AdrianTestZone2")
        {
            _direction = Vector2.down;
        }
        else if (collision.tag == "AdrianTestZone3")
        {
            _direction = Vector2.left;
        }
        else if (collision.tag == "AdrianTestZone4")
        {
            _direction = Vector2.up;
        }
    }
}
