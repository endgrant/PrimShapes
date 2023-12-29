using Godot;
using System;


public partial class XpOverlay : Control {
        private ProgressBar progressBar;
        private Label levelDisplay;
        private Label pointsDisplay;


        // Called when the node enters the tree
        public override void _Ready() {
                base._Ready();
                HBoxContainer container = GetNode<HBoxContainer>("HBoxContainer");
                progressBar = container.GetNode<ProgressBar>("ProgressBar");
                levelDisplay = container.GetNode<Label>("CurrentLevel");
                pointsDisplay = container.GetNode<Label>("UnspentPoints");
        }


        // Update the display
        public void Update(float experience, int points) {
                int currentLevel = Globals.GetLevelFromXp(experience);
                progressBar.MinValue = Globals.GetXpFromLevel(currentLevel);
                progressBar.MaxValue = Globals.GetXpFromLevel(currentLevel + 1);
                progressBar.Value = experience;

                levelDisplay.Text = "lvl: " + currentLevel;
                pointsDisplay.Text = "pts: " + points;
        }
}
