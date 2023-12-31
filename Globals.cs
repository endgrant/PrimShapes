using Godot;
using System;

public static class Globals {
        public struct Base {
                public const float maxHealth = 20.0F;
                public const float bodyDmg = 2.0F;
                public const float projDmg = 1.0F;
                public const float speed = 1.0F;
                public const float firerate = 1.0F;
        }
        
        public struct Iter {
                public const float health = 10.0F;
                public const float bodyDmg = 1.0F;
                public const float projDmg = 0.5F;
                public const float speed = 0.1F;
                public const float firerate = 0.2F;
        }

        public const float bounceFactor = 0.3F;
        public const string shapesPath = "res://Entity/RigidEntity/Shapes";

        public static bool justUnpaused = false;


        public static float GetHealthFromLevel(int level) {
                return Base.maxHealth + Iter.health * level;
        }


        public static float GetBodyDmgFromLevel(int level) {
                return Base.bodyDmg + Iter.bodyDmg * level;
        }


        public static float GetProjDmgFromLevel(int level) {
                return Base.projDmg + Iter.projDmg * level;
        }


        public static float GetSpeedFromLevel(int level) {
                return Base.speed + Iter.speed * level;
        }


        public static float GetFirerateFromLevel(int level) {
                return Base.firerate + Iter.firerate * level;
        }
        

	public static int GetLevelFromXp(float experience) {
                return (int)Math.Floor(Math.Sqrt((double)experience) / 2.0);
        }


        public static float GetXpFromLevel(int level) {
                return (float)Math.Pow(level * 2.0, 2.0);
        }
}
