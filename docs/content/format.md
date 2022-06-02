# ArmyPlanner Data Format

ArmyPlanner works with JSON files to store the data and structures. On the top level there is an index file in which all available games are stored. This contains the paths to the individual game folders.<br />
[learn more about the repository index schema](content/repository-index-schema.md)

In the game folders are as second level the index files with the codex files for the respective game.<br />
[learn more about the game index schema](content/game-index-schema.md)

The codex files are the third and final level and contains the actual data about units, abilities, etc.<br />
[learn more about the codex schema](content/codex-schema.md)