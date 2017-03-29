using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class FirstLevelInitializer : MonoBehaviour {

    public int ConcreteBlocksAmount;
    public int SoftBlocksAmount;
    float width;
    GameObject player;
    List<GameObject> ConcreteBlocks;
    List<GameObject> SoftBlocks;
    StaticObjectCreator staticObjectCreator = new StaticObjectCreator();
    DynamicObjectCreator dynamicObjectCreator = new DynamicObjectCreator();
	void Start () {
        
        GameObject field = staticObjectCreator.GetPlane();
        width = 10 *field.transform.localScale.x / (ConcreteBlocksAmount * 2 + 1);

        player = dynamicObjectCreator.GetPlayer();
        FixTransform.SetPlane(field, ConcreteBlocksAmount);
        FixTransform.SetPlayer(player);
        //player.transform.localScale = new Vector3(width * 0.8f, width * 0.7f, width * 0.8f);
        //player.transform.position = new Vector3(-10 + player.transform.localScale.x, player.transform.localScale.y, -10 + player.transform.localScale.z);
        Instantiate(player);

        ConcreteBlocks = new List<GameObject>(ConcreteBlocksAmount);
        SoftBlocks = new List<GameObject>(SoftBlocksAmount);
        for (int i = 0; i < ConcreteBlocksAmount; i++)
        {
            ConcreteBlocks.Add(staticObjectCreator.GetConcreteBlock());
            ConcreteBlocks[i].transform.localScale = new Vector3(width, width, width);
        }

        float offsetX = width;
        float offsetY = width;

        for (int j = 0; j < ConcreteBlocksAmount; j++)
        {
            for (int i = 0; i < ConcreteBlocksAmount; i++)
            {
                ConcreteBlocks[i].transform.position = new Vector3(-10 + offsetX + width / 2, width / 2, -10  + width / 2 + offsetY);
                offsetX += 2 * width;
                Instantiate(ConcreteBlocks[i]);
            }
            offsetX = width;
            offsetY += 2 * width;
        }

            
        
        Instantiate(field);

        //GameObject nnn = Instantiate(objectCreator.GetSoftBlock());
        //nnn.transform.position = new Vector3(1, 1, 1);
        //GameObject softCube = objectCreator.GetConcreteBlock();
        //GameObject field = objectCreator.GetPlane();

        //GameObject.Instantiate(softCube);
        //GameObject.Instantiate(field);
    }

    // Update is called once per frame
    void Update () {
        //GameObject cube = new GameObject.CreatePrimitive(PrimitiveType.Cube);
    }
}
