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
    public float timeUntilFire;
    private float rotationspeed = 5f;
    [SerializeField] private GameObject Gun;


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
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);
    }

    protected void GunUpdate()
    {
        if (Target == null)
        {
            FindTarget();
            return;
        }

        RotateGun();
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

    public void RotateGun()
    {
        if (Target == null)
        {
            return;
        }

      
        Vector2 direction = Target.gameObject.transform.position - transform.position;
        Quaternion target = Quaternion.FromToRotation(Vector3.up, direction);
        Gun.transform.rotation = Quaternion.Lerp(Gun.transform.rotation, target, Time.deltaTime * rotationspeed);

    }




}
