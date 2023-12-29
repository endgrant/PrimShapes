using Godot;
using System;
using System.Numerics;


public interface Entity {
        public float GetMass();
        public float GetCollisionDamage();
        public void HeavyImpact(Godot.Vector2 force, float damage);
        public void LightImpact(Godot.Vector2 force, float damage);
        public void Destroy();
}
