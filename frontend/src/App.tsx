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
    <div className="app-shell">
      <div className="background-glow background-glow-one"></div>
      <div className="background-glow background-glow-two"></div>

      <main className="converter-card">
        <header className="card-header">
          <p className="eyebrow">Currency to Text</p>
          <h1>Convert Numbers Instantly</h1>
          <p className="subtitle">
            Enter a value and choose a language to generate the text output.
          </p>
        </header>

        <form className="converter-form" method="post" onSubmit={Convert}>
          <div className="field-group">
            <label htmlFor="numberInput">Amount</label>
            <input
              id="numberInput"
              className="number-input"
              type="number"
              step={0.01}
              min={0}
              max={999999999.99}
              placeholder="e.g. 1234.56"
            ></input>
          </div>

          <div className="field-group">
            <label htmlFor="languageSelect">Language</label>
            <LanguageSelection
              languages={Object.keys(languages)}
            ></LanguageSelection>
          </div>

          <button className="convert-button" type="submit">
            Convert
          </button>
        </form>

        <section className="result-panel" aria-live="polite">
          <h2>Result</h2>
          <div className="result-view">
            {response || "Your converted text will appear here."}
          </div>
        </section>
      </main>
    </div>
  );
}

export default App;
