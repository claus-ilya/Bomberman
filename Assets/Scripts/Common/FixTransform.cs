using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FixTransform
{
    public static float Width { get; private set; }
    static GameObject plane;
    public static void SetPlane(GameObject planeObject, int numberOfBlocks)
    {
        plane = planeObject;
        Width = 10 * planeObject.transform.localScale.x / (numberOfBlocks * 2 + 1);
    }
    public static void SetPlayer(GameObject player)
    {
        player.transform.localScale = new Vector3(Width * 0.8f, Width * 0.7f, Width * 0.8f);
        player.transform.position = new Vector3(-5 * plane.transform.localScale.x + player.transform.localScale.x,
            player.transform.localScale.y, -5 *plane.transform.localScale.z + player.transform.localScale.z);
    }
    public static void SetConcreteBlocks(List<GameObject> concreteBlocks)
    {
        foreach (GameObject concreteBlock in concreteBlocks)
            concreteBlock.transform.position = new Vector3(Width, Width, Width);
        for (int i = 0; i < concreteBlocks.Count; i++)
        {
            //for (int j = 0; j < concreteBlocks.Count)
            //{
            //    concreteBlocks[j]
            //}
        }
    }
}
