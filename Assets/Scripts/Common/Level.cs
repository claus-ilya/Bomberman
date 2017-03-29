using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    StaticObjectCreator staticObjectCreator;
    public int ConcreteBlocksAmount { get; private set; }
    public int SoftBlocksAmount { get; private set; }

    List<GameObject> ConcreteBlocks;
    List<GameObject> SoftBlocks;

    public Level(int c, int s)
    {
        ConcreteBlocksAmount = c;
        SoftBlocksAmount =  s;
        ConcreteBlocks = new List<GameObject>(c);
        SoftBlocks = new List<GameObject>(s);
        //for (int i = 0; i < ConcreteBlocks.Count - 1)
            //ConcreteBlocks[i] = staticObjectCreator.GetConcreteBlock();
        //ConcreteBlocks[i].dup

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
