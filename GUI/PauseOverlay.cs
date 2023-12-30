using Godot;
using System;

public partial class PauseOverlay : Control
{
        // User input received
        public override void _Input(InputEvent @event) {
                if (@event.IsActionPressed("Pause")) {
                        GetTree().Paused = false;
                        Visible = false;
                        Globals.justUnpaused = true;
                }

                base._Input(@event);
        }
}
