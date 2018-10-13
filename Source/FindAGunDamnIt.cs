using RimWorld;
using Verse;
using Verse.AI;

namespace FindAGunDamnIt
{
    public class ThinkNode_ConditionalHunter : ThinkNode_Conditional
    {
        protected override bool Satisfied(Pawn pawn)
        {
            bool hunter = pawn.workSettings.WorkIsActive(WorkTypeDefOf.Hunting);
            return pawn.IsColonist && !pawn.Drafted && (hunter && pawn.IsHashIntervalTick(7) || !hunter && pawn.IsHashIntervalTick(257) );
        }
    }

    class JobGiver_PickUpOpportunisticWeapon_Extended : JobGiver_PickUpOpportunisticWeapon
    {
        protected override Job TryGiveJob(Pawn pawn)
        {
            var res = base.TryGiveJob(pawn);
            if (res == null) return null;

            if (res.def != JobDefOf.Equip) return res; //some other mod ?

            var t = (Thing) res.targetA;
            return t.IsForbidden(pawn) ? null : res;
        }
    }
    
    
}