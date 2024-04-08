using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketStage3 : MultipleBarrels
{

    public override IEnumerator Fire()
    {
        Vector2 direction = (Target.transform.position - transform.position).normalized;
        List<GameObject> firedBullets = new List<GameObject>();


        for (int i = 0; i < bulletspawn.Length; i++)
        {
           
            if (Target != null)
            {
                GameObject fireBullet = Instantiate(bullet, bulletspawn[i].transform.position, Quaternion.identity);
                BulletAngle(fireBullet, Target);
                fireBullet.GetComponent<Rigidbody2D>().velocity = Bulletspeed * direction;
                GunShot.Play();
                firedBullets.Add(fireBullet);
            }

            // Wait for 0.25 seconds between each shot, except after the last one
            if (i < bulletspawn.Length - 1)
            {
                yield return new WaitForSeconds(0.25f);
            }
        }

        // Wait 2 seconds after the last bullet before starting to destroy them
        yield return new WaitForSeconds(2f);

        // Destroy all bullets that were fired
        foreach (var bullet in firedBullets)
        {
            Destroy(bullet);
        }
    }
}
