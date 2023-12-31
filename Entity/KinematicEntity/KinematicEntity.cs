using Godot;
using System;


public partial class KinematicEntity : CharacterBody2D, Entity {
        protected Health statHealth;
        protected BodyDmg statBodyDmg;
        protected ProjDmg statProjDmg;
        protected Speed statSpeed;
        protected Firerate statFirerate;

        protected float health;
        protected float experience;
        protected float mass = 50.0F;


        // Called when the node enters the tree
        public override void _Ready() {
                base._Ready();

                health = statHealth.GetValue();
        }


        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _PhysicsProcess(double delta) {
                for(int i = 0; i < GetSlideCollisionCount(); i++) {
                        GodotObject collider = GetSlideCollision(i).GetCollider();
                        if(collider is Entity) {
                                Entity entity = (Entity)collider;
                                Vector2 direction = (GetPosition() - entity.GetPosition()).Normalized();
                                float force = (GetVelocity() * GetMass() + entity.GetVelocity() * entity.GetMass()).Length() + 50;
                                entity.Impact(-direction * force * (1 + GetCollisionDamage() * 0.1F) * Globals.bounceFactor, 
                                        GetCollisionDamage() * GetVelocity().Length() / (Globals.bounceFactor * 1000));
                                Impact(direction * force * (1 + entity.GetCollisionDamage() * 0.1F) * Globals.bounceFactor, 
                                        entity.GetCollisionDamage() * entity.GetVelocity().Length() / (Globals.bounceFactor * 1000));
                        }
                }
	}


        public float GetCollisionDamage() {
                return statBodyDmg.GetValue();
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
        }


        public void Recoil(Vector2 force, float damage) {
                Velocity += force / mass;
        }


        // Destroy this entity
        public void Destroy() {
                
        }


        public Vector2 GetPosition() {
                return Position;
        }
}
