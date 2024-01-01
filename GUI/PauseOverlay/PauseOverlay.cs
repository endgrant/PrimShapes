using Godot;
using System;

public partial class PauseOverlay : Control {
        private HBoxContainer statContainer;
        private Label pointsLabel;

        private Map map;
        private Player player;

        private int points = 0;


        // Entered the tree for the first time
        public override void _Ready() {
                base._Ready();

                VBoxContainer mainContainer = GetNode<VBoxContainer>("VBoxContainer");
                pointsLabel = mainContainer.GetNode<Label>("PointsLabel");
                statContainer = mainContainer.GetNode<HBoxContainer>("HBoxContainer");                
        }


        public T CreateStatButton<T>(Player player, string path, bool last = false) where T : Stat {
                PackedScene statScene = GD.Load<PackedScene>(Globals.statsPath + "/" + typeof(T).ToString() + "/" + path);
                Stat stat = statScene.Instantiate<Stat>();
                stat.Init(player);

                statContainer.AddChild(stat);
                if (!last) {
                        Control spacer = new() {
                                Name = "Spacer" + stat.Name,
                                CustomMinimumSize = new Vector2(128, 0)
                        };
                        statContainer.AddChild(spacer);
                }

                return (T)stat;
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


        public void AssignMap(Map map) {
                this.map = map;
        }


        public void AssignPlayer(Player player) {
                this.player = player;
        }


        public int GetPoints() {
                return points;
        }


        public void SetPoints(int points) {
                this.points = points;
                player.SetPoints(this.points);
                map.UpdateXpOverlay();
                pointsLabel.Text = "Points: " + this.points;
        }
}
