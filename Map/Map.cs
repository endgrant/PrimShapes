using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


public partial class Map : Node {
	private Player player;
        private Node shapeCollection;
        private XpOverlay xpOverlay;

        private Vector2 bounds;
        private List<PackedScene> shapeScenes = new();


        // Called when the node enters the tree
        public override void _Ready() {
                base._Ready();
                player = GetNode<Player>("Player");
                shapeCollection = GetNode<Node>("Shapes");
                xpOverlay = GetNode("CanvasLayer").GetNode<XpOverlay>("XpOverlay");

                Node2D playArea = GetNode<Node2D>("PlayArea");
                ColorRect rect = playArea.GetNode<ColorRect>("ColorRect");
                bounds = new Vector2 {
                        X = rect.Size.X * playArea.Scale.X,
                        Y = rect.Size.Y * playArea.Scale.Y
                };

                List<string> shapeFiles = new List<string>(DirAccess.GetFilesAt(Globals.shapesPath));
                foreach (string file in shapeFiles) {
                        shapeScenes.Add(GD.Load<PackedScene>(Globals.shapesPath + "/" + file));
                }

                int i = 0;
                while (i < 120) {
                        i++;
                        SpawnShape();
                }
        }


        public Player GetPlayer() {
                return player;
        }


        public void UpdateXpOverlay() {
                xpOverlay.Update(GetPlayer().GetXp());
        }


        // Spawns a new particle shape
        public void SpawnShape() {
                Random random = new();

                RigidEntity shape = shapeScenes[random.Next() % shapeScenes.Count].Instantiate<RigidEntity>();

                Vector2 randCoords = new Vector2 {
                        X = (float)random.NextDouble() * bounds.X,
                        Y = (float)random.NextDouble() * bounds.Y,
                };

                shape.Position = randCoords - bounds / 2;
                shape.AssignMap(this);
                shapeCollection.AddChild(shape);
        }
}
