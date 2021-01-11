import React from 'react'; 

import styles from './index.module.css';

function Header() {
    return (
        <header>
            <div>
                <img src={process.env.PUBLIC_URL + '/images/logo.svg'} alt="Site logo"></img>
            </div>

            <nav>
                <ul>
                    <li></li>
                </ul>
            </nav>
        </header>
    )
}

export default Header;