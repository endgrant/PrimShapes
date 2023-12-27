using Godot;
using System;

public static class Globals
{
	public static int GetLevelFromXP(float experience) {
                return (int)Math.Floor(Math.Sqrt((double)experience) / 2.0);
        }
}
