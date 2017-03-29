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

    public override GameObject GetEnemy()
    {
        throw new NotImplementedException();
    }
}
