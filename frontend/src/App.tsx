import { useState } from "react";
import "./App.css";
import type { ConversionResponse } from "./types/conversion-response";

function App() {
  const [response, setResponse] = useState("");

  async function Convert() {
    const urlBase = import.meta.env.VITE_API_BASE;
    console.log(urlBase);
    try {
      const preResponse = await fetch(`${urlBase}/Convert?number=123.45`);

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
      <input className="number-input"></input>
      <button className="convert-button" onClick={Convert}>
        Convert
      </button>
      <div className="result-view">{response}</div>
    </div>
  );
}

export default App;
