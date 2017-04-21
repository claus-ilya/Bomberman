using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    public abstract class StaticObjectGeneratorBase
    {

        public abstract GameObject GetPlane();
        public abstract GameObject GetConcreteBlock();
        public abstract GameObject GetSoftBlock();
        public abstract GameObject GetWall();
        public abstract GameObject GetBomb();
}

