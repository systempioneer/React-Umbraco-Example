import React, { Component } from 'react';
import './App.css';

class App extends Component {
  constructor(props) {
    super(props)

    this.state = { currentContent: '' }
  }

  componentDidMount() {
    fetch('/umbraco/surface/rendercontent/byid/1064', { credentials: 'same-origin' })
      .then((response) => {
        if (response.ok) {
          return response.text()
        }
        return Promise.reject(response)
      })
      .then(result => { this.setState({ currentContent: result }) })
  }

  render() {
    return (
      <div className="App" dangerouslySetInnerHTML ={{ __html: this.state.currentContent }}>
      </div>
    );
  }
}

export default App;
