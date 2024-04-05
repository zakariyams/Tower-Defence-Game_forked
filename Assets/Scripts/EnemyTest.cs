using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public float movespeed = 5f;
    private Rigidbody2D rb;
    [SerializeField] GameObject[] points;
    private int index = 0;
    private GameObject target;

    void Start()
    {
        target = points[index];
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(target.transform.position, transform.position) <= 0.1f)
        {
            index++;
            target = points[index];
            if (index == 6)
            {
                index = 0;
                target = points[index];
            }

        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;

        rb.velocity = direction * movespeed;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Debug.Log("Hit");
            
        }
    }

}
