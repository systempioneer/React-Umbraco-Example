import React, { Component } from 'react';
import { Helmet } from "react-helmet";
import MainNavigation from './MainNavigation';
import BottomNavigation from './BottomNavigation';

class ContentPage extends Component {
  constructor(props) {
    super(props)

    this.state = { currentContent: { Name: this.props.initialState.currentContent.Name, Content: this.props.initialState.currentContent.Content }}
  }

  componentDidMount() {
    var pageId = this.props.initialState.content[this.props.location.pathname.replace(/\/+?$/, '/')].Id

    if(this.props.initialState.currentContent.Url !== this.props.location.pathname) {
      this.setState({ currentContent: { Name: '', Content: '' } }, () => {
        fetch(`/umbraco/surface/rendercontent/byid/${pageId}`, { credentials: 'same-origin' })
          .then((response) => {
            if (response.ok) {
              return response.json()
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
        <Helmet>
          <title>{`${this.state.currentContent.Name} | ${this.props.initialState.siteTitle}`}</title>
        </Helmet>
        <ScrollToTopOnMount />
        <MainNavigation {...this.props.initialState} history={this.props.history} />


        <div dangerouslySetInnerHTML ={{ __html: this.state.currentContent.Content }} />


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
