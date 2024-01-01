using Godot;


public partial class Enemy : KinematicEntity {
        [ExportCategory("Spawn Stats")]
        [Export(PropertyHint.Range, "0, " + Globals.maxStatLevel)] protected int healthLvl;
        [Export(PropertyHint.Range, "0, " + Globals.maxStatLevel)] protected int bodyDmgLvl;
        [Export(PropertyHint.Range, "0, " + Globals.maxStatLevel)] protected int projDmgLvl;
        [Export(PropertyHint.Range, "0, " + Globals.maxStatLevel)] protected int speedLvl;
        [Export(PropertyHint.Range, "0, " + Globals.maxStatLevel)] protected int firerateLvl;


        // Called when the node enters the tree
        public override void _Ready() {
                statHealth = new(this, healthLvl);
                statBodyDmg = new(this, bodyDmgLvl);
                statProjDmg = new(this, projDmgLvl);
                statSpeed = new(this, speedLvl);
                statFirerate = new(this, firerateLvl);
                
                base._Ready();
        }
}