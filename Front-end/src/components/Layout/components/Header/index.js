import classNames from 'classnames/bind';
import styles from './Header.module.scss';
import companyLogo from '../../../../assets/image/Logo2.png';
import { Link, useNavigate } from 'react-router-dom';
import React, { useState } from 'react';

import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

//icon;
import { MdOutlineLogout } from 'react-icons/md';
import { MdAccountCircle } from 'react-icons/md';

function Header() {
    const navigate = useNavigate();
    const [activeNav, setActiveNav] = useState('');
    const handleLogout = () => {
        localStorage.removeItem('token');
        localStorage.removeItem('role');
        navigate('/login');
        toast.success('Logout Success!');
    };

    const handleNavClick = (navItem) => {
        setActiveNav(navItem);
    };
    const cx = classNames.bind(styles);
    // const thay vi var
    var token = localStorage.getItem('token');

    //fake token
    if (!token || token === '') {
        token = '';
    }
    return (
        <header className={cx('wrapper')}>
            <div className={cx('inner')}>
                <div className={cx('logo', 'item', 'one')}>
                    <Link to="/">
                        <img style={{ borderRadius: '0px' }} s src={companyLogo} alt="Logo" />
                    </Link>
                </div>
                <nav className={cx('navbar', 'item', 'four')}>
                    <li className={cx({ active_navbar: activeNav === 'home' })}>
                        <Link to="/" onClick={() => handleNavClick('home')}>
                            Trang chủ
                        </Link>
                    </li>
                    <li className={cx({ active_navbar: activeNav === 'service' })}>
                        <Link to="/service" onClick={() => handleNavClick('service')}>
                            Dịch vụ
                        </Link>
                    </li>
                    <li className={cx({ active_navbar: activeNav === 'aboutme' })}>
                        <Link to="/aboutme" onClick={() => handleNavClick('aboutme')}>
                            Giới thiệu
                        </Link>
                    </li>
                </nav>
                <div className={cx('right_navbar', 'item', 'one')}>
                    {token.length > 0 ? (
                        <div className={cx('account')}>
                            <Link to="/account" className={cx('icon_account')}>
                                <MdAccountCircle style={{ color: '#126131' }} />
                            </Link>
                            <button className={cx('logout-btn')} onClick={handleLogout}>
                                <MdOutlineLogout />
                            </button>
                        </div>
                    ) : (
                        <div className={cx('notoken')}>
                            <button className={cx('logup-btn')}>
                                <Link to="/signup">Logup</Link>
                            </button>
                            <button className={cx('login-btn')}>
                                <Link to="/login">Login</Link>
                            </button>
                        </div>
                    )}
                </div>
            </div>
        </header>
    );
}

export default Header;
