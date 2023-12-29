using Godot;
using System;
using System.Numerics;


public interface Entity {
        public float GetMass();
        public float GetCollisionDamage();
        public void Impact(Godot.Vector2 force, float damage);
        public void Destroy();
        public Godot.Vector2 GetVelocity();
}
