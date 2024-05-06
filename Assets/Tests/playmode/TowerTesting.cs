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
        // Load a test scene
        yield return SceneManager.LoadSceneAsync("TestSceneJ");

        // Arrange
        GameObject rocketObj = new GameObject();
        rocketObj.tag = "Bullet";

        // Add required components
        OneBarrel rocketScript = rocketObj.AddComponent<OneBarrel>();

        // Simulate collision using physics
        yield return new WaitForSeconds(5f); // Wait for physics to update

        // Assert
        Assert.IsTrue(rocketScript.Responsive); // Assert that Fire method has been called
    }

    [UnityTest]
    public IEnumerator MultipleBarrel_ResponsiveTest()
    {
        // Load a test scene
        yield return SceneManager.LoadSceneAsync("TestSceneJ");

        // Arrange
        GameObject rocketObj = new GameObject();
        rocketObj.tag = "Bullet";


        // Add required components
        MultipleBarrels rocketScript = rocketObj.AddComponent<MultipleBarrels>();

        // Simulate collision using physics
        yield return new WaitForSeconds(5f); // Wait for physics to update

        // Assert
        Assert.IsTrue(rocketScript.Responsive); // Assert that Fire method has been called
    }

    [UnityTest]
    public IEnumerator RocketStage2_ResponsiveTest()
    {
        // Load a test scene
        yield return SceneManager.LoadSceneAsync("TestSceneJ");

        // Arrange
        GameObject rocketObj = new GameObject();

        // Add required components
        RocketStageTwo rocketScript = rocketObj.AddComponent<RocketStageTwo>();

        // Simulate collision using physics
        yield return new WaitForSeconds(5f); // Wait for physics to update
        // Assert
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
