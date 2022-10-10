import React, { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';

function App() {
  const [statistics, setStatics] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5000/api/scb').then((response) => {
      console.log(response);
      setStatics(response.data);
    });
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        <ul>
          {statistics.map((statistics: any) => (
            <li key={statistics.id}>Statestik:{statistics.county}</li>
          ))}
        </ul>
      </header>
    </div>
  );
}

export default App;
