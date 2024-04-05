using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWorldTower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
    }
}
