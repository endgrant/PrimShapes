using Godot;
using System;


public partial class KinematicEntity : CharacterBody2D, Entity {
        [ExportCategory("Attributes")]
        [Export(PropertyHint.Range, "0, 100000")] protected float maxHealth;
        [Export(PropertyHint.Range, "0, 100000")] float collisionDamage;
        [Export(PropertyHint.Range, "0, 100000")] float projectileDamage;
        [Export(PropertyHint.Range, "0, 100000")] float moveSpeed;
        [Export(PropertyHint.Range, "0, 100000")] float fireRate;

        protected float health;
        protected float experience;
        protected float mass = 50.0F;


        // Called when the node enters the tree
        public override void _Ready() {
                base._Ready();
                health = maxHealth;
        }


        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _PhysicsProcess(double delta) {
                for(int i = 0; i < GetSlideCollisionCount(); i++) {
                        GodotObject collider = GetSlideCollision(i).GetCollider();
                        if(collider is Entity) {
                                Entity entity = (Entity)collider;
                                entity.Impact(mass * (Velocity - entity.GetVelocity()) * (1 + GetCollisionDamage() * 0.1F) * Globals.bounceFactor, GetCollisionDamage());
                                Impact(entity.GetMass() * (-Velocity + entity.GetVelocity()) * (1 + entity.GetCollisionDamage() * 0.1F) * Globals.bounceFactor, entity.GetCollisionDamage());
                        }
                }
	}


        public float GetCollisionDamage() {
                return collisionDamage;
        }


        public float GetMass() {
                return mass;
        }


        public Vector2 GetVelocity() {
                return Velocity;
        }

        // Collide with entity
        public void Impact(Vector2 force, float damage) {
                Velocity = force / mass;
                MoveAndSlide();
        }

        public void Recoil(Vector2 force, float damage) {
                Velocity += force / mass;
                MoveAndSlide();
        }


        // Destroy this entity
        public void Destroy() {
                
        }
}
