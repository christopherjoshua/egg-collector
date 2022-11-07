using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using static Types;

namespace Collector.EggGenerator
{
    public class EggGeneratorModel : BaseModel, IEggGeneratorModel
    {
        public List<IEggController> EggList { get; private set; }

        public void UpdateEggList(List<IEggController> newEggList)
        {
            EggList = newEggList;
            SetDataAsDirty();
        }
    }
}
