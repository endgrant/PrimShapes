using Godot;
using System;


public partial class KinematicEntity : CharacterBody2D, Entity {
        protected struct stats {
                public float maxHealth;
                public float collisionDamage;
                public float projectileDamage;
                public float moveSpeed;
                public float fireRate;
        }

        protected float health;
        protected float experience;
        protected float mass = 10.0F;


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta) {
	}

        public void Impact(Vector2 force, int damage) {
                Velocity = force / (float)Math.Pow(mass, 2);
                MoveAndSlide();
        }

        public float GetMass() {
                return mass;
        }
}
