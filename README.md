# Umbraco React Example Site

Live demo: [http://umbraco-react.systempioneer.com/](http://umbraco-react.systempioneer.com/)


![Live demo screenshot](https://www.systempioneer.com/img/umbraco-react-example-2.png "Live demo screenshot")

## What is this?
This is the default Umbraco Fanoe starter kit re-imagined as a badass single-page app, powered by React. It's an example of how Umbraco and React can come together beautifully.

Built with love for our Umbraco friends by the dev team at [SystemPioneer](https://www.systempioneer.com/) 

## Features
* React components rendered server-side within the Umbraco pipeline
* Content rendered by Umbraco grid, edit content in the backoffice like a regular Umbraco site
* Using ES6 syntax & build pipeline immediately familiar to React developers 
* Bundled with Webpack with 90% code re-use between server and client bundles

Disclaimer: This is new project and shouldn't be used yet for production. It's unstable and apis will change

## Technical Overview
Incoming requests are handled by a [custom RenderMvcController](https://github.com/systempioneer/ReactUmbracoExample/blob/master/UmbracoReactStarterKit/Controllers/ReactRoutesController.cs), which is [registered](https://github.com/systempioneer/ReactUmbracoExample/blob/master/UmbracoReactStarterKit/App_Start/UmbracoReactStartup.cs#L30) as the default controller and always renders the [Master.cshtml](https://github.com/systempioneer/ReactUmbracoExample/blob/master/UmbracoReactStarterKit/Views/Master.cshtml) template. In that template React server rendering is achieved using [Reactjs.NET](https://reactjs.net/). An initial state for the React app is constructed using `UmbracoHelper` and passed as a prop to the root component.

On the client side we use [react-router](https://github.com/ReactTraining/react-router) and [construct route handlers programatically](https://github.com/systempioneer/ReactUmbracoExample/blob/master/UmbracoReactStarterKit/app/src/App.js#L31), using what we know about the Umbraco content nodes from the initial state. Every route renders a [ContentPage component](https://github.com/systempioneer/ReactUmbracoExample/blob/master/UmbracoReactStarterKit/app/src/ContentPage.js), which uses the fetch api to make a request to a custom SurfaceController called [RenderContentController](https://github.com/systempioneer/ReactUmbracoExample/blob/master/UmbracoReactStarterKit/Controllers/RenderContentController.cs). RenderContentController [returns a JSON object](https://github.com/systempioneer/ReactUmbracoExample/blob/master/UmbracoReactStarterKit/Controllers/RenderContentController.cs#L37) containing a "Content" property, which is HTML rendererd by Umbraco and is used by React to update the page. It also returns a "Name" property which is used by [react-helmet](https://github.com/nfl/react-helmet) to update the page title. 

## Contributing
We're definitely open for PRs! The project maintainer doesn't sleep and can merge a PR anytime. This is a new project and was built quickly as a proof-of-concept. There's alot of hacky code and we want to refactor everything.

Still to do (at least):
[ ] Refactor logic out of the [Master view](https://github.com/systempioneer/ReactUmbracoExample/blob/master/UmbracoReactStarterKit/Views/Master.cshtml)
[ ] The [ViewFromContentId method](https://github.com/systempioneer/ReactUmbracoExample/blob/master/UmbracoReactStarterKit/Controllers/ReactRenderMvcController.cs#L13) is referenced in a hacky way in the Master template, and should probably go in the service layer
[ ] The react code needs to be gone over to be refactored for readability
[ ] Let's write unit tests for the js and .NET

## License
Copyright 2017 SYSTEMPIONEER LIMITED

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

![](http://www.systempioneer.com/img/SystemPioneerSmall.png)
