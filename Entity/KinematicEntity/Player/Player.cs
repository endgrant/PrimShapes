using Godot;
using System;
// Player.cs
// Control for the player object


public partial class Player : KinematicEntity, Entity {
        [Signal] public delegate void XpChangedEventHandler(float experience);
        [Signal] public delegate void LevelChangedEventHandler(int level, int points);

        private int unspentPoints = 0;

        private float topSpeed = 500.0F;
        private float acceleration = 2.0F;


        // Called when the node enters the tree for the first time
        public override void _Ready() {
                base._Ready();
        }


        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _PhysicsProcess(double delta) {
                health = maxHealth;
                Vector2 inputVector = new Vector2 {
                        X = Input.GetAxis("MoveLeft", "MoveRight"),
                        Y = Input.GetAxis("MoveUp", "MoveDown")
                };

                Velocity = Velocity.MoveToward(inputVector.Normalized() * topSpeed, (float)(acceleration * delta * 1000));

                MoveAndSlide();
                base._PhysicsProcess(delta);
	}


        public float GetXp() {
                return experience;
        }


        public int GetPoints() {
                return unspentPoints;
        }
        

        // Award experience points to the entity
        public void AwardXP(float experience) {
                int currentLevel = Globals.GetLevelFromXp(this.experience);
                this.experience += experience;
                int newLevel = Globals.GetLevelFromXp(this.experience);

                EmitSignal(SignalName.XpChanged, experience);

                // New level reached
                if (newLevel > currentLevel) {
                        LevelUp(newLevel, currentLevel);
                }
        }


        // Entity reached new level
        private void LevelUp(int newLevel, int prevLevel) {
                unspentPoints += newLevel - prevLevel;
                EmitSignal(SignalName.LevelChanged, newLevel, unspentPoints);
        }
}
