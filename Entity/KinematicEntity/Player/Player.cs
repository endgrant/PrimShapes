using Godot;
using System;


public partial class Player : KinematicEntity {
        private float topSpeed = 512.0F;
        private float acceleration = 0.2F;


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta) {
                Vector2 inputVector = new Vector2 {
                        X = Input.GetAxis("MoveLeft", "MoveRight"),
                        Y = Input.GetAxis("MoveUp", "MoveDown")
                };

                Velocity = Velocity.Lerp(inputVector * topSpeed, acceleration);

                MoveAndSlide();
	}
}
