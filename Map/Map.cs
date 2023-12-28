using Godot;
using System;


public partial class Map : Node {
	private Player player;
        private Node shapeCollection;


        // Called when the node enters the tree
        public override void _Ready() {
                base._Ready();
                player = GetNode<Player>("Player");
                shapeCollection = GetNode<Node>("Shapes");
        }


        public Player GetPlayer() {
                return player;
        }


        private PackedScene shapeSceneTest = GD.Load<PackedScene>("Entity/RigidEntity/Particles/triangle.tscn");
        // Spawns a new particle shape
        public void SpawnShape() {
                RigidEntity shape = shapeSceneTest.Instantiate<RigidEntity>();
                
        }
}
