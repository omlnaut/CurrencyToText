import React, { useState } from "react";
import "./App.css";
import { ConversionLanguage, ConvertNumber } from "./Api";
import { LanguageSelection } from "./components/LanguageSelection";

interface FormElements extends HTMLFormControlsCollection {
  numberInput: HTMLInputElement;
  languageSelect: HTMLSelectElement;
}
interface NumberFormElement extends HTMLFormElement {
  readonly elements: FormElements;
}
const languages: Record<string, ConversionLanguage> = {
  english: ConversionLanguage.English,
  deutsch: ConversionLanguage.German,
};
function App() {
  const [response, setResponse] = useState("");

  async function Convert(event: React.SubmitEvent<NumberFormElement>) {
    event.preventDefault();

    const numberStr = event.currentTarget.elements.numberInput.value;
    const languageStr = event.currentTarget.elements.languageSelect.value;

    setResponse(await ConvertNumber(numberStr, languages[languageStr]));
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
        <LanguageSelection
          languages={Object.keys(languages)}
        ></LanguageSelection>
        <button className="convert-button" type="submit">
          Convert
        </button>
      </form>
      <div className="result-view">{response}</div>
    </div>
  );
}

export default App;
