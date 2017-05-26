import React from 'react';
import { Link } from 'react-router-dom';

const MainNavigation = props => {
  const { mainNavigation, homeUrl, siteLogo } = props

  const handleClick = e => {
    e.preventDefault()

    if (e.target.tagName === 'A') {
      props.history.push(e.target.getAttribute('href'))
    }
  }

  return (
    <header>
      <div className="container">
          <div className="row">
              <div className="col-xs-8 col-sm-12 col-md-4">
                  <Link to={homeUrl}>
                      <div className="brand" style={{"backgroundImage":`url('${siteLogo}?height=65&width=205&bgcolor=000')`}}></div>
                  </Link>
              </div>
              <div className="col-sm-12 col-md-8">
                  <nav dangerouslySetInnerHTML={{ __html: mainNavigation }} onClick={handleClick} />
              </div>
          </div>
      </div>

      <div id="toggle" className="toggle">
          <Link to="#" className="cross"><span></span></Link>
      </div>
    </header>
  );
}

export default MainNavigation;