using UnityEngine;
using System.Collections;

public class Player : Paddle
{
	private float _speed;
	
	public Player () : base ( "player" )
	{
		_speed = 100;
	}
	
	public override void Update ()
	{
		base.Update ();
		
		float vertical = Input.GetAxis ( "Vertical" );
		
		this.y += vertical * Time.deltaTime * _speed;
	}
	
}

