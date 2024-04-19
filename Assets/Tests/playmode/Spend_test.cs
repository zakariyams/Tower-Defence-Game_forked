using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Spend_test
{
    // A Test behaves as an ordinary method

    private LevelManager manager;


    [Test]
    public void Spend_failed_test()
    {
        // Use the Assert class to test conditions


        GameObject gameObject = new GameObject();
        manager = gameObject.AddComponent<LevelManager>();


        manager.currency = 150;

        bool IsSpend = manager.Spend(200);

        Assert.AreEqual(false, IsSpend);



    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    /*[UnityTest]
    public IEnumerator Spend_testWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }*/
}
