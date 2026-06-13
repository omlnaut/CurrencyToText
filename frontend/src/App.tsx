import React, { useState } from "react";
import "./App.css";
import type { ConversionResponse } from "./types/conversion-response";

interface FormElements extends HTMLFormControlsCollection {
  numberInput: HTMLInputElement;
}
interface NumberFormElement extends HTMLFormElement {
  readonly elements: FormElements;
}
function App() {
  const [response, setResponse] = useState("");

  async function Convert(event: React.SubmitEvent<NumberFormElement>) {
    event.preventDefault();
    const numberStr = event.currentTarget.elements.numberInput.value;
    const params = new URLSearchParams({ number: numberStr });

    const urlBase = import.meta.env.VITE_API_BASE;
    console.log(urlBase);
    try {
      const preResponse = await fetch(
        `${urlBase}/Convert?${params.toString()}`,
      );

      if (!preResponse.ok) {
        setResponse("Error fetching from api.");
        return;
      }

      const response: ConversionResponse = await preResponse.json();

      console.log(JSON.stringify(response));

      setResponse(response.convertedNumber);
    } catch (error) {
      setResponse("Api is not reachable.");
      console.log(`Could not reach api, details: ${error}`);
    }
  }
  return (
    <div>
      <form method="post" onSubmit={Convert}>
        <input
          id="numberInput"
          className="number-input"
          type="number"
          step={0.01}
          min={0}
          max={999999999.99}
        ></input>
        <button className="convert-button" type="submit">
          Convert
        </button>
      </form>
      <div className="result-view">{response}</div>
    </div>
  );
}

export default App;
