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
        GameObject rocketObj = new GameObject();
        rocketObj.tag = "Bullet";
        OneBarrel rocketScript = rocketObj.AddComponent<OneBarrel>();
        yield return new WaitForSeconds(5f); 
        Assert.IsTrue(rocketScript.Responsive); 
    }

    [UnityTest]
    public IEnumerator MultipleBarrel_ResponsiveTest()
    { 
        yield return SceneManager.LoadSceneAsync("TestSceneJ");
        GameObject rocketObj = new GameObject();
        rocketObj.tag = "Bullet";
        MultipleBarrels rocketScript = rocketObj.AddComponent<MultipleBarrels>();
        yield return new WaitForSeconds(5f); 
        Assert.IsTrue(rocketScript.Responsive); 
    }

    [UnityTest]
    public IEnumerator RocketStage2_ResponsiveTest()
    {
        yield return SceneManager.LoadSceneAsync("TestSceneJ");
        GameObject rocketObj = new GameObject();
        RocketStageTwo rocketScript = rocketObj.AddComponent<RocketStageTwo>();
        yield return new WaitForSeconds(5f); 
        Assert.IsTrue(rocketScript.Responsive);
    }

    [UnityTest]
    public IEnumerator RocketStage3_ResponsiveTest()
    {
        yield return SceneManager.LoadSceneAsync("TestSceneJ");
        GameObject rocketObj = new GameObject();
        RocketStage3 rocketScript = rocketObj.AddComponent<RocketStage3>();
        yield return new WaitForSeconds(5f); 
        Assert.IsTrue(rocketScript.Responsive); 
    }




}
