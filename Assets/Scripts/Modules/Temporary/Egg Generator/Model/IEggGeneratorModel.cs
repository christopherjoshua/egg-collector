using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

namespace Collector.EggGenerator
{

    public interface IEggGeneratorModel : IBaseModel
    {
        List<EggController> EggList { get; }
    }
}