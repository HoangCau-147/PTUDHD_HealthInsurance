import classNames from 'classnames/bind';
import styles from './Service.module.scss';
import { useNavigate } from 'react-router-dom';
import Banner from '../../assets/image/banner-top.jpg';
import Img3 from '../../assets/image/bh3.png';
import { HomeApi } from '../../services/ApiHome/home';
import React, { useEffect, useState, useRef } from 'react';

import Slide from './Slide';

const cx = classNames.bind(styles);
const role = localStorage.getItem('role');

function Services() {
    let negative = useNavigate();

    const [product, setProduct] = useState([]);
    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await HomeApi();
                setProduct(response);


            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };
        fetchData();
    }, []);


    const swiperRef = useRef(null);

    return (
        <div className={cx('wrapper')}>
            <div className={cx('header')}>
                <img style={{ borderRadius: '0' }} className={cx('banner_top')} src={Banner} alt="Banner" />
                <h1 className={cx('title')}>Dịch vụ</h1>
            </div>
            <Slide />
        </div>
    );
}

export default Services;
