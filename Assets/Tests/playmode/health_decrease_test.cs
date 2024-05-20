using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class health_decrease_test
{


    //private Enemies testenemy;
    private Transform b;

    // A Test behaves as an ordinary method
    //[Test]
    /*public void health_decrease_testSimplePasses()
    {
        // Use the Assert class to test conditions
        GameObject gameObject = new GameObject();
        testenemy = gameObject.AddComponent<Enemies>();

        GameObject healthbar = new GameObject();
        SpriteRenderer healthBarSpriteRenderer = healthbar.AddComponent<SpriteRenderer>();
        
        healthBarSpriteRenderer.color = Color.blue;
        Transform healbar = healthbar.AddComponent<Transform>();

        testenemy.healthBar = healbar;

        //testenemy.spriteRenderer = GetComponent<SpriteRenderer>();


        //testenemy.healthBar.transform.localScale = new Vector3(0.1f, 0.1f, 1f);

        testenemy.health = 100;

        //testenemy.curHealth = 90;

        testenemy.TakeDamage(40);

        float testHealth = testenemy.curHealth - 40;

        Assert.AreEqual(testenemy.curHealth, testHealth);

        Vector3 testvecor = new Vector3(0.1f - (40/100), 0.1f, 1f);

        //Assert.AreEqual(testenemy.healthBar.localScale, testvecor);

    }*/
    
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    
    
    [UnityTest]
    public IEnumerator health_decrease_testWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.


        yield return SceneManager.LoadSceneAsync("TestSceneZ");

        GameObject gameObject = GameObject.Find("Testenemy");

        Enemies testenemy = gameObject.GetComponent<Enemies>();

        //testenemy = gameObject.AddComponent<Enemies>();

        //GameObject healthbar = new GameObject();
        //SpriteRenderer healthBarSpriteRenderer = healthbar.AddComponent<SpriteRenderer>();
        
        //healthBarSpriteRenderer.color = Color.blue;
        //Transform healbar = healthbar.AddComponent<Transform>();

        //testenemy.healthBar = healbar;*/

        //testenemy.spriteRenderer = GetComponent<SpriteRenderer>();


        //testenemy.healthBar.transform.localScale = new Vector3(0.1f, 0.1f, 1f);

        //testenemy.health = 100;

        //testenemy.curHealth = 90;

        float testHealth = testenemy.curHealth - 40;
        
        testenemy.TakeDamage(40);

        Assert.AreEqual(testenemy.curHealth, testHealth);

        Vector3 testvecor = new Vector3(testenemy.healthBar.localScale.x - (40/100), 0.1f, 1f);


        Assert.AreEqual(testenemy.healthBar.localScale, testvecor);



        //yield return null;
    }
    
}
