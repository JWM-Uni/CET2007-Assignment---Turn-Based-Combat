# CET2007 Assignment - Turn Based Combat

## Prerequisites

Visual Studio 2026

## Instructions for running the program

Open the .slx file to load the program into Visual Studio

Run the program

Follow the prompts displayed in the console

## How to view the log and character data

In the same directory as the .slx, open the folder with the project name

Open the bin folder

Open the Debug folder

The log is the text file titled 'log.txt', and the character data is stored in the json file titled 'characterData.json'

-----
## Design choices for the Character Hierarchy explained

In this section, I will discuss the design choices I made for the Character Hierarchy of classes and explain why certain decisions were made.

### Combatant Class

The Combatant Class is the parent class in the character hierarchy. It is an abstract class because it is not intended to be instantiated, only used as a base class. I decided to design it this way because both the player and enemy characters share some common properties that I could include in the same class rather than copy the properties across two different classes. These properties are ID, Name, Type, Health, and Attack. It also includes the BasicAttack method which both characters use, and an abstract method called TakeDamage. TakeDamage is abstract so that custom messages can be used in the subclasses to specify it to either the player or enemy. Both PlayerCombatant and EnemyCombatant inherit from this class.

###  PlayerCombatant Class

The PlayerCombatant class is a child class of Combatant, and the parent class of Knight, Archer, and Mage. It also implements the IComparable interface. It is an abstract class because it is not intended to be instantiated, only used as an intermediary class to include some specific features for the player's character. I decided to design it this way because the player's character has access to some actions that the enemy character does not need, so the properties and methods exclusive to players are not shared with the enemy characters. These properties are Defence and SkillName. It also includes the Defend, CharacterInfo, TakeDamage, Skill, ActionSelection, and CompareTo methods. Defend is included in this class because the scenario stated the enemy will only ever basic attack the player, meaning there is no need for them to have access to the defend method. The same goes for the Skill method. Skill is an abstract method which allows the child classes of PlayerCombatant to implement their own versions of Skill. The ActionSelection method is used to output a list of options the player can choose from on their turn, so the enemy character does not use it. CompareTo is used to allow the CharacterFactory to sort the list by name. The TakeDamage abstract method from Combatant is implemented, and includes a custom damage taking message specifying the player's character's name. It also includes a JsonPolymorphism object with type discriminators, which I implemented to ensure that when the character data is serialised and deserialised from the JSON file in the JsonManager class, it is able to differentiate which of PlayerCombatant's child classes the data belongs to, and format it as the correct object.

### IComparable Interface

IComparable is an interface that is used to implement a comparison method. It is implemented by PlayerCombatant. I chose to use an interface here because I was using the built-in Sort method in PlayerCombatant to allow it to sort the list by name, which requires IComparable to function. It includes the method CompareTo so that it is required to be implemented by any class implementing the interface.

### Knight, Archer, and Mage Classes

NOTE: I've grouped up these classes to discuss because they are similar to each other.

Knight, Archer, and Mage are all child classes of PlayerCombatant. Each class passes all it's properties up to PlayerCombatant and Combatant. They are separated into different classes due to requiring different implementations of the abstract Skill method to fit the character type. For Knight, the skill is a slash doing extra damage. For Archer, it's a sharpened arrow doing bonus damage. For Mage, it's a heal that heals the player's health but does no damage. The hierarchy for characters was designed to be modular this way because it allows for a new character type to be added at any point in the future by adding a class and having it inherit from PlayerCombatant, with the only extra steps being to add their stats to the constructor, and implement their own custom version of the Skill method.

### EnemyCombatant Class

The EnemyCombatant class is a child class of Combatant. I decided to design it this way because it allows me to create any number of enemies with different stats by simply changing the stats in the constructor, should I expand this project in the future. The TakeDamage abstract method from Combatant is implemented, and includes a custom damage taking message specifying the enemy character's name.

-----
## Design choices for the Game's Management and Operation explained

In this section, I will discuss the design choices behind the rest of the classes that are used to manage and operate the game and it's features, and explain why certain decisions were made.

### Logger Class

Logger is a class that is used to manage the logging of information and actions that the player and program take during the runtime of the game. I chose to use the Singleton design pattern for this class by using 'private static Logger instance;' to ensure that only one instance of the Logger class exists across the entire program. It includes a static string property for the file path where it logs the information into a text file. It also includes the methods GetInstance, Log, and ResetLog. GetInstance allows other areas of the program to access the one instance of Logger that exists. Log takes a message and writes it to the log file, including the hour, minute, and second it was logged. ResetLog clears the log and is used at the beginning of the program to remove any logged information from the previous runtime.

### JsonManager Class

JsonManager is a class that is used to manage the saving and loading of character data to a JSON file through serialising and deserialising. I initially included the saving and loading directly in the CharacterFactory class, but decided to separate them and put the JSON parts in their own class to keep in line with responsibility principles and separation of concerns, since saving and loading is different to selecting a character. It also helps to encapsulate and protect file access, since it is the only class that will be accessing the JSON directly. It includes a constant string property for the file path where stores the character data in a json. It also includes the methods LoadCharacterData and SaveCharacterData. LoadCharacterData finds and reads all the text from the JSON and deserialises it into a list to return. SaveCharacterData takes a List of PlayerCombatant objects, serialises them, then writes them to the JSON. Because Knight, Archer, and Mage are subclasses of PlayerCombatant, my inclusion of JSON polymorphism allows them to be saved and loaded as their individual classes within the lists.

