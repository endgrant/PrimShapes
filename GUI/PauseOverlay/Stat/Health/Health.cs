using Godot;
using System;
using System.IO;

public partial class Health : Stat {
        public Health() : base() {}


        public Health(KinematicEntity owner, int level) : base(owner, level) {}
        

        // Returns the value of this stat
        public override float GetValue() {
                return 20.0F + 10.0F * level;
        }
}
