using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameObject : MonoBehaviour
{
    public static float Width { get; private set; } // Ширина блока
    public static int NumberOfConcreteBlocks { get; set; }  // Количество твердых блоков
    public static int NumberOfSoftBlocks { get; set; }      // Количество разрушимых блоков
    public static List<Vector3> EmptyTiles;     // Список свободных плиток на арене (где не стоят блоки)
    static GameObject plane;

    public static void SetPlane(GameObject planeObject, int numberOfBlocks)
    {
        plane = planeObject;
        NumberOfConcreteBlocks = numberOfBlocks;
        Width = 10 * planeObject.transform.localScale.x / (numberOfBlocks * 2 + 1);
        DefineEmptyTiles();
        Instantiate(plane);
    }
    public static void SetPlayer(GameObject player)
    {
        player.transform.localScale = new Vector3(Width * 0.6f, Width * 0.6f, Width * 0.6f); //0.7
        player.transform.position = new Vector3(-5 * plane.transform.localScale.x + player.transform.localScale.x * 0.7f,
            0, -5 *plane.transform.localScale.z + player.transform.localScale.z);
        Instantiate(player);

    }

    public static void SetEnemy(GameObject enemy, int count)
    {
        enemy.transform.localScale = new Vector3(Width * 0.6f, Width * 0.6f, Width * 0.6f);   
        for (int i = 0; i < count; i++)
        {
            Vector3 vector = EmptyTiles[Random.Range(0, EmptyTiles.Count - 1)];
            enemy.transform.position = new Vector3(vector.x, 0, vector.z);
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

    public static void SetSoftBlocks(GameObject softBlock, int number)
    {
        NumberOfSoftBlocks = number;
        softBlock.transform.localScale = new Vector3(Width, Width, Width);
        for (int i = 0; i < NumberOfSoftBlocks; i++)
        {
            int index = Random.Range(0, EmptyTiles.Count - 1);
            Vector3 vector = EmptyTiles[index];
            softBlock.transform.position = new Vector3(EmptyTiles[index].x, Width / 2, EmptyTiles[index].z);
            EmptyTiles.RemoveAt(index);
            Instantiate(softBlock);
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

    // Определить список свободных плиток
    public static void DefineEmptyTiles()
    {
        EmptyTiles = new List<Vector3>();
        float offsetX = 0;
        float offsetY = 0;
        for (int i = 0; i < NumberOfConcreteBlocks; i++)
        {
            for (int j = 0; j < NumberOfConcreteBlocks; j++)
            {
                EmptyTiles.Add(new Vector3(-10 + offsetX + Width / 2, Width * 0.7F + 0.1F, -10 + Width / 2 + offsetY));
                offsetX += 2 * Width;
            }
            offsetX = Width;
            offsetY += 2 * Width;
        }
        EmptyTiles.RemoveAt(0);
    }
}
