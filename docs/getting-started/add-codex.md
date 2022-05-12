# Add new Codex

## create the base codex file

___**Important:**___ ___All files must be located in the corresponding game folder.___

First, select a unique key for the codex. Preferably, the key includes the name of the army and, for example, the publication date of the codex.
Now create a JSON file with the key in the folder, for example `a-new-army-2022.json`. The content looks like this:<br />
`{`<br />
`    "$schema": "https://raw.githubusercontent.com/lk-code/armyplanner/main/codex-schema-v1.json"`<br />
`}`

By specifying the schema file, Visual Studio Code shows you the allowed entries and how exactly they are applied.

## how does the translation engine work

Before you add a language file, you should know how the ArmyPlanner translation engine works.

The language file contains a JSON object in which all texts for the codex are stored. A translation consists of a unique key and the actual translation. The key must be identical in all language files (for example, en, de, es, fr, etc.) so that the translation can be found in all languages. The key of the translation is inserted in the codex file and is automatically replaced by the translation by the ArmyPlanner app.

For example, the language file may look like this: <br />
`{` <br />
`    "meta_game_name": "Warhammer 40K",` <br />
`    "meta_codex_name": "Tau Empire 2018 (8th)",` <br />
`    ...` <br />
`}` <br />

## add a language for the codex

First create a new JSON file in the following format `{codex-key}.{language}.json`. Example `a-new-army-2022.en.json`.<br />
Then open the main codex file (not the language file) and add the following entry (if not already present):<br />
`{`<br />
`    "$schema": "https://raw.githubusercontent.com/lk-code/armyplanner/main/codex-schema-v1.json",`<br />
`    "languages": [`<br />
`    ]`<br />
`}`<br />

For each language, you will now insert one JSON object with the specified format into the languages JSON array. In the following example, we add two objects for English and German:
`{`<br />
`    "$schema": "https://raw.githubusercontent.com/lk-code/armyplanner/main/codex-schema-v1.json",`<br />
`    "languages": [`<br />
`        {`<br />
`            "name": "English (English)",`<br />
`            "path": "a-new-army-2022.en.json",`<br />
`            "lang": "en"`<br />
`        },`<br />
`        {`<br />
`            "name": "Deutsch (German)",`<br />
`            "path": "a-new-army-2022.de.json",`<br />
`            "lang": "de"`<br />
`        }`<br />
`    ]`<br />
`}`<br />