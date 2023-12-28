using Godot;
using System;

public partial class RigidEntity : RigidBody2D, Entity {
        [ExportCategory("Attributes")]
        [Export(PropertyHint.Range, "0, 100000")] float maxHealth;
        [Export(PropertyHint.Range, "0, 100000")] float collisionDamage;
        [Export(PropertyHint.Range, "0, 100000")] int xpValue;

        protected float health;

        protected Map map;


        // Called when the node enters the tree
        public override void _Ready() {
                base._Ready();
                health = maxHealth;        
        }


        public float GetCollisionDamage() {
                return collisionDamage;
        }


        public float GetMass() {
                return Mass;
        }


        // Applies an impulse to the body
        public void Impact(Vector2 force, float damage) {
                ApplyCentralImpulse(force);
        }


        // Destroy this entity
        public void Destroy() {
                
        }
}