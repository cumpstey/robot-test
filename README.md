# Toy Robot Simulator

## Instructions

### Rules of engagement

- Use any language you like, .Net, php, JavaScript, whatever...
- Feel free to include an interface that you feel is suitable, be that command line or full html app.
- Feel free to embellish it as much as you want, but all the core functionality MUST be adhered to.

### Description

- The application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units.
- There are no other obstructions on the table surface.
- The robot is free to roam around the surface of the table, but must be prevented from falling to destruction. Any movement
that would result in the robot falling from the table must be prevented, however further valid movement commands must still
be allowed.
- You need to provide test data/results for the app & its logic

### Objectives

- Create an application that can read in commands of the following form -
	- PLACE X,Y,F
	- MOVE
	- LEFT
	- RIGHT
	- REPORT
- PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.
- The origin (0,0) can be considered to be the SOUTH WEST most corner.
- The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The application should discard all commands in the sequence until a valid PLACE command has been executed.
- MOVE will move the toy robot one unit forward in the direction it is currently facing.
- LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
- REPORT will announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient.
- A robot that is not on the table can choose the ignore the MOVE, LEFT, RIGHT and REPORT commands.
- Input can be from a file, or from standard input, as the developer chooses.
- Provide test data to exercise the application.

### Constraints

- The toy robot must not fall off the table during movement. This also includes the initial placement of the toy robot.
- Any move that would cause the robot to fall must be ignored.

### Example input and output

1. 

		PLACE 0,0,NORTH
		MOVE
		REPORT
	
	Output: `0,1,NORTH`

2.	

		PLACE 0,0,NORTH
		LEFT
		REPORT

	Output: `0,0,WEST`

3.	

		PLACE 1,2,EAST
		MOVE
		MOVE
		LEFT
		MOVE
		REPORT

	Output: `3,3,NORTH`

## This implementation

The aim was not to make the simplest implementation which satisfies the requirements, but to make a testable, flexible and extensible implementation.

The BusinessLogic project contains the core functionality - classes or structs representing the robot, grid, coordinate and current state of the robot, as well as the default set of commands.

The Utilities project provides functionality which formats logged messages appropriately, while allowing the writing of them to be carried out elsewhere - in this case by the ConsoleLogger defined in the ConsoleUI project.

The UI.ConsoleUI project provides a console interface.

The UI.Common project contains parsers for the default commands.

The command parsing and execution is tested in the two test projects.

### Extensibility

It's easy to imagine, if you think of this as being a real project, that having been given and built to the above set of instructions, you'll get a message from the client the day before anticipated launch saying something like: "Can we do diagonal movement instead? It's just more Apple! And on a 7x9 grid."

Such a thing is simple to deal with here.

- The size of the grid is passed to the app as parameters on execution `-x 5 -y 5` and so can trivially be set to anything.

- To change the commands is straightforward:
	- Create a new class inheriting from `Command`, which performs the command on the robot's current state.
	- Create a method which parses a string command into your new `Command` class, and register it:
	
			var commandParser = new TextCommandParser(logger);
            commandParser.RegisterParser("keyword", ParserMethod);

		You can, if necessary, not register the default commands:

			var commandParser = new TextCommandParser(logger, registerDefaultParsers: false);

Because the UI is completely separated from the business logic, it's also simple to create an alternative UI without having to change any of the logic.