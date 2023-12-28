using Godot;
using System;


public interface Entity {
        public float GetMass();
        float GetCollisionDamage();
        void Impact(Vector2 force, float damage);
        void Destroy();
}
