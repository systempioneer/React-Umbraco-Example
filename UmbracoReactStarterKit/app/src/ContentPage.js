import React, { Component } from 'react';

class ContentPage extends Component {
  constructor(props) {
    super(props)

    this.state = { currentContent: '' }
  }

  componentDidMount() {
    var pageId = window.__INITIAL_STATE__.content[this.props.location.pathname.replace(/\/?$/, '/')].Id

    console.log(this.props)

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
      <div dangerouslySetInnerHTML ={{ __html: this.state.currentContent }}>
      </div>
    );
  }
}

export default ContentPage;
