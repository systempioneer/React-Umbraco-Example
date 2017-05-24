import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import './index.css';
require('es6-promise').polyfill();
require('isomorphic-fetch');


ReactDOM.render(<App />, document.getElementById('root'));
registerServiceWorker();
