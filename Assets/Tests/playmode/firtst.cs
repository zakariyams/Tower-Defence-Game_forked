using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class firtst
{

    private LevelManager manager;


    // A Test behaves as an ordinary method
    [Test]
    public void ReduceHealth_test()
    {
        // Use the Assert class to test conditions
        GameObject gameObject = new GameObject();
        manager = gameObject.AddComponent<LevelManager>();

        int damage = 45;

        manager.mapHealth = 100;

        manager.ReduceHealth(damage);


        Assert.AreEqual(100-damage, manager.mapHealth);
        

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.


    /*[UnityTest]
    public IEnumerator firtstWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }*/
}
