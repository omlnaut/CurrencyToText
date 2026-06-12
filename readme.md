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

# Steps

- [x] setup devcontainer
- basic architecture setup
  - [x] asp.net api
  - [x] react app
  - [x] test: app can talk to api
- api
  - conversion logic
    - english
      - [x] whole numbers
      - fractions
    - german
  - endpoint
    - validation
    - global error handling
- showcase setup
  - docker-compose for spinning up both api+app
  - test: app can talk to api

- app
  - react html base
  - validation
  - api types
  - api interaction
  - css

#### maybe?

- tests in pipeline
