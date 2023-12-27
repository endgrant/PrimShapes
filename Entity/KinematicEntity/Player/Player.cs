using Godot;
using System;
// Player.cs
// Control for the player object


public partial class Player : KinematicEntity {
        [Signal] public delegate void XpChangedEventHandler(float experience);
        [Signal] public delegate void LevelUpEventHandler(int level, int points);

        private int unspentPoints = 0;

        private float topSpeed = 512.0F;
        private float acceleration = 0.2F;


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta) {
                Vector2 inputVector = new Vector2 {
                        X = Input.GetAxis("MoveLeft", "MoveRight"),
                        Y = Input.GetAxis("MoveUp", "MoveDown")
                };

                Velocity = Velocity.Lerp(inputVector * topSpeed, acceleration);

                MoveAndSlide();
	}


        // Award experience points to the entity
        public void AwardXP(float experience) {
                int currentLevel = Globals.GetLevelFromXP(this.experience);
                this.experience += experience;
                int newLevel = Globals.GetLevelFromXP(this.experience);

                EmitSignal(SignalName.XpChanged, experience);

                // New level reached
                if (newLevel > currentLevel) {
                        LevelUp(newLevel, currentLevel);
                }
        }


        // Entity reached new level
        private void LevelUp(int newLevel, int prevLevel) {
                unspentPoints += newLevel - prevLevel;
                EmitSignal(SignalName.LevelUp, newLevel, unspentPoints);
        }
}
