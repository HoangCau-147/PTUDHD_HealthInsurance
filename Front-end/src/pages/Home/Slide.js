import React, { useEffect, useState } from 'react';
import './style.css';

const Slide = () => {
    const [slideIndex, setSlideIndex] = useState(1);

    useEffect(() => {
        const showSlides = () => {
            let newIndex = slideIndex + 1;
            if (newIndex > 3) {
                newIndex = 1;
            }
            setSlideIndex(newIndex);
        };

        const intervalId = setInterval(showSlides, 10000);

        return () => {
            clearInterval(intervalId);
        };
    }, [slideIndex]);

    const prevSlide = () => {
        setSlideIndex((prevIndex) => (prevIndex > 1 ? prevIndex - 1 : 3));
    };

    const nextSlide = () => {
        setSlideIndex((prevIndex) => (prevIndex < 3 ? prevIndex + 1 : 1));
    };

    const goToSlide = (n) => {
        setSlideIndex(n);
    };

    return (
        <div className="slideshow-container">
            <a className="prev" onClick={prevSlide}>
                &#10094;
            </a>

            {/* Your slides go here */}
            <div className="mySlides fade" style={{ display: slideIndex === 1 ? 'block' : 'none' }}>
                <div className="numbertext">1 / 3</div>
                <img
                    src={require('../../assets/image/banner-1.png')}
                    style={{ borderRadius: '0px', width: '100%' }}
                    alt="Slide 1"
                />
            </div>
            <div className="mySlides fade" style={{ display: slideIndex === 2 ? 'block' : 'none' }}>
                <div className="numbertext">2 / 3</div>
                <img
                    src={require('../../assets/image/banner-2.png')}
                    style={{ borderRadius: '0px', width: '100%' }}
                    alt="Slide 2"
                />
            </div>
            <div className="mySlides fade" style={{ display: slideIndex === 3 ? 'block' : 'none' }}>
                <div className="numbertext">3 / 3</div>
                <img
                    src={require('../../assets/image/banner-3.png')}
                    style={{ borderRadius: '0px', width: '100%' }}
                    alt="Slide 3"
                />
            </div>

            {/* Next button on the right */}
            <a className="next" onClick={nextSlide}>
                &#10095;
            </a>

            {/* The dots/circles at the bottom */}
            <div style={{ textAlign: 'center', position: 'absolute', bottom: '0', width: '100%' }}>
                <span className="dot" onClick={() => goToSlide(1)}></span>
                <span className="dot" onClick={() => goToSlide(2)}></span>
                <span className="dot" onClick={() => goToSlide(3)}></span>
            </div>
        </div>
    );
};

export default Slide;
