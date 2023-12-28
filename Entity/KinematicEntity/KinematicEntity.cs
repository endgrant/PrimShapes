using Godot;
using System;


public partial class KinematicEntity : CharacterBody2D, Entity {
        [ExportCategory("Attributes")]
        [Export(PropertyHint.Range, "0, 100000")] float maxHealth;
        [Export(PropertyHint.Range, "0, 100000")] float collisionDamage;
        [Export(PropertyHint.Range, "0, 100000")] float projectileDamage;
        [Export(PropertyHint.Range, "0, 100000")] float moveSpeed;
        [Export(PropertyHint.Range, "0, 100000")] float fireRate;

        protected float health;
        protected float experience;
        protected float mass = 10.0F;


        // Called when the node enters the tree
        public override void _Ready() {
                base._Ready();
                health = maxHealth;
        }


        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _PhysicsProcess(double delta) {
	}


        public float GetCollisionDamage() {
                return collisionDamage;
        }


        public float GetMass() {
                return mass;
        }

        // Collide with entity
        public void Impact(Vector2 force, float damage) {
                Velocity = force / (float)Math.Pow(mass, 2);
                MoveAndSlide();
        }


        // Destroy this entity
        public void Destroy() {
                
        }
}
