using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using System.Reflection;
using UnityEngine;

namespace Syrchalis_MoreSlaves
{
    public class MoreSlavesSettings : ModSettings
    {
        public static IntRange slaveCount = new IntRange(3, 5);

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look<IntRange>(ref slaveCount, "slaveCount", new IntRange(3, 5) , true);
        }
    }
}
