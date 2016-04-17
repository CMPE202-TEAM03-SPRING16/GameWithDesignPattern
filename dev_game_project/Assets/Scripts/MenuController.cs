using System;
namespace AssemblyCSharp
{
	public class MenuController
	{

		private MenuHandler menuHandler;
		private MainMenu mainMenu;

		private PlayGame playGame;
		private QuitGame quitGame;
		public MenuController ()
		{	
			mainMenu = new MainMenu ();
			menuHandler = new MenuHandler ();
			playGame = new PlayGame (mainMenu);
			quitGame = new QuitGame (mainMenu);

		}

		public void executeAction(MenuManager menuManager, string action){

			switch(action){
			case "play":
				menuHandler.Execute (playGame, menuManager);
			break;
			case "quit":
				menuHandler.Execute (quitGame, menuManager);
			break;
			}
		}




	}
}