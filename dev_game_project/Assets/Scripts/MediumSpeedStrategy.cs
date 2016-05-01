using System;

	public class MediumSpeedStrategy : ISpeedStrategy
	{
		public MediumSpeedStrategy ()
		{

		}

	public void SetSpeed(Mover character,int speed){
			character.speed = speed;
		}
	}

