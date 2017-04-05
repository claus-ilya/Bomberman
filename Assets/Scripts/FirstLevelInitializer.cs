using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class FirstLevelInitializer : MonoBehaviour {

    public int ConcreteBlocksAmount;
    public int SoftBlocksAmount;
    public int NumberOfEnemy;
    GameObject field;
    GameObject player;
    GameObject wall;
    GameObject concreteBlock;
    List<GameObject> softBlocks;
    StaticObjectCreator staticObjectCreator = new StaticObjectCreator();
    DynamicObjectCreator dynamicObjectCreator = new DynamicObjectCreator();

    GameObject enemy1;
	void Start ()
    {         
        field = staticObjectCreator.GetPlane();
        player = dynamicObjectCreator.GetPlayer();
        concreteBlock = staticObjectCreator.GetConcreteBlock();
        softBlocks = new List<GameObject>(SoftBlocksAmount);
        wall = staticObjectCreator.GetWall();
        enemy1 = dynamicObjectCreator.GetEnemy();



        FixTransform.SetPlane(field, ConcreteBlocksAmount);
        FixTransform.SetPlayer(player);
        FixTransform.SetConcreteBlocks(concreteBlock);
        FixTransform.SetWalls(wall);

        Instantiate(field);
        Instantiate(player);

        FixTransform.SetPlayer(enemy1);
        FixTransform.SetEnemy(enemy1, NumberOfEnemy);
        //enemy1.transform.localPosition = new Vector3(enemy1.transform.localPosition.x, enemy1.transform.localPosition.y, enemy1.transform.localPosition.z + 2);
        //Instantiate(enemy1);
    }

    // Update is called once per frame
    void Update () {

    }
}
