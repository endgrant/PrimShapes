using Godot;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;


public partial class Map : Node {
	private Player player;
        private Node shapeCollection;
        private XpOverlay xpOverlay;

        private Godot.Vector2 bounds;
        private List<PackedScene> shapeScenes = new();
        private List<int> spawnChances = new();
        private int totalSpawnChance = 0;


        // Called when the node enters the tree
        public override void _Ready() {
                base._Ready();
                player = GetNode<Player>("Player");
                shapeCollection = GetNode<Node>("Shapes");
                xpOverlay = GetNode("CanvasLayer").GetNode<XpOverlay>("XpOverlay");

                Node2D playArea = GetNode<Node2D>("PlayArea");
                ColorRect rect = playArea.GetNode<ColorRect>("ColorRect");
                bounds = new Godot.Vector2 {
                        X = rect.Size.X * playArea.Scale.X,
                        Y = rect.Size.Y * playArea.Scale.Y
                };

                List<string> shapeFiles = new List<string>(DirAccess.GetFilesAt(Globals.shapesPath));
                foreach (string file in shapeFiles) {
                        shapeScenes.Add(GD.Load<PackedScene>(Globals.shapesPath + "/" + file));
                }


                foreach(PackedScene scene in shapeScenes) {
                        RigidEntity shape = (RigidEntity)scene.Instantiate();
                        shapeCollection.AddChild(shape);
                        int spawnChance = shape.GetSpawnChance();
                        spawnChances.Add(spawnChance);
                        totalSpawnChance += spawnChance;
                        shape.QueueFree();
                }


                for(int i = 0; i < 300; i++)
                        SpawnShape();
        }


        public Player GetPlayer() {
                return player;
        }


        public void UpdateXpOverlay() {
                xpOverlay.Update(GetPlayer().GetXp(), GetPlayer().GetPoints());
        }


        // Spawns a new particle shape
        public void SpawnShape() {
                Random random = new();
                int type = (int)(random.NextInt64() % totalSpawnChance);

                int selector = 0;
                int i = 0;
                while(true) {
                        selector += spawnChances[i];
                        if(type < selector)
                                break;
                        i++;
                }

                RigidEntity shape = shapeScenes[i].Instantiate<RigidEntity>();

                Godot.Vector2 randCoords = new Godot.Vector2 {
                        X = (float)random.NextDouble() * bounds.X,
                        Y = (float)random.NextDouble() * bounds.Y,
                };

                shape.Position = randCoords - bounds / 2;
                shape.AssignMap(this);
                shapeCollection.AddChild(shape);
        }
}
