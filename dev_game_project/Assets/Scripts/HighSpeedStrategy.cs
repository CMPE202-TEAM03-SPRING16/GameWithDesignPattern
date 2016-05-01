using System;

	public class HighSpeedStrategy : ISpeedStrategy
	{
		public HighSpeedStrategy ()
		{

		}

		public void SetSpeed(Mover character,int speed){
			character.speed = speed;
		}
	}
