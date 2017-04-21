using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    public class StaticObjectCreator : StaticObjectGeneratorBase
{
    public override GameObject GetPlane()
    {
        return (GameObject)Resources.Load("Prefabs/Blocks/Field", typeof(GameObject));
    }

    public override GameObject GetConcreteBlock()
    {
        return (GameObject)Resources.Load("Prefabs/Blocks/ConcreteBlock", typeof(GameObject));
    }

    public override GameObject GetSoftBlock()
    {
        return (GameObject)Resources.Load("Prefabs/Blocks/SoftBlock", typeof(GameObject));
    }

    public override GameObject GetWall()
    {
        return (GameObject)Resources.Load("Prefabs/Walls/Wall", typeof(GameObject));
    }

    public override GameObject GetBomb()
    {
        return (GameObject)Resources.Load("Prefabs/Bombs/Bomb", typeof(GameObject));
    }
}

