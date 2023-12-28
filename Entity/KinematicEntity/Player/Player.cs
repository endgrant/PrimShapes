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
                base._Ready();
                Vector2 inputVector = new Vector2 {
                        X = Input.GetAxis("MoveLeft", "MoveRight"),
                        Y = Input.GetAxis("MoveUp", "MoveDown")
                };

                Velocity = Velocity.MoveToward(inputVector.Normalized() * topSpeed, (float)(acceleration * delta * 1000));

                MoveAndSlide();

                for(int i = 0; i < GetSlideCollisionCount(); i++) {
                        GodotObject collider = GetSlideCollision(i).GetCollider();
                        if(collider is Entity) {
                                Entity entity = (Entity)collider;
                                entity.Impact(mass * Velocity, GetCollisionDamage());
                                Impact(entity.GetMass() * Velocity * -1, entity.GetCollisionDamage());
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
