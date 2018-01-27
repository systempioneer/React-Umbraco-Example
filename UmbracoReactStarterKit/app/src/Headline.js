import React, { Component } from 'react';

class Headline extends Component {
  constructor(props) {
    super(props)
  }

  render() {
    // Only on client
    if (window !== undefined) {
      // Expect this to run on each ContentPage rendered
      // by the Umbraco SurfaceController
      alert('this.props.value: ' + this.props.value)
      console.log(this.props.value)
    }
    
    return (
      <h1>{this.props.value}</h1>
    )
  }
}

export default Headline;
