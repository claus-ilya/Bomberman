using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixTransform : MonoBehaviour
{
    public static float Width { get; private set; } // Ширина блока
    public static int NumberOfConcreteBlocks { get; set; }  // Количество твердых блоков
    static GameObject plane;
    public static void SetPlane(GameObject planeObject, int numberOfBlocks)
    {
        plane = planeObject;
        NumberOfConcreteBlocks = numberOfBlocks;
        Width = 10 * planeObject.transform.localScale.x / (numberOfBlocks * 2 + 1);
    }
    public static void SetPlayer(GameObject player)
    {
        player.transform.localScale = new Vector3(Width * 0.9f, Width * 0.7f, Width * 0.9f);
        player.transform.position = new Vector3(-5 * plane.transform.localScale.x + player.transform.localScale.x * 0.7f,
            player.transform.localScale.y, -5 *plane.transform.localScale.z + player.transform.localScale.z);
    }

    public static void SetEnemy(GameObject enemy, int count)
    {
        List<Vector3> vector3 = new List<Vector3>();
        float offsetX = 0;
        float offsetY = 0;
        for (int i = 0; i < NumberOfConcreteBlocks; i++)
        {
            for (int j = 0; j < NumberOfConcreteBlocks; j++)
            {
                vector3.Add(new Vector3(-10 + offsetX + Width / 2, Width / 2, -10 + Width / 2 + offsetY ));
                offsetX += 2 * Width;
            }
            offsetX = Width;
            offsetY += 2 * Width;
        }

        for (int i = 0; i < count; i++)
        {
            enemy.transform.position = vector3[Random.Range(0, vector3.Count - 1)];
            Instantiate(enemy);
        }

    }
    public static void SetConcreteBlocks(GameObject concreteBlock)
    {
        concreteBlock.transform.localScale = new Vector3(Width, Width, Width);
        float offsetX = Width;
        float offsetY = Width;
        for (int i = 0; i < NumberOfConcreteBlocks; i++)
        {
            for (int j = 0; j < NumberOfConcreteBlocks; j++)
            {
                concreteBlock.transform.position = new Vector3(-10 + offsetX + Width / 2, Width / 2, -10 + Width / 2 + offsetY);
                offsetX += 2 * Width;
                 Instantiate(concreteBlock);
            }
            offsetX = Width;
            offsetY += 2 * Width;
        }
    }
    public static void SetWalls(GameObject wall)
    {
        wall.transform.eulerAngles = new Vector3(0, 0, 0);
        wall.transform.localScale = new Vector3(10 * plane.transform.localScale.x +2*Width, Width, Width);
        wall.transform.position = new Vector3(0, Width / 2, -10f - Width / 2);
        Instantiate(wall);
        wall.transform.position = new Vector3(0, Width / 2, 10f + Width / 2);
        Instantiate(wall);
        wall.transform.localEulerAngles = new Vector3(0, 90, 0);
        wall.transform.position = new Vector3(-10f - Width / 2, Width / 2, 0);
        Instantiate(wall);
        wall.transform.position = new Vector3(10f + Width / 2, Width / 2, 0);
        Instantiate(wall);
        return;



    }
}
