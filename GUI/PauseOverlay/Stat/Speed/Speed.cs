using Godot;
using System;

public partial class Speed : Stat {
        public Speed() : base() {}


        public Speed(KinematicEntity owner, int level) : base(owner, level) {}


        // Returns the value of this stat
        public override float GetValue() {
                return 1.0F + 0.1F * level;
        }
}
