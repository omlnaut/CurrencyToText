# Currency to text

## Goal

Create web app that lets users enter a number and chose a language. Return the number in written form in the chosen language.

### Requirements

#### Functional

- The maximum number of dollars is 999 999 999.
- The maximum number of cents is 99.
- The separator between dollars and cents is a ‘,’ (comma).

#### Non-functional

- asp.net backend (.net 10)
- react frontend
- conversion implemented server-side

#### assumptions

- no negative numbers
- no authx

## Simplifications

- local demo only, so we drop (would be handled via gateway in production setting)
  - cors (wildcard cors)
  - https
- backend: solution setup with multiple projects. One endpoint + one 'business logic' function can go into the same project.
- sign-safety in backend utility functions

# Steps

- [x] setup devcontainer
- [x] basic architecture setup
  - [x] asp.net api
  - [x] react app
  - [x] test: app can talk to api
- [x] api
  - [x] english conversion logic
    - [x] whole numbers
    - [x] fractions
  - [x] endpoint
    - [x] basic call
- [x] app
  - [x] react html base
  - [x] api types
  - [x] api interaction
  - [x] validation
- [x] german conversion logic
  - [x] refactor english
  - [x] implement german
- [x] app
  - [x] language selection
  - [x] css
  - [x] refactor make pretty(ish)
- [x] showcase setup
  - [x] docker-compose for spinning up both api+app
- readme documentation
- endpoint
  - documentation

#### maybe?

- tests in pipeline
- global exception handling in api
- endpoint error handling
- validation
- refactor german?
