using Godot;
using System;

public partial class Stat : VBoxContainer {
        protected PauseOverlay pause;
        protected KinematicEntity entity;

        protected int level = 0;

        protected Button button;


        public Stat() {}
        

        public Stat(KinematicEntity owner, int level) {
                entity = owner;
                this.level = level;
        }


        public void Init(KinematicEntity owner) {
                entity = owner;
        }


        public override void _Ready() {
                base._Ready();

                if (entity is Player) {
                        Player player = (Player)entity;
                        pause = player.GetPause();
                        button = GetNode<Button>("Button");
                        UpdateLabel();
                }
        }


        protected void UpdateLabel() {
                button.Text = Convert.ToString(level);
        }


        // User clicked upgrade button
        public void ButtonPressed() {
                if (pause.GetPoints() <= 0) {
                        return;
                }

                if (level >= int.Parse(Globals.maxStatLevel)) {
                        return;
                }

                pause.SetPoints(pause.GetPoints() - 1);
                level++;
                UpdateLabel();
        }


        // Returns the value of this stat
        public virtual float GetValue() {
                return 0.0F;
        }
}
