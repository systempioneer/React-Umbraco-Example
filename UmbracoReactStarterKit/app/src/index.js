// import React from 'react';
// import ReactDOM from 'react-dom';
// import App from './App';
import registerServiceWorker from './registerServiceWorker';
require('es6-promise').polyfill();
require('isomorphic-fetch');

var React = require("expose-loader?React!react");
var ReactDOM = require("expose-loader?ReactDOM!react-dom");
var ReactDOMServer = require("expose-loader?ReactDOMServer!react-dom/server");
var Components = require('expose-loader?Components!./clientComponents');


// ReactDOM.render(<App />, document.getElementById('root'));
registerServiceWorker();
