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
    public class MoreSlaves : Mod
    {
        public static MoreSlavesSettings settings;

        public MoreSlaves(ModContentPack content) : base(content)
        {
            settings = GetSettings<MoreSlavesSettings>();
        }

        public override string SettingsCategory() => "MoreSlavesSettingsLabel".Translate();

        public override void DoSettingsWindowContents(Rect inRect)
        {
            checked
            {
                Listing_Standard listing_Standard = new Listing_Standard();
                listing_Standard.Begin(inRect);
                listing_Standard.Label("MoreSlavesSettingSlaveCount".Translate(), tooltip: "MoreSlavesSettingsSlaveCountTooltip".Translate());
                listing_Standard.IntRange(ref MoreSlavesSettings.slaveCount, 0, 20);
                listing_Standard.End();
                settings.Write();
            }
        }

        public override void WriteSettings()
        {
            base.WriteSettings();
        }
    }
}
