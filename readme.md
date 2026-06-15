# Currency to text

## Goal

Create web app that lets users enter a number and chose a language. Return the number in written form in the chosen language, interpreted as curreny in dollars/cents.

## AI usage

During the development, no integrated ai tools were used (code completion, agents), with two exceptions:

1. Styling the react app with css was done by github copilot, see `AI_CHAT_LOG.md`. The ai changes are collected int the merge commit `6c2811f1c933a397559ca42ee34f6c3c0ef6f374`.
   Reason is that I'm rather new to frontend development, only having done a hobby project with react+typescript. All other parts of the frontend, i.e. form elements, api interaction, were all hand coded.
2. Test cases for the german conversion logic. I created the test cases for the english converter by hand, but used gemini to create the german conversion tests from that.

AI is used in all kinds of websearch, this history is not included (i.e. ".net how to reverse list", ...).

## Requirements

### Functional

- The maximum number of dollars is 999 999 999.
- The maximum number of cents is 99.
- The separator between dollars and cents is a ‘,’ (comma).
- user can choose between english and german conversion language

### Non-functional

- asp.net backend (.net 10)
- react frontend (node 24)
- conversion implemented server-side

## Assumptions

Additionally to the given functional requirements, this project assumes:

- no negative numbers

## How to run

This project is intended to run on docker, so a docker installation on your local machine is required.

### Development

This project was developed using a devcontainer in vscode. Open the project root in vscode and run `F1 -> Dev Containers: Rebuild and Reopen in Container`.

Running the api is configured as task `.NET Core Launch (web)`, trigger this via `F5`. Running the react app is done via terminal. Switch to the frontend dir, then run `npm run dev`.

Tests exist for the conversion logic in the backend, in project `backend/tests/BackEndTests`. Run with `dotnet test` from the test project dir.

### Showcase

If you only want to run both api and app, run the docker-compose file (docker compose + docker needed on local system). Go to project dir and run `docker compose up`.

App is served at http://localhost:5174/, api documentation at http://localhost:8080/swagger/index.html.

## Design decisions

Simple one client - one server architecture.

- data range validation is done in both frontend and backend

### Simplifications

- local demo only, so we drop (would be handled via gateway in production setting)
  - cors (wildcard cors)
  - https
- backend: No need for full-blown clean-architecture with multiple projects. One endpoint + one 'business logic' function can go into the same project.
  - Static classes for conversion instead of common interface for a one-off project like this
- production oriented api setup was dropped, i.e. global exception handling, running tests in ci/cd

## Known limitations

- frontend "deployment" in docker-compose file is not production ready
- exceptions in backend would be passed through to the caller
