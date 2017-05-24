import React, { Component } from 'react';
import './App.css';
import {
  BrowserRouter as Router,
  Route,
  Link
} from 'react-router-dom';
import ContentPage from './ContentPage';

class App extends Component {
  render() {
    return (
      <Router>
        <div className="App">

          {Object.keys(window.__INITIAL_STATE__.content).map((item, index) => <Route key={index} exact path={item} component={ContentPage} /> )}

        </div>
      </Router>
    );
  }
}

export default App;
