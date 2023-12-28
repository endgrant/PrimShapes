using Godot;
using System;
using System.Runtime.CompilerServices;


public partial class Map : Node {
	private Player player;
        private Node shapeCollection;
        private Vector2 bounds;


        // Called when the node enters the tree
        public override void _Ready() {
                base._Ready();
                player = GetNode<Player>("Player");
                shapeCollection = GetNode<Node>("Shapes");
                Node2D playArea = GetNode<Node2D>("PlayArea");
                ColorRect rect = playArea.GetNode<ColorRect>("ColorRect");
                bounds = new Vector2 {
                        X = rect.Size.X * playArea.Scale.X,
                        Y = rect.Size.Y * playArea.Scale.Y
                };

                int i = 0;
                while (i < 100) {
                        i++;
                        SpawnShape(false);
                }
        }


        public Player GetPlayer() {
                return player;
        }


        private PackedScene shapeSceneTest = GD.Load<PackedScene>("Entity/RigidEntity/Shapes/triangle.tscn");
        // Spawns a new particle shape
        public void SpawnShape(bool hidden) {
                RigidEntity shape = shapeSceneTest.Instantiate<RigidEntity>();
                Viewport viewport = GetPlayer().GetViewport();
                Rect2 extents = viewport.GetVisibleRect();
                Vector2 randCoords = extents.Position;
                Random random = new();

                if (hidden) {
                         // Sample random positions until finding one outside the viewport extents
                        int i = 0;
                        while (extents.HasPoint(randCoords)) {
                                i++;
                                if (i > 10) {
                                        return;
                                }

                                randCoords = new Vector2 {
                                        X = (float)random.NextDouble() * bounds.X,
                                        Y = (float)random.NextDouble() * bounds.Y,
                                };
                        }
                }  else {
                        randCoords = new Vector2 {
                                X = (float)random.NextDouble() * bounds.X,
                                Y = (float)random.NextDouble() * bounds.Y,
                        };
                }

                shape.Position = randCoords - bounds / 2;
                shapeCollection.AddChild(shape);
        }
}