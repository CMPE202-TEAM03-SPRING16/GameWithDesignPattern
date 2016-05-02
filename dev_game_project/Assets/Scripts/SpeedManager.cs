using System;

	public class SpeedManager
	{
		private Mover character;
		SpeedContext speedContext;

		public SpeedManager (Mover character)
		{
			this.character = character;
		}

		public void SetNewSpeed(string speedType){
			switch(speedType){

			case "low":
				new SpeedContext(new LowSpeedStrategy()).executeStrategy(character, -10);
				break;
			case "medium":
				new SpeedContext(new MediumSpeedStrategy()).executeStrategy(character, -15);
				break;
			case "high":
				new SpeedContext(new HighSpeedStrategy()).executeStrategy(character, -20);
				break;
			}
		}
	}