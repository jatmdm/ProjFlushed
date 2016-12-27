using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterDialogueTest : DialogueTest {
	GameStateScript gameState;

	string characterName;

	void Hello1(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("Hey there, big sister!");
		} else if (choice == 1) {
			Current = Hello2;
			Current(-1);
		}
	}
	void Hello2(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("As you can see,\nI am in the process of making a very fantastic pie.");
		} else if (choice == 1) {
			Current = Hello3;
			Current(-1);
		}
	}
	void Hello3(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("However,");
		} else if (choice == 1) {
			Current = Hello4;
			Current(-1);
		}
	}
	void Hello4(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("There is one complication:");
		} else if (choice == 1) {
			Current = Hello5;
			Current(-1);
		}
	}
	void Hello5(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("I have only tangerines.");
		} else if (choice == 1) {
			Current = Hello6;
			Current(-1);
		}
	}
	void Hello6(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("No sane person would ever make a pie with just tangerines!");
		} else if (choice == 1) {
			Current = Hello7;
			Current(-1);
		}
	}
	void Hello7(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("So, please, big sister, can you help me?");
		} else if (choice == 1) {
			Current = Hello8;
			Current(-1);
		}
	}
	void Hello8(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("Please find some other fruit to put in my pie.");
		} else if (choice == 1) {
			Current = Hello9;
			Current(-1);
		}
	}
	void Hello9(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("Your assistance would be very appreciated!");
		} else if (choice == 1) {
			gameState.IncrementArc ();
			gameState.Overworld ();
		}
	}

	void Pineapple1(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("Pineapple? \nWhy would you give me a pineapple?");
		} else if (choice == 1) {
			Current = Pineapple2;
			Current (-1);
		}
	}
	void Pineapple2(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("I hate pineapple!");
		} else if (choice == 1) {
			Current = Pineapple3;
			Current (-1);
		}
	}
	void Pineapple3(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("Please find a better fruit.");
		} else if (choice == 1) {
			gameState.Overworld ();
		}
	}

	void Apple1(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue ("Oh look, An apple!");
		} else if (choice == 1) {
			Current = Apple2;
			Current (-1);
		}
	}
	void Apple2(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("Apples are good, but you could do better.");
		} else if (choice == 1) {
			Current = Apple3;
			Current (-1);
		}
	}
	void Apple3(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("How about you give me something a little more purple?");
		} else if (choice == 1) {
			gameState.Overworld ();
		}
	}

	void Grape1(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue ("You brought me grapes? \nI love grapes!");
		} else if (choice == 1) {
			Current = Grape2;
			Current (-1);
		}
	}
	void Grape2(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("But…");
		} else if (choice == 1) {
			Current = Grape3;
			Current (-1);
		}
	}
	void Grape3(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("Grapes and tangerines? That doesn’t sound very good.");
		} else if (choice == 1) {
			Current = Grape4;
			Current (-1);
		}
	}
	void Grape4(int choice) {
		if (choice == -1) {
			monologue = false;
			conversation.NewChoice ("What will my mom say?",
				"She'll say 'Follow your heart.'",
				"She'll punish you harshly.",
			    "");
		} else if (choice == 1) {
			Current = Grape5;
			Current (-1);
		} else if (choice == 2) {
			Current = Grape8;
			Current (-1);
		}
	}
	void Grape5(int choice) {
		if (choice == -1) {
			conversation.NewChoice ("Are you sure?",
				"Yes!",
				"No!",
			    "");
		} else if (choice == 1) {
			Current = Grape6;
			Current (-1);
		} else if (choice == 2) {
			Current = Grape8;
			Current (-1);
		}
	}
	void Grape6(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("Hmm...");
		} else if (choice == 1) {
			Current = Grape7;
			Current (-1);
		}
	}
	void Grape7(int choice) {
		if (choice == -1) {
			monologue = false;
			conversation.NewChoice ("<Enter her brain?>",
				"Yes",
				"No",
			    "");
		} else if (choice == 1) {
			gameState.arcState = 2;
			gameState.finished = true;
			SceneManager.LoadScene ("tangerineJump");
		} else if (choice == 2) {
			gameState.Overworld ();
		}
	}
	void Grape8(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("<You see she enters a state of melancholy>");
		} else if (choice == 1) {
			gameState.Overworld ();
			initiated = false;
		}
	}


	void FindFruit(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("Hurry up!\nIt's almost oven insertion time!");
		} else if (choice == 1) {
			gameState.Overworld ();
		}
	}

	void Thankyou(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("Thanks big sister!\nThe pie is delicious!");
		} else if (choice == 1) {
			gameState.Overworld ();
		}
	}

	// Use this for initialization
	// Call Initialize first, set current to the base of the current dialogue tree,
	// Then call Current(-1) to start
	void Start () {
		//initiated = false;
		gameState = GameObject.FindWithTag ("GameController").GetComponent<GameStateScript> ();
		characterName = GetComponent<DialogueTransitionScript> ().characterName;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameState.CurrentState () == "Dialogue" && initiated != true) {
			if (gameState.GetInterlocutor() == characterName) {
				// Logic can be added here for which dialogue tree to start from
				Initialize ();

				if (gameState.GetArcState () == 2) {
					Current = Thankyou;
					Current (-1);
				} else if (gameState.GetFruit () == "Pineapple") {
					Current = Pineapple1;
					Current (-1);
				} else if (gameState.GetFruit () == "Grape") {
					Current = Grape1;
					Current (-1);
				} else if (gameState.GetFruit () == "Apple") {
					Current = Apple1;
					Current (-1);
				} else if (gameState.GetArcState () == 0) {
					Current = Hello1;
					Current (-1);
				} else if (gameState.GetArcState () == 1) {
					Current = FindFruit;
					Current (-1);
				}
			}
		}
		if (gameState.CurrentState () == "Overworld" && initiated == true) {
			initiated = false;
		}
		if (initiated == true) {
			Current (GetChoice ());
		}
	}
}