### CharacterFactory Class

CharacterFactory is a class that is used to allow the player to select their choice of character for use in the game, and creates the character for them. I chose to use the Factory design pattern for this class to separate the creation and selection of the player character from the main game's logic, so that it can be handled independently. It has three properties, characterList, JsonPath, and jsonSaveLoad. characterList is a list that allows for the storing of PlayerCombatant objects. JsonPath is a constant string that sets the file path to characterData.json. jsonSaveLoad is an object of the JsonManager class and is used to allow serialisation and deserialisation of JSON data.
It also includes six methods, SortList, LoadData, SaveData, SearchCharacter, ViewCharacterList, and CreateCharacter. SortList allows the player to sort the character list by the characters' ID or Name, using a Bubble Sort to sort by ID, and the built-in Sort method for sorting by Name. LoadData uses jsonSaveLoad to load the character data into the list, and create a new set of data if none is found. SaveData uses jsonSaveLoad to save the list of character data to the JSON file. SearchCharacter searches for a character that the player chooses and returns there position in the characterList using a linear search. ViewCharacterList outputs the information of every character in the list. CreateCharacter takes an input from the player and selects their chosen character using a linear search and returns the chosen character. I chose to separate the methods to make the design of this class more modular and flexible when being used, while still keeping them within the CharacterFactory because they are all relevant to the character creation and selection process.

### AttackObserver Class

AttackObserver is a class that is responsible for calculating the amount of damage a character receives when attacked. It also implements the IDamageObserver interface. I chose to use the Observer design pattern for this class to separate the damage calculation from the main game's logic by notifying this class as an observer to calculate the damage needed. It includes the property ActualDamage, which stores the post-calculation damage of an attack. It also includes the method OnDamageCalculation, which calculates the damage based on specified attack and defence values, then returns the actual damage.

### IDamageObserver Interface

IDamageObserver is an interface that is used to implement a damage calculation method. It is implemented by AttackObserver. I chose to use an interface here because if I wanted to expand the program in future, I can implement this interface into other observers that may track the total amount of damage done for a statistics output or something similar, allowing for loose coupling rather than being dependent on a concrete class. It includes the method OnDamageCalculation so that it is required to be implemented by any class implementing the interface.

### GameManager Class

GameManager is a class that is responsible for overseeing and managing the operation of the game, bringing together several different classes. I chose to design it this way because it allows me to create a central system that controls the game, while keeping individual responsibilities within the separate classes. It includes the properties Player, Enemy, and DamageObserver. Player stores a PlayerCombatant object specified in the GameManager's construction, which is the player's chosen character. Enemy stores an EnemyCombatant object also specified in the GameManager's construction, which is the created enemy for the game. DamageObserver is empty initially, but is used to store an AttackObserver object as part of the observer pattern for damage calculation.
It also includes the methods SubscribeToObserver, NotifyDamageCalculation, GameMenu, and RunGame. SubscribeToObserver allows the GameManager to subscribe to the AttackObserver so that it can be notified. NotifyDamageCalculation takes an attack and defence value and notifies the subscribed to AttackObserver that a damage calculation is needed, which it then receives. GameMenu creates a CharacterFactory object, then loads the character data and outputs a menu of pre-game options to the player. It then loops this menu, carrying out the action selected by the player until the player chooses to either start the game, or exit the system. If start the game is chosen, it calls CreateCharacter and then creates an enemy and assigns them, then returns a string containing 1. If exit is chosen, it returns a string containing 5. These values are used in the main to determine whether RunGame is called or not.
RunGame is the largest method in the program because it controls the game's turn based process, using methods from several classes to carry it out. It starts a loop that continues until either the game is quit or the player or enemy dies. Within this loop, it outputs the turn number and characters' statuses, and then lets the player pick an action (the turn count isn't incremented and the enemy doesn't take a turn if the show info option is chosen). The enemy then takes their action, and the turn count is incremented. When the while loop breaks from the player or enemy dying, or quitting the game, it outputs the results of the game, either win, lose, or quitting, and ends the method.

-----
## General Comments on my Design and Design Choices

The game logs any actions taken by the player and enemy, as well as the turn count, and the outcomes of the game using the single instance of the Logger class.

I tried to focus on keeping data encapsulated and separating methods into different classes based on responsibilities. Most of the properties are private set properties meaning they can only be viewed by external classes, not modified. I initially had the JSON operations within the CharacterFactory but to protect data access, I moved all JSON operations into the JsonManager class to ensure only one class had direct access to the JSON file and to separate the responsibilities which the CharacterFactory did not need. Likewise, the Logger class is the only class to be able to directly access the TXT file that contains the runtime log.

The design choices I made were to ensure that the program would be expandable in future should I develop it further. Each class was designed to be modular and easy to expand, so that it would be easy to implement new features without impeding or breaking the rest of the program. For example, adding a new character type for the player simply requires adding a new class that inherits from PlayerCombatant and has a unique skill implementation.

All design choices were also made to follow the specification for the Assignment, aiming to meet each of the code implementation requirements, as well as to follow the capabilities explained in the Turn-Based Game scenario.
