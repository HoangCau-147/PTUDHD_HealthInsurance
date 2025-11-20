import React from 'react';
import Slide from './Slide';
import ListInsurance from './ListInsurance';
import './home.css';

const Home = () => {
    return (
        <div className="containerHome" style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
            <div style={{ width: '100%', textAlign: 'center' }}>
                <Slide></Slide>
            </div>
            <div style={{ width: '100%' }}>
                <ListInsurance />
            </div>
        </div>
    );


};

export default Home;
