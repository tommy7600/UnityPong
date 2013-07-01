using UnityEngine;
using System.Collections;

public class Ball : FSprite
{
	private Vector2 _velocity;
	private Vector2 _acceleration;
	private float	_angle; // radians
	private float	_maxVelocity;
	public Ball () : base ( "ball" )
	{
		_velocity 		= new Vector2 ( 0.0f, 0.0f );
		_acceleration 	= new Vector2 ( 0.0f, 0.0f );
		_angle 			= 0;
		_maxVelocity	= 50.0f;
	}
	
	public void Reset ()
	{
		// reset accelerationn
		_acceleration 	= new Vector2 ( 0.0f, 0.0f );
		
		// need a random angle from 0 - 45 degrees
		
		_angle = Mathf.PI / 4 * RXRandom.Float ();
		
		_velocity.x = -_maxVelocity * Mathf.Cos ( _angle );
		_velocity.y = _maxVelocity * Mathf.Sin ( _angle );
		
	}
	
	public void Update ()
	{
		float dt = Time.deltaTime;
		
		_velocity.x += _acceleration.x * dt;
		_velocity.y += _acceleration.y * dt;
		
		float newX = _velocity.x * dt + this.x;
		float newY = _velocity.y * dt + this.y;
		
		if ( !this.VerticalWallCollsion ( newX, newY ) && !this.HorizontalWallCollision (newX, newY ) )
		{
			this.x = newX;
			this.y = newY;
		}
		else
		{
			
			if ( this.VerticalWallCollsion ( newX, newY ) )
			{
				_velocity.x = -_velocity.x;
			} else {
				_velocity.y = -_velocity.y;
			}
				
		}
	}
	
	private bool VerticalWallCollsion ( float x, float y )
	{
		if ( x < Futile.screen.halfWidth 
			&& x > - Futile.screen.halfWidth )
		{
			return false;
		}
			
		return true;
	}
	
	private bool HorizontalWallCollision ( float x, float y )
	{
		if ( y < Futile.screen.halfHeight
			&& y > - Futile.screen.halfHeight )
		{
			return false;
		}
			
		return true;
	}
}

