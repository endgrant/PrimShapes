using Godot;
using System;

public partial class Firerate : Stat {
        public Firerate() : base() {}


        public Firerate(KinematicEntity owner, int level) : base(owner, level) {}


        // Returns the value of this stat
        public override float GetValue() {
                return 1.0F + 0.2F * level;
        }
}
