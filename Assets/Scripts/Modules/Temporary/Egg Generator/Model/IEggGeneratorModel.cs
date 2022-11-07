using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using static Types;

namespace Collector.EggGenerator
{

    public interface IEggGeneratorModel : IBaseModel
    {
        List<IEggController> EggList { get; }
    }
}