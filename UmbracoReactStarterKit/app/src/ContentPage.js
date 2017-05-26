import React, { Component } from 'react';
import MainNavigation from './MainNavigation';
import BottomNavigation from './BottomNavigation';

class ContentPage extends Component {
  constructor(props) {
    super(props)

    this.state = { currentContent: '' }
  }

  componentDidMount() {
    var pageId = window.__INITIAL_STATE__.content[this.props.location.pathname.replace(/\/?$/, '/')].Id

    fetch(`/umbraco/surface/rendercontent/byid/${pageId}`, { credentials: 'same-origin' })
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
      <div>
        <MainNavigation {...window.__INITIAL_STATE__} history={this.props.history} />


        <div dangerouslySetInnerHTML ={{ __html: this.state.currentContent }} />


        <BottomNavigation {...window.__INITIAL_STATE__} history={this.props.history} />
      </div>
    );
  }
}

export default ContentPage;
