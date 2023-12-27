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


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta) {
	}
}
