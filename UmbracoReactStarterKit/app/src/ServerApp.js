import React, { Component } from 'react';
import './App.css';
import {
  StaticRouter as Router,
  Route
} from 'react-router';
import ContentPage from './ContentPage';

class App extends Component {
  constructor(props) {
    super(props)
  }

  render() {
    const { initialState } = this.props

    const RoutedContentPage = (innerProps) => {
      return (
        <ContentPage
          initialState={initialState}
          {...innerProps}
        />
      );
    }

    return (
      <Router
          location={initialState.location}
        >
        <div className="App">
          {Object.keys(this.props.initialState.content).map((item, index) => <Route key={index} exact path={item} component={RoutedContentPage} /> )}
        </div>
      </Router>
    );
  }
}

export default App;
