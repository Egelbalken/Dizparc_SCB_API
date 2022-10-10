import React, { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

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
      <Header
        as="h1"
        icon="tag"
        content="SCBs Kod test försök av Kent Jakobsson"
      />
      <List>
        {statistics.map((statistics: any) => (
          <List.Item key={statistics.id}>
            Statestik: {statistics.county}
          </List.Item>
        ))}
      </List>
    </div>
  );
}

export default App;
