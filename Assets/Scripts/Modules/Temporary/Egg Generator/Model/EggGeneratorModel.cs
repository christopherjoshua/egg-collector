using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
namespace Collector.EggGenerator
{
    public class EggGeneratorModel : BaseModel, IEggGeneratorModel
    {
        public List<EggController> EggList { get; private set; }

        public void UpdateEggList(List<EggController> newEggList)
        {
            EggList = newEggList;
            SetDataAsDirty();
        }
    }
}
