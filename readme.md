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

## Decisions
- drop https since we only demo locally?


# Steps

- [x] setup devcontainer
- basic architecture setup
	- [x] asp.net api
	- react app
	- test: app can talk to api
- showcase setup
	- docker-compose for spinning up both api+app
	- test: app can talk to api
- api
	- conversion logic
		- find unittest cases
	- endpoint
		- validation
  	- global error handling

- app
	- react html base
	- validation
	- api types
	- api interaction
	- css

#### maybe?
- tests in pipeline