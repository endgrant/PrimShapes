using Godot;
using System;
// Player.cs
// Control for the player object


public partial class Player : KinematicEntity, Entity {        
        private PauseOverlay pauseOverlay;

        private int unspentPoints = 0;

        private float topSpeed = 500.0F;
        private float acceleration = 2.0F;


        // Called when the node enters the tree for the first time
        public override async void _Ready() {
                await ToSignal(GetTree().Root.GetChild(0), SignalName.Ready);

                statHealth = pauseOverlay.CreateStatButton<Health>(this, "health.tscn");
                statBodyDmg = pauseOverlay.CreateStatButton<BodyDmg>(this, "body_dmg.tscn");
                statProjDmg = pauseOverlay.CreateStatButton<ProjDmg>(this, "proj_dmg.tscn");
                statSpeed = pauseOverlay.CreateStatButton<Speed>(this, "speed.tscn");
                statFirerate = pauseOverlay.CreateStatButton<Firerate>(this, "firerate.tscn", true);
                
                base._Ready();
        }


        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _PhysicsProcess(double delta) {
                Vector2 inputVector = new Vector2 {
                        X = Input.GetAxis("MoveLeft", "MoveRight"),
                        Y = Input.GetAxis("MoveUp", "MoveDown")
                };

                Velocity = Velocity.MoveToward(inputVector.Normalized() * topSpeed * statSpeed.GetValue(), 
                        (float)(acceleration * delta * 1000));

                MoveAndSlide();
                base._PhysicsProcess(delta);
	}


        public void AssignPause(PauseOverlay pause) {
                pauseOverlay = pause;
        }


        public PauseOverlay GetPause() {
                return pauseOverlay;
        }


        public float GetXp() {
                return experience;
        }


        public int GetPoints() {
                return unspentPoints;
        }


        public void SetPoints(int points) {
                unspentPoints = points;
        }
        

        // Award experience points to the entity
        public void AwardXP(float experience) {
                int currentLevel = Globals.GetLevelFromXp(this.experience);
                this.experience += experience;
                int newLevel = Globals.GetLevelFromXp(this.experience);

                // New level reached
                if (newLevel > currentLevel) {
                        LevelUp(newLevel, currentLevel);
                }
        }


        // Entity reached new level
        private void LevelUp(int newLevel, int prevLevel) {
                unspentPoints += newLevel - prevLevel;
        }
}
