using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class LevelInitializer : MonoBehaviour {

    public int numberOfConcreteBlocks;
    public int numberOfSoftBlocks;
    public int numberOfEnemy;
    GameObject plane;
    GameObject wall;
    GameObject concreteBlock;
    GameObject softBlock;
    GameObject player;
    GameObject enemy;
    StaticObjectCreator staticObjectCreator = new StaticObjectCreator();
    DynamicObjectCreator dynamicObjectCreator = new DynamicObjectCreator();

	void Start ()
    {
        plane = staticObjectCreator.GetPlane();
        concreteBlock = staticObjectCreator.GetConcreteBlock();
        softBlock = staticObjectCreator.GetSoftBlock();
        wall = staticObjectCreator.GetWall();
        player = dynamicObjectCreator.GetKnight();
        enemy = dynamicObjectCreator.GetDinosaurEnemy();

        SetGameObject.SetPlane(plane, numberOfConcreteBlocks);
        SetGameObject.SetWalls(wall);
        SetGameObject.SetConcreteBlocks(concreteBlock);
        SetGameObject.SetSoftBlocks(softBlock, numberOfSoftBlocks);
        SetGameObject.SetPlayer(player);
        SetGameObject.SetEnemy(enemy, numberOfEnemy);

    }
}
