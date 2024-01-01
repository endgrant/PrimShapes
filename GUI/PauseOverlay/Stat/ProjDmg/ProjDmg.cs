using Godot;
using System;

public partial class ProjDmg : Stat {
        public ProjDmg() : base() {}


        public ProjDmg(KinematicEntity owner, int level) : base(owner, level) {}


        // Returns the value of this stat
        public override float GetValue() {
                return 1.0F + 0.5F * level;
        }
}
