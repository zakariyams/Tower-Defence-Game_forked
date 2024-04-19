using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Currency_test
{


    private LevelManager manager;
    // A Test behaves as an ordinary method
    [Test]
    public void Currency_testSimplePasses()
    {
        // Use the Assert class to test conditions
        GameObject gameObject = new GameObject();
        manager = gameObject.AddComponent<LevelManager>();

        manager.currency = 200;

        manager.IncreaseCurrency(150);

        Assert.AreEqual(350, manager.currency);

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    /*[UnityTest]
    public IEnumerator Currency_testWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }*/
}
