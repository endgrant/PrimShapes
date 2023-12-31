using Godot;
using System;

public static class Globals {
        public const float bounceFactor = 0.3F;
        public const string shapesPath = "res://Entity/RigidEntity/Shapes";

        public static bool justUnpaused = false;


	public static int GetLevelFromXp(float experience) {
                return (int)Math.Floor(Math.Sqrt((double)experience) / 2.0);
        }


        public static float GetXpFromLevel(int level) {
                return (float)Math.Pow(level * 2.0, 2.0);
        }
}
