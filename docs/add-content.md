# Add Content

## Getting Started

Use a tool like [GitHub Desktop](https://desktop.github.com/) to clone the repository [`https://github.com/lk-code/armyplanner`](https://github.com/lk-code/armyplanner). In the cloned repository, the files for games and codices can be edited.

## Add new Game

Open the file /index.json. The content looks like this:<br />
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

Add an object with the folder name of your own game at the end. Then create a folder with that name. All the game files like codices will be placed here.

There you must first create a file index.json with the following content:<br />
`{`<br />
`    "$schema": "https://raw.githubusercontent.com/lk-code/armyplanner/main/game-schema-v1.json",`<br />
`    "title": "NAME_OF_YOUR_GAME",`<br />
`    "description": "A description for the game in markdown code.",`<br />
`    "codices": [`<br />
`    ]`<br />
`}`

Then proceed to the [Add new Codex](#add-new-codex) step.

## Add new Codex