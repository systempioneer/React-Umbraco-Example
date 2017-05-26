import React, { Component } from 'react';
import MainNavigation from './MainNavigation';
import BottomNavigation from './BottomNavigation';

class ContentPage extends Component {
  constructor(props) {
    super(props)

    this.state = { currentContent: this.props.initialState.currentContent.content }
  }

  componentDidMount() {
    var pageId = this.props.initialState.content[this.props.location.pathname.replace(/\/+?$/, '/')].Id

    if(this.props.initialState.currentContent.url !== this.props.location.pathname) {
      this.setState({ currentContent: '' }, () => {
        fetch(`/umbraco/surface/rendercontent/byid/${pageId}`, { credentials: 'same-origin' })
          .then((response) => {
            if (response.ok) {
              return response.text()
            }
            return Promise.reject(response)
          })
          .then(result => { this.setState({ currentContent: result }) })
      })
    }
  }

  render() {
    return (
      <div>
        <ScrollToTopOnMount />
        <MainNavigation {...this.props.initialState} history={this.props.history} />


        <div dangerouslySetInnerHTML ={{ __html: this.state.currentContent }} />


        <BottomNavigation {...this.props.initialState} history={this.props.history} />
      </div>
    );
  }
}

class ScrollToTopOnMount extends Component {
  componentDidMount(prevProps) {
    window.scrollTo(0, 0)
  }

  render() {
    return null
  }
}

export default ContentPage;
