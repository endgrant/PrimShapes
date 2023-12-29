using Godot;
using System;

public partial class RigidEntity : RigidBody2D, Entity {
        [ExportCategory("Attributes")]
        [Export(PropertyHint.Range, "0, 100000")] float maxHealth;
        [Export(PropertyHint.Range, "0, 100000")] float collisionDamage;
        [Export(PropertyHint.Range, "0, 100000")] int xpValue;
        [Export(PropertyHint.Range, "0, 100")] int spawnChance = 50;

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


        public int GetSpawnChance() {
                return spawnChance;
        }


        public Vector2 GetVelocity() {
                return LinearVelocity;
        }


        public void AssignMap(Map map) {
                this.map = map;
        } 


        // Applies an impulse to the body
        public void Impact(Vector2 force, float damage) {
                health -= damage;
                if (health <= 0) {
                        Destroy();
                }

                ApplyCentralImpulse(force);
        }


        // Destroy this entity
        public void Destroy() {
                map.GetPlayer().AwardXP(xpValue);
                map.UpdateXpOverlay();
                QueueFree();
        }
}