using UnityEngine;
using System.Collections;

public class girlDialogue : DialogueTest {
	GameStateScript gameState;
	
	string characterName;
	
	void Health1(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("Hey there uncle Auggie!");
		} else if (choice == 1) {
			Current = Health2;
			Current(-1);
		}
	}
	void Health2(int choice) {
		if (choice == -1) {
			conversation.NewMonologue("I've been worried about you lately.");
		} else if (choice == 1) {
			Current = Health3;
			Current(-1);
		}
	}
	void Health3(int choice) {
		if (choice == -1) {
			conversation.NewMonologue("In fact, all of us are worried about you.");
		} else if (choice == 1) {
			Current = Health4;
			Current(-1);
		}
	}
	void Health4(int choice) {
		if (choice == -1) {
			conversation.NewMonologue("You're sickness keeps getting worse and worse and there's nothing I can do.");
		} else if (choice == 1) {
			Current = Health5;
			Current(-1);
		}
	}
	void Health5(int choice) {
		if (choice == -1) {
			conversation.NewMonologue("But it is ok now.\nI am even excited!");
		} else if (choice == 1) {
			Current = Health6;
			Current(-1);
		}
	}
	void Health6(int choice) {
		if (choice == -1) {
			conversation.NewMonologue("Now that the world famous Dr. van Oinkenstein has promised to help you\nI'm sure you'll be OK!");
		} else if (choice == 1) {
			Current = Health7;
			Current(-1);
		}
	}
	void Health7(int choice) {
		if (choice == -1) {
			conversation.NewMonologue("Your appointment with him is about now, isn't it?");
		} else if (choice == 1) {
			Current = Health8;
			Current(-1);
		}
	}
	void Health8(int choice) {
		if (choice == -1) {
			conversation.NewMonologue("Why don't you go to the hospital?");
		} else if (choice == 1) {
			Current = Health9;
			Current(-1);
		}
	}
	void Health9(int choice) {
		if (choice == -1) {
			conversation.NewMonologue("I'll be waiting here for you when you get back.");
		} else if (choice == 1) {
			Current = Health10;
			Current(-1);
		}
	}
	void Health10(int choice) {
		if (choice == -1) {
			monologue = false;
			conversation.NewChoice("You'll remember to come see me when you're done, right?",
			                         "Of course!",
			                         "Maybe?",
			                         "");
		} else if (choice == 1) {
			Current = Health11;
			Current(-1);
		} else if (choice == 2) {
			Current = Health11;
			Current(-1);
		}
	}
	void Health11(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue("Ok...\nWell, seeya!");
		} else if (choice == 1) {
			gameState.Overworld();
			gameState.IncrementArc();
		}
	}

	void Silence(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue ("");
		} else if (choice == 1) {
			gameState.Overworld ();
		}
	}
	
	// Use this for initialization
	// Call Initialize first, set current to the base of the current dialogue tree,
	// Then call Current(-1) to start
	void Start () {
		//initiated = false;
		gameState = GameObject.Find ("GameState").GetComponent<GameStateScript> ();
		characterName = GetComponent<DialogueTransitionScript> ().characterName;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameState.CurrentState () == "Dialogue" && initiated != true) {
			if (gameState.GetInterlocutor() == characterName) {
				// Logic can be added here for which dialogue tree to start from
				Initialize ();

				if (gameState.GetArcState() == 1) {
					Current = Health1;
					Current (-1);
				} else {
					Current = Silence;
					Current(-1);
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
