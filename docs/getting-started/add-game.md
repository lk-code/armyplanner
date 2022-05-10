# Add a new Game

Open the file index.json in the root directory. All available games are listed here. The content looks like this:<br />
`{`<br />
`    "$schema": "https://raw.githubusercontent.com/lk-code/armyplanner/main/repository-schema-v1.json",`<br />
`    "games": [`<br />
`        {`<br />
`            "path": "/w40k"`<br />
`        },`<br />
`        {`<br />
`            "path": "/waos"`<br />
`        }`<br />
`        ....`<br />
`        {`<br />
`            "path": "/directory_to_your_own_game"`<br />
`        }`<br />
`    ]`<br />
`}`

Choose a directory key for the game. This key must be unique, that means it should not be used again in the whole ArmyPlanner repository. This will be used later in the individual codices for the assignment.<br />
To add your own game to the index do the following:

1. Add an object with the folder name of your own game at the end of the index list `games`.
2. As path you specify the unique key of your game.
3. Then create a folder with that name. All game files, such as codices, are now stored here.
4. In the created directory you now have to create an index file index.json, in which the available codes are listed. This file will have the following content:<br />
`{`<br />
`    "$schema": "https://raw.githubusercontent.com/lk-code/armyplanner/main/game-schema-v1.json",`<br />
`    "title": "NAME_OF_YOUR_GAME",`<br />
`    "description": "A description for the game in markdown code.",`<br />
`    "codices": [`<br />
`    ]`<br />
`}`

Then proceed to the [Add new Codex](#add-new-codex) step.