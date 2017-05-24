import React, { Component } from 'react';
import logo from './logo.svg';
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
      <div className="App" dangerouslySetInnerHTML={{ __html: this.state.currentContent }}>
        {/*<div className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h2>Welcome to React</h2>
        </div>
        <p className="App-intro">
          To get started, edit <code>src/App.js</code> and save to reload.
        </p>*/}
      </div>
    );
  }
}

export default App;
