using Godot;
using System;

public partial class ResourceGenerator : RigidBody3D
{
    double time = 2.5f;
    
    [Export] PackedScene resurs;
    [Export] Area3D colloction_zone;
    [Export] Player player;

    public Godot.Collections.Array array = new Godot.Collections.Array();

    private bool playerInside = false;
    public override void _Ready()
	{
        colloction_zone.BodyEntered += entered;
        colloction_zone.BodyExited += exited;

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        
        time -= delta;
        GD.Print("time to spawn");
        if (time <= 0.0f)
        {
            RigidBody3D buy = resurs.Instantiate<RigidBody3D>();
            //buy.GlobalPosition = GlobalPosition;
            buy.Visible = false;
            GD.Print("spawned");

            array.Add(buy);
            GD.Print("addid on array");

            time = 2.5f;

        }

        if (playerInside && Input.IsActionJustPressed("Hey"))
        {
            foreach (var item in array)
            {
                player.player_inv.Add(item);
            }

            array.Clear();
        }
    }

    void entered(Node3D Body)
    {
        if (Body is CharacterBody3D)
        {
              playerInside = true;

        }
        
    }
    void exited(Node3D Body) 
    {
        if(Body is CharacterBody3D)
        {
            playerInside = false;
        }
    }

}
