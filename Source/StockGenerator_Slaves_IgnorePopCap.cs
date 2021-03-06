﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using UnityEngine;

namespace Syrchalis_MoreSlaves
{
    public class StockGenerator_Slaves_IgnorePopCap : StockGenerator
    {
        public override IEnumerable<Thing> GenerateThings(int forTile, Faction faction = null)
        {
            int count = MoreSlavesSettings.slaveCount.RandomInRange;
            int num;
            for (int i = 0; i < count; i = num + 1)
            {
                if (!(from fac in Find.FactionManager.AllFactionsVisible
                      where fac != Faction.OfPlayer && fac.def.humanlikeFaction
                      select fac).TryRandomElement(out Faction faction2))
                {
                    yield break;
                }
                PawnGenerationRequest request = PawnGenerationRequest.MakeDefault();
                request.KindDef = slaveKindDef ?? PawnKindDefOf.Slave;
                request.Faction = faction2;
                request.Tile = forTile;
                request.ForceAddFreeWarmLayerIfNeeded = !trader.orbital;
                request.RedressValidator = (Pawn x) => x.royalty == null || !x.royalty.AllTitlesForReading.Any<RoyalTitle>();
                Pawn pawn = PawnGenerator.GeneratePawn(request);
                yield return pawn;
                num = i;
            }
        }

        public override bool HandlesThingDef(ThingDef thingDef)
        {
            return thingDef.category == ThingCategory.Pawn && thingDef.race.Humanlike && thingDef.tradeability > Tradeability.None;
        }

        public PawnKindDef slaveKindDef;
    }
}
