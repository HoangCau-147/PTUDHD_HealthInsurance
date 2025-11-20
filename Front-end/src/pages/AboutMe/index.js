import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import classNames from 'classnames/bind';

import styles from './Aboutme.module.scss';
import Banner from '../../assets/image/banner-top.jpg';

//icon
import { IoIosInformationCircle, IoMdContacts } from 'react-icons/io';

const cx = classNames.bind(styles);

function AboutMe() {
    const [activeSection, setActiveSection] = useState('introduction');
    const handelInformation = () => {
        setActiveSection('introduction');
    };

    const handelContract = () => {
        setActiveSection('contact');
    };

    return (
        <>
            <div className={cx('header')}>
                <img style={{ borderRadius: '0' }} className={cx('banner_top')} src={Banner} alt="Banner" />
                <h1 className={cx('title')}>Giới thiệu</h1>
            </div>

            <nav className={cx('navigation')}>
                <li
                    id={cx('info')}
                    onClick={handelInformation}
                    className={cx(activeSection === 'introduction' ? 'active_navbar' : '')}
                >
                    <IoIosInformationCircle />
                    <Link to="">Giới thiệu </Link>
                </li>
                <li
                    id={cx('contract')}
                    onClick={handelContract}
                    className={cx(activeSection === 'contact' ? 'active_navbar' : '')}
                >
                    <IoMdContacts />
                    <Link to="">Liên hệ</Link>
                </li>
            </nav>

            <div className={cx('content')}>
                <section id={cx('introduction')} className={cx({ active: activeSection === 'introduction' })}>
                    <h2>Giới thiệu kênh bảo hiểm trực tuyến</h2>
                    <span className={cx('short_des')}>
                        Đây là dự án môn học Bảo hiểm sức khỏe, Phân tích hệ thống thông tin hiện đại - HCMUS
                    </span>
                </section>
                <section id={cx('contact')} className={cx('contract', { active: activeSection === 'contact' })}>
                    <h2>Đồ án Bảo hiểm sức khỏe, Phân tích hệ thống thông tin hiện đại - HCMUS </h2>
                    <span>Nhóm 6</span>
                    <div>
                        <h4>Điện thoại:</h4>
                        <span>(+84) 5718 717</span>
                    </div>
                    <div>
                        <h4>Email:</h4>
                        <span>hoangcau14783@gmail.com</span>
                    </div>
                </section>
            </div>
        </>
    );
}

export default AboutMe;
