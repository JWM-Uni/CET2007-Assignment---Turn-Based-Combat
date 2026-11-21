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

The PlayerCombatant class is a child class of Combatant, and the parent class of Knight, Archer, and Mage. It also implements the IComparable interface. It is an abstract class because it is not intended to be instantiated, only used as an intermediary class to include some specific features for the player's character. I decided to design it this way because the player's character has access to some actions that the enemy character does not need, so the properties and methods exclusive to players are not shared with the enemy characters. These properties are Defence and SkillName. It also includes the Defend, CharacterInfo, TakeDamage, Skill, ActionSelection, and CompareTo methods. Defend is included in this class because the scenario stated the enemy will only ever basic attack the player, meaning there is no need for them to have access to the defend method. The same goes for the Skill method. Skill is an abstract method which allows the child classes of PlayerCombatant to implement their own versions of Skill. The ActionSelection method is used to output a list of options the player can choose from on their turn, so the enemy character does not use it. CompareTo is used to allow the CharacterFactory to sort the list by name. The TakeDamage abstract method from Combatant is implemented, and includes a custom damage taking message specifying the player's character's name.

### Knight, Archer, and Mage Classes

NOTE: I've grouped up these classes to discuss because they are similar to each other.

Knight, Archer, and Mage are all child classes of PlayerCombatant. Each class passes all it's properties up to PlayerCombatant and Combatant. They are separated into different classes due to requiring different implementations of the abstract Skill method to fit the character type. For Knight, the skill is a slash doing extra damage. For Archer, it's a sharpened arrow doing bonus damage. For Mage, it's a heal that heals the player's health but does no damage. The hierarchy for characters was designed to be modular this way because it allows for a new character type to be added at any point in the future by adding a class and having it inherit from PlayerCombatant, with the only extra steps being to add their stats to the constructor, and implement their own custom version of the Skill method.

### EnemyCombatant Class

The EnemyCombatant class is a child class of Combatant. I decided to design it this way because it allows me to create any number of enemies with different stats by simply changing the stats in the constructor, should I expand this project in the future. The TakeDamage abstract method from Combatant is implemented, and includes a custom damage taking message specifying the enemy character's name.

-----
## Design choices for the Game's Management and Operation explained

In this section, I will discuss the design choices behind the rest of the classes that are used to manage and operate the game and it's features, and explain why certain decisions were made.

### Logger Class

Logger is a class that is used to manage the logging of information and actions that the player and program take during the runtime of the game. I chose to use the Singleton design pattern for this class by using 'private static Logger instance;' to ensure that only one instance of the Logger class exists across the entire program. It includes a static string attribute for the file path where it logs the information into a text file. It also includes the methods GetInstance, Log, and ResetLog. GetInstance allows other areas of the program to access the one instance of Logger that exists. Log takes a message and writes it to the log file, including the hour, minute, and second it was logged. ResetLog clears the log and is used at the beginning of the program to remove any logged information from the previous runtime.

### JsonManager Class

JsonManager is a class that is used to manage the saving and loading of character data to a JSON file through serialising and deserialising. I initially included the saving and loading directly in the CharacterFactory class, but decided to separate them and put the JSON parts in their own class to keep in line with responsibility principles and separation of concerns, since saving and loading is different to selecting a character. It also helps to encapsulate and protect file access, since it is the only class that will be accessing the JSON directly. It includes a constant string attribute for the file path where stores the character data in a json. It also includes the methods LoadCharacterData and SaveCharacterData. LoadCharacterData finds and reads all the text from the JSON and deserialises it into a list to return. SaveCharacterData takes a List of PlayerCombatant objects, serialises them, then writes them to the JSON. Because Knight, Archer, and Mage are subclasses of PlayerCombatant, my inclusion of JSON polymorphism allows them to be saved and loaded as their individual classes within the lists.

### CharacterFactory Class

