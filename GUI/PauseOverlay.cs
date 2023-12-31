using Godot;
using System;

public partial class PauseOverlay : Control
{
        private Label pointsLabel;

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


        public void SetPoints(int points) {
                this.points = points;
                pointsLabel.Text = "Points: " + this.points;
        }
}
