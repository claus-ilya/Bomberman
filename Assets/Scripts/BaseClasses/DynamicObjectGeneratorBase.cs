using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DynamicObjectGeneratorBase
{
    public abstract GameObject GetPlayer();

    public abstract GameObject GetKnight();

    public abstract GameObject GetCapsuleEnemy();

    public abstract GameObject GetDinosaurEnemy();
}
