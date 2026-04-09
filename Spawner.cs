using Godot;
using System;

public partial class Spawner : Node3D
{
	[Export] PackedScene resurs;
    [Export] int amount = 20;

  

    public override void _Ready()
	{

        Spawn();
         
	}


    void Spawn()
    {
        if (resurs == null)
        {
            GD.Print("no resurs");
            return;
        }
        for (int i  = 0; i < amount; i++)
        {
            RigidBody3D instance = resurs.Instantiate<RigidBody3D>();

            AddChild(instance);


            instance.GlobalPosition = GetParent<Node3D>().GlobalPosition;
        }
        


    }


}
