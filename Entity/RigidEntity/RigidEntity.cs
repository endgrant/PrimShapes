using Godot;
using System;

public partial class RigidEntity : RigidBody2D, Entity {
    [ExportCategory("Attributes")]
    [Export(PropertyHint.Range, "0, 100000")] int health;
    [Export(PropertyHint.Range, "0, 100000")] int contactDamage;
    [Export(PropertyHint.Range, "0, 100000")] int experience;

    public void Impact(Vector2 force, int damage) {
        ApplyCentralImpulse(force);
    }

    public float GetMass() {
        return Mass;
    }
}