using System;

	public class SpeedContext
	{

		private ISpeedStrategy strategy;

		public SpeedContext (ISpeedStrategy strategy)
		{
			this.strategy = strategy;
		}

		public void executeStrategy(Mover character, int speed){
			strategy.SetSpeed (character, speed);
		}


	}
	