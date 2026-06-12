import { useEffect, useState } from "react";
import "./App.css";

function App() {
  const [response, setResponse] = useState("");

  useEffect(() => {
    async function callApi() {
      const urlBase = import.meta.env.VITE_API_BASE;
      const preResponse = await fetch(`${urlBase}/weatherforecast`);
      const response = await preResponse.json();

      setResponse(JSON.stringify(response));
    }
    callApi();
  }, []);
  return <div>Api response: {response}</div>;
}

export default App;
