using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class tower_instantiate_test
{
    // A Test behaves as an ordinary method
    /*[Test]
    public void tower_instantiate_testSimplePasses()
    {
        // Use the Assert class to test conditions
    }*/

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    

    public position_script_mock position;
    private BuildManager buildmanager;
    private LevelManager lvlmanager;
    
    private SpriteRenderer testSpriteRenderer;
    
    private Color hovcol;
    private Color original;

    /*[SetUp]
    public void SetUp()
    {


        GameObject gameObject = new GameObject();
        position = gameObject.AddComponent<position_script>();

        testSpriteRenderer = gameObject.AddComponent<SpriteRenderer>();

        hovcol = Color.red;
        original = Color.white;

        position.SetSpriteRenderer(testSpriteRenderer);
        position.SetHoverColor(hovcol);
        //position.spriterend = testSpriteRenderer;
        
        testSpriteRenderer.color = original;

        //position.tower = null;

        Debug.Log("Runs");
    }*/






    [UnityTest]
    public IEnumerator tower_not_null()
    {
        yield return SceneManager.LoadSceneAsync("TestSceneZ");

        GameObject positionobj = GameObject.Find("position");

        position_script_mock position = positionobj.GetComponent<position_script_mock>();


        /*GameObject build = new GameObject();
        buildmanager = build.AddComponent<BuildManager>();*/
        //BuildManager bmanager = buildmanager.acces_build;

        /*BuildManager bmanager = BuildManager.acces_build;

        GameObject mockprefab = new GameObject();
        //bmanager.Set_prefabs(mockprefab, 1);
        bmanager.selectedTower = 1;*/
        BuildManager.main.selectedTower = 1;



        //bmanager.selectedTower = 1;

        GameObject manager = new GameObject();
        lvlmanager = manager.AddComponent<LevelManager>();

        lvlmanager.currency = 200;

        Debug.Log("Runs2");

        position.OnMouseDown();


        Debug.Log("Runs3");
        //yield return new WaitForSeconds(1f);

        Assert.IsNotNull(position.tower);

        //yield return null;
    }
}
