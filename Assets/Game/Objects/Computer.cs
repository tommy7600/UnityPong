using UnityEngine;
using System.Collections;

public class Computer : Paddle
{
	
	private Ball _ball = null;
	
	public Computer () : base ( "computer" )
	{
		
	}
	
	public override void Update ()
	{
		base.Update ();
		
		if ( _ball != null )
		{
			this.y = _ball.y;
		}
		
	}
	
	public Ball ball
	{
		get { return _ball; }
		
		set { _ball = value; } 
	}
}

