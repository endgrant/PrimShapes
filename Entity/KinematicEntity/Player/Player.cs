using Godot;
using System;
// Player.cs
// Control for the player object


public partial class Player : KinematicEntity, Entity {
        [Signal] public delegate void XpChangedEventHandler(float experience);
        [Signal] public delegate void LevelChangedEventHandler(int level, int points);

        private int unspentPoints = 0;

        private float topSpeed = 2000.0F;

        private float acceleration = 0.5F;


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta) {
                Vector2 inputVector = new Vector2 {
                        X = Input.GetAxis("MoveLeft", "MoveRight"),
                        Y = Input.GetAxis("MoveUp", "MoveDown")
                };

                Velocity = Velocity.Lerp(inputVector.Normalized() * topSpeed, (float)(acceleration * delta));

                MoveAndSlide();

                for(int i = 0; i < GetSlideCollisionCount(); i++) {
                        KinematicCollision2D collision = GetSlideCollision(i);
                        if(collision.GetCollider() is Entity) {
                                ((Entity)collision.GetCollider()).Impact(mass * Velocity, 0);
                                Impact(((Entity)collision.GetCollider()).GetMass() * Velocity * -1, 0);
                        }

                }
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
                EmitSignal(SignalName.LevelChanged, newLevel, unspentPoints);
        }


}
