using Godot;
using System;
using System.Net.Http;

public class Node2D : Godot.Node2D {
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override async void _Ready() {
        HttpClient client = new HttpClient();
        HttpResponseMessage msg;

        try {
            msg = await client.SendAsync(new HttpRequestMessage(
                HttpMethod.Get,
                "http://google.com/"
            ));
        } catch (Exception error) {
            ((TextEdit)GetNode("TextEdit")).Text = "error! " + error.ToString();
            return;
        }
    
        ((TextEdit)GetNode("TextEdit")).Text = await msg.Content.ReadAsStringAsync();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
