using Godot;
using System;

public static class Globals {
        public const float bounceFactor = 0.25F;
        public const string shapesPath = "res://Entity/RigidEntity/Shapes";


	public static int GetLevelFromXP(float experience) {
                return (int)Math.Floor(Math.Sqrt((double)experience) / 2.0);
        }
}
