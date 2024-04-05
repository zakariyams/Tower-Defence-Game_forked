using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GunFirstStage : Towers
{
    [SerializeField] private float range = 5f;
    [SerializeField] private float bulletspeed = 20f;
    [SerializeField] private float bps = 1f;
    private GameObject target;
    [SerializeField] private GameObject bulletspawn;
    [SerializeField] private GameObject bullet;
    private float timeUntilFire;


    private void Start()
    {
        Range = range;
        Bulletspeed = bulletspeed;
        Bps = bps;
        Target = target;
    }

    public override IEnumerator Fire()
    {
        GameObject Firebullet = Instantiate(bullet, bulletspawn.transform.position, Quaternion.identity);
        Vector2 direction = (Target.transform.position - transform.position).normalized;
        Firebullet.GetComponent<Rigidbody2D>().velocity = Bulletspeed * direction;

        BulletAngle(Firebullet, Target);
        yield return new WaitForSeconds(1f);
        Destroy(Firebullet);
    }


    protected override void Update()
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

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, range);
    }

}
