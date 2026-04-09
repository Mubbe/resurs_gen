using Godot;
using System;
using static Godot.HttpRequest;

public partial class Resurs : RigidBody3D
{
    [Export] Area3D Collect;

    private bool playerInside = false;

    public override void _Ready()
    {
        Collect.BodyEntered += Entered;
        Collect.BodyExited += Exited;
    }

    void Entered(Node3D body)
    {
        if (body is CharacterBody3D)
        {
            playerInside = true;
        }
    }

    void Exited(Node3D body)
    {
        if (body is CharacterBody3D)
        {
            playerInside = false;
        }
    }

    public override void _Process(double delta)
    {
        if (playerInside && Input.IsActionJustPressed("Hey"))
        {
            GD.Print("Collected!");
            QueueFree(); 
        }
    }
}

