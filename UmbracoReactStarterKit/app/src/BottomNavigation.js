import React from 'react';

const BottomNavigation = props => {
  const { bottomNavigation, homeUrl, siteLogo } = props

  const handleClick = e => {
    if (e.target.tagName === 'A' && e.target.getAttribute("target") !== "_blank") {
      props.history.push(e.target.getAttribute('href'))
    }
  }


  return (
    <footer className="field dark">
        <div className="container">
            <div className="row" dangerouslySetInnerHTML={{ __html: bottomNavigation }} onClick={handleClick} />
        </div>
    </footer>
  );
}

export default BottomNavigation;