using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RocketStageTwo : MultipleBarrels
{
   
    public override IEnumerator Fire()
    {
        Vector2 direction = (Target.transform.position - transform.position).normalized;
        
        GameObject Firebullet = Instantiate(bullet, bulletspawn[0].transform.position, Quaternion.identity);
        BulletAngle(Firebullet, Target);
        Firebullet.GetComponent<Rigidbody2D>().velocity = Bulletspeed * direction;
        GunShot.Play();
        yield return new WaitForSeconds(0.25f);

        GameObject Firebullet2 = Instantiate(bullet, bulletspawn[1].transform.position, Quaternion.identity);
        BulletAngle(Firebullet2, Target);
        Firebullet2.GetComponent<Rigidbody2D>().velocity = Bulletspeed * direction;
        GunShot.Play();
        yield return new WaitForSeconds(2f);
        Destroy(Firebullet);
        Destroy(Firebullet2);
    }



}
