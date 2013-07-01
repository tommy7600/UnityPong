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
		float vertical = Input.GetAxis ( "Vertical" );
		
		float y		= vertical * Time.deltaTime * _speed + this.y;
		float maxY 	= y + this.height/2;
		float minY 	= y - this.height/2;
		
		if (this.VerticalWallCollision ( this.x, maxY ) )
		{
			this.y = Futile.screen.halfHeight - this.height/2;
		}
		else if (this.VerticalWallCollision ( this.x, minY ) )
		{
			this.y = -Futile.screen.halfHeight + this.height/2;
		}
		else
		{
			this.y = y;	
		}
		
		base.Update ();
	}
	
}

