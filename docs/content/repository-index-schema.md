# Repository Index

The index file for the repository is located at `/index.json` and is the primary entry point. This file is defined by the JSON schema `/repository-schema-v1.json`.

In this file, the paths to all available games are given in the form of a list. This path represents a folder with the same name on the same level.

[learn how to add a game to the repository](/getting-started/add-game)

The file contains a JSON object with the following structure:

JSON-Key | JSON-Type | Description
-------- | -------- | --------
**games** | JSON-Array | contains a listing of [`Game-Index-Entry`](#game-index-entry) objects

#### Game-Index-Entry

A `Game-Index-Entry` is a JSON object with the following structure:

JSON-Key | JSON-Type | Description
-------- | -------- | --------
**path** | string | specifies the absolute path to the folder of a game.