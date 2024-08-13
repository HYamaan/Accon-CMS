import React, {useState,useMemo,memo} from "react";
import Slider from "react-slick";
import {LazyLoadImage} from "react-lazy-load-image-component";
import {useRouter} from "next/router";


function SampleNextArrow(props) {
    const {className, style, onClick} = props;
    return (
        <div
            className={className}
            style={{
                ...style,
                display: "block",
                position: "absolute",
                top: "50%",
                right: "3rem",
                transform: "translate(0, -50%)",
                zIndex: "100",
                cursor: "pointer"
            }}
            onClick={onClick}
        />
    );
}

function SamplePrevArrow(props) {
    const {className, style, onClick} = props;
    return (
        <div
            className={`${className}`}
            style={{
                ...style,
                display: "block",
                position: "absolute",
                top: "50%",
                left: "1.5rem",
                transform: "translate(0, -50%)",
                zIndex: "100",
                cursor: "pointer"
            }}
            onClick={onClick}
        />
    );
}

const SliderComponent = ({slider}) => {
    const router = useRouter();
    const [currentSlide, setCurrentSlide] = useState(0);

    console.log("slider", slider);
    const settings = {
        dots: false,
        lazyLoad: true,
        infinite: true,
        speed: 500,
        slidesToShow: 1,
        slidesToScroll: 1,
        initialSlide: 0,
        className: "main-slider",
        nextArrow: <SampleNextArrow/>,
        prevArrow: <SamplePrevArrow/>,
        afterChange: (current) => {
            setCurrentSlide(current);
        }
    };

    const getAnimateClass = (index) => (currentSlide === index ? "animate" : "");

    return (
        <div className="slider-section">
            <div className="slider-container">
                <Slider {...settings}>
                    {slider?.map((slide, index) => (
                        <div key={index} className="slider-section">
                            <LazyLoadImage
                                src={`/${slide.path}`}
                                alt={slide.path}
                                effect="blur"
                                priority="true"
                                threshold={0}
                            />
                            <div className={`slider-text ${getAnimateClass(index)}`}>
                                <h3>{slide.heading}</h3>
                                <p>{slide.content}</p>
                                <div className="d-flex gap-3 justify-content-center">
                                    <button
                                        className="primary-button"
                                        onClick={() => router.push(slide.button1Link)}
                                    >
                                        {slide.button1Text}
                                    </button>
                                    <button
                                        className="secondary-button"
                                        onClick={() => router.push(slide.button2Link)}
                                    >
                                        {slide.button2Text}
                                    </button>
                                </div>
                            </div>
                        </div>
                    ))}
                </Slider>
            </div>
        </div>
    );
};

export default React.memo(SliderComponent);
