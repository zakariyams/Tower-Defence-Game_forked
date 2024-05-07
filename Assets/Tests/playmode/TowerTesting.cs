using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TowerTesting
{
    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator OneBarrel_ResponsiveTest()
    {
        yield return SceneManager.LoadSceneAsync("TestSceneJ");
        GameObject rocketObj = GameObject.Find("Tower (8)");
        OneBarrel rocketScript = rocketObj.GetComponent<OneBarrel>();
        yield return new WaitForSeconds(5f); 
        Assert.IsNotNull(rocketScript.Target); 
    }

    [UnityTest]
    public IEnumerator MultipleBarrel_ResponsiveTest()
    { 
        yield return SceneManager.LoadSceneAsync("TestSceneJ");
        GameObject rocketObj = GameObject.Find("Tower (2)");
        MultipleBarrels rocketScript = rocketObj.GetComponent<MultipleBarrels>();
        yield return new WaitForSeconds(5f); 
        Assert.IsNotNull(rocketScript.Target); 
    }

    [UnityTest]
    public IEnumerator RocketStage2_ResponsiveTest()
    {
        yield return SceneManager.LoadSceneAsync("TestSceneJ");
        GameObject rocketObj = GameObject.Find("Rocketlvl2");
        RocketStageTwo rocketScript = rocketObj.GetComponent<RocketStageTwo>();
        yield return new WaitForSeconds(5f); 
        Assert.IsNotNull(rocketScript.Target);
    }

    [UnityTest]
    public IEnumerator RocketStage3_ResponsiveTest()
    {
        yield return SceneManager.LoadSceneAsync("TestSceneJ");
        GameObject rocketObj = GameObject.Find("Rocketlvl3");
        RocketStage3 rocketScript = rocketObj.GetComponent<RocketStage3>();
        yield return new WaitForSeconds(5f); 
        Assert.IsNotNull(rocketScript.Target); 
    }




}
