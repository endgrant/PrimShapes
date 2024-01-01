using Godot;
using System;

public partial class BodyDmg : Stat {
        public BodyDmg() : base() {}


        public BodyDmg(KinematicEntity owner, int level) : base(owner, level) {}


        // Returns the value of this stat
        public override float GetValue() {
                return 2.0F + 1.0F * level;
        }
}
