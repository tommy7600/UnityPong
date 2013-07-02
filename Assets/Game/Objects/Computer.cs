using UnityEngine;
using System.Collections;

public class Computer : Paddle
{
	
	private Ball _ball = null;
	private float _speed;
	
	public Computer () : base ( "computer" )
	{
		_speed = 75.0f;
	}
	
	public override void Update ()
	{	
		if ( _ball != null && _ball.velocity.x > 0 )
		{
			float y = _ball.y;
			
			if ( y - this.y > 0 )
			{
				y = Time.deltaTime * _speed + this.y;
			}
			else
			{
				y = -Time.deltaTime * _speed + this.y;
			}
			
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
			else if ( this._ball.y > maxY || this._ball.y < minY )
			{
				this.y = y;	
			}
		
		}
		
		base.Update ();	
	}
	
	public Ball ball
	{
		get { return _ball; }
		
		set { _ball = value; } 
	}
}

