import { useEffect, useState } from "react";
import "./App.css";

function App() {
  const [response, setResponse] = useState("");

  useEffect(() => {
    async function callApi() {
      const preResponse = await fetch("http://localhost:5196/weatherforecast");
      const response = await preResponse.json();

      setResponse(JSON.stringify(response));
    }
    callApi();
  }, []);
  return <div>Api response: {response}</div>;
}

export default App;
