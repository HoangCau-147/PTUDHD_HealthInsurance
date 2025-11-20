import React, { useEffect, useState } from 'react';
import axios from 'axios';
import classNames from 'classnames/bind';
import { Link } from 'react-router-dom';
import { Image } from 'cloudinary-react';
import { useNavigate } from 'react-router-dom';
import { HomeApi } from '../../services/ApiHome/home';

// swiper
import { Swiper, SwiperSlide } from 'swiper/react';
import 'swiper/css';
import 'swiper/css/effect-coverflow';
import 'swiper/css/pagination';
import 'swiper/css/navigation';
import { EffectCoverflow, Pagination, Navigation } from 'swiper/modules';

//style
import styles from './Slide.module.scss';
const role = localStorage.getItem('role');


const cx = classNames.bind(styles);
const SlideServices = () => {
    const navigate = useNavigate();
    const [product, setProduct] = useState([]);

    const handleSeeMore = (id) => {
        navigate(`/service/${id}`);
    };

    const handleRegister = (id) => {
        if (role === 'Customer') {
            navigate(`/register/${id}`);
        } else if (!role) {
            navigate(`/login`);
        }
        else {
            navigate(`/admin`);

        }
    };

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

    return (
        <>
            {product && product.length > 0 ? (
                <Swiper
                    effect={'coverflow'}
                    grabCursor={true}
                    centeredSlides={true}
                    loop={true}
                    slidesPerView={0.82}
                    coverflowEffect={{
                        rotate: 0,
                        stretch: 0,
                        depth: 100,
                        modifier: 2.5,
                    }}
                    pagination={{ el: '.swiper-pagination', clickable: true }}
                    navigation={{
                        nextEl: '.swiper-button-next',
                        prevEl: '.swiper-button-prev',
                        clickable: true,
                    }}
                    modules={[EffectCoverflow, Pagination, Navigation]}
                    className={cx('slider')}
                >
                    {/* start slide */}
                    {product.map((curElem) => (
                        <SwiperSlide className={cx('card')} key={curElem.id}>
                            <Image
                                className={cx('card_img')}
                                cloudName={process.env.REACT_APP_CLOUDINARY_CLOUD_NAME}
                                publicId={curElem.imageUrl}
                                alt="image"
                                style={{ borderRadius: '0px' }}
                            />
                            <div className={cx('card_data')}>
                                <span className={cx('name')}>{curElem.policyName}</span>

                                <p className={cx('description')}>{curElem.shortDescription}</p>

                                <div className={cx('button')}>
                                    <button
                                        className={cx('btn', 'link')}
                                        onClick={() => handleSeeMore(curElem.productId)}
                                    >
                                        Xem chi tiết
                                    </button>
                                    <button
                                        className={cx('btn', 'buynow')}
                                        onClick={() => handleRegister(curElem.productId)}
                                    >
                                        Buy now!
                                    </button>
                                </div>
                            </div>
                        </SwiperSlide>
                    ))}
                    {/* end slide */}
                </Swiper>
            ) : (
                <div className="no-products-message">Không có bảo hiểm nào.</div>
            )}
        </>
    );
};

export default SlideServices;
