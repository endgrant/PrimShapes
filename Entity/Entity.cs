using Godot;
using System;


public interface Entity {
    public float GetMass();
    void Impact(Vector2 force, int damage);
}
