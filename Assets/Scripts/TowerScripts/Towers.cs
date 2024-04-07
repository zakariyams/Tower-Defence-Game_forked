using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Towers : MonoBehaviour
{
    
    public float Range {  get; protected set; }
    public float Bulletspeed { get; protected set; }
    public float Bps {  get; protected set; }
    [SerializeField] private LayerMask enemy;
    public GameObject Target { get; protected set; }
    protected float timeUntilFire;

<<<<<<< HEAD
=======

    
>>>>>>> 797a89f33d93ab592a1619be83e61ff716eefa49
    // Finds the closest enemy and places it as the next target. RayCAstHit2D[] is an array of all objects that goes in the circle
    public void FindTarget( )
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, Range, (Vector2)transform.position, 0f, enemy);
        if (hits.Length > 0)
        {
            Target = hits[0].transform.gameObject;
        }
        else
        {
            Target = null;
        }
    }

    protected virtual void Update()
    {
        if (Target == null || !CheckInRange())
        {
            FindTarget();
        } 
    }


    public bool CheckInRange()
    {
        return Vector2.Distance(Target.transform.position, transform.position) <= Range;
    }

    // Fires the bullet 
    public abstract IEnumerator Fire();
    

    // Fixes the angle of the bullet when firing 
    public static void BulletAngle(GameObject bullet, GameObject target)
    {
        Vector2 offset = target.transform.position - bullet.transform.position;
        bullet.transform.rotation = Quaternion.FromToRotation(Vector3.up, offset);
    }

    protected void GunUpdate()
    {
        if (Target == null)
        {
            FindTarget();
            return;
        }

        Vector2 direction = Target.gameObject.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        timeUntilFire += Time.deltaTime;

        if (!CheckInRange())
        {
            Target = null;
        }
        else if (timeUntilFire >= 1f / Bps && CheckInRange())
        {
            StartCoroutine(Fire());
            timeUntilFire = 0f;
        }
    }




}
