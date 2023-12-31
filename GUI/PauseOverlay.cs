using Godot;
using System;

public partial class PauseOverlay : Control
{
        private Label pointsLabel;

        private Player player;

        private int points = 0;


        // Entered the tree for the first time
        public override void _Ready() {
                base._Ready();

                pointsLabel = GetNode("VBoxContainer").GetNode<Label>("PointsLabel");
        }


        // User input received
        public override void _Input(InputEvent @event) {
                if (@event.IsActionPressed("Pause")) {
                        GetTree().Paused = false;
                        Visible = false;
                        Globals.justUnpaused = true;
                }

                base._Input(@event);
        }


        public void AssignPlayer(Player player) {
                this.player = player;
        }


        public void SetPoints(int points) {
                this.points = points;
                pointsLabel.Text = "Points: " + this.points;
        }


        public void HealthUpgrade() {

        }


        public void BodyDmgUpgrade() {

        }


        public void ProjDmgUpgrade() {

        }


        public void SpeedUpgrade() {

        }


        public void FirerateUpgrade() {

        }
}
