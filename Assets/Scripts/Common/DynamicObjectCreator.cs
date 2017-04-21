using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObjectCreator : DynamicObjectGeneratorBase
{

    public override GameObject GetPlayer()
    {
        return (GameObject)Resources.Load("Prefabs/Player/Capsule", typeof(GameObject));
    }

    public override GameObject GetCapsuleEnemy()
    {
        return (GameObject)Resources.Load("Prefabs/Enemies/Enemy", typeof(GameObject));
    }

    public override GameObject GetKnight()
    {
        return (GameObject)Resources.Load("Knight/prefabs/knightprefab", typeof(GameObject));
    }

    public override GameObject GetDinosaurEnemy()
    {
        return (GameObject)Resources.Load("Allosaurus/Prefabs/Allosaurus_01", typeof(GameObject));
    }


}
