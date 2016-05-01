using System;

	public class LowSpeedStrategy : ISpeedStrategy
	{
		public LowSpeedStrategy ()
		{

		}

	public void SetSpeed(Mover character,int speed){
			character.speed = speed;
		}
	}

